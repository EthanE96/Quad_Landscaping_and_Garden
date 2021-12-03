function getPlants(){ //GET METHOD
  const plantsAPI = "https://quadlg-api.herokuapp.com/api/plants";

  fetch(plantsAPI)
  .then(function (respone) {
    console.log(respone);
    return respone.json();
  })
  .then(function (json) {
    let htmlTitle = "";
    let htmlDescrip = "";
    json.forEach((plant) => {
      htmlTitle += plant.plantName ;
      htmlDescrip += plant.plantDescrip ; });
    document.getElementById("name").innerHTML = htmlTitle;
    document.getElementById("descrip").innerHTML = htmlDescrip;
  })
  .catch(function (error) {
    console.log(error);
  });
}