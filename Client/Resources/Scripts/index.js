//Search Function
function searchButton(){  
    const plantsAPI = "https://quadlg-api.herokuapp.com/api/plants";

  fetch(plantsAPI)
  .then(function (respone) {
    console.log(respone);
    return respone.json();
  })
  .then(function (json) {
    let plantName = "";

    json.forEach((plant) => {
      plantName += "<option value=\""+plant.plantName+"\">"
      
      document.getElementById("brow").innerHTML = plantName;
    }); 
  })
  .catch(function (error) {
    console.log(error);
  });
}




// Googe Sign In Script
function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();

    var confirm = "ethanaedwards5@gmail.com"
    var userEmail = profile.getEmail()

    if (userEmail == confirm) {
        window.location="admin.html";

        var auth2 = gapi.auth2.getAuthInstance();
        auth2.signOut().then(function (){
        console.log('User signed out.');
        });
    }
    else{
        alert("Passwords do not match.");
    }
}