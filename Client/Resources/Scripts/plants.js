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
    let htmlMTitle = "";
    let htmlMDescrip = "";
    let count = 1;

    json.forEach((plant) => {
      htmlTitle = plant.plantName; 
      htmlDescrip = plant.plantDescrip;

      htmlMTitle = plant.plantName
      htmlMDescrip = plant.plantDescrip
      
      document.getElementById("name"+count).innerHTML = htmlTitle;
      document.getElementById("descrip"+count).innerHTML = htmlDescrip;
      
      document.getElementById("Mname"+count).innerHTML = htmlMTitle;
      document.getElementById("Mdescrip"+count).innerHTML = htmlMDescrip;

      count++;
    });
  })
  .catch(function (error) {
    console.log(error);
  });
}

