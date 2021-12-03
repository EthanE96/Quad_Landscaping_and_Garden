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
    let count = 1;
    json.forEach((plant) => {
      htmlTitle = plant.plantName; 
      htmlDescrip = plant.plantDescrip;
      
      document.getElementById("name"+count).innerHTML = htmlTitle;
      document.getElementById("descrip"+count).innerHTML = htmlDescrip;

      count++;
    });
  })
  .catch(function (error) {
    console.log(error);
  });
}

