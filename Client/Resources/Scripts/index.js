//GET: api/plants
function AllPlants() {
  const allPlantsURL = "https://localhost:5001/api/plants/";

  fetch(allPlantsURL)
    .then(function (respone) {
      console.log(respone);
      return respone.json();
    })
    .then(function (json) {
      let html = "<ul>";
      json.forEach((plant) => {
        html +=
          "<li>" +
          "Name: " +
          plant.plantName +
          " Plant Description: " +
          plant.plantDescript +
          " Water: " +
          plant.plantWater +
          " Plant Sun:" +
          plant.plantSunLight +
          " Season: " +
          plant.season +
          "</li>";
      });
      html += "</ul>";
      document.getElementById("allPlants").innerHTML = html;
    })
    .catch(function (error) {
      console.log(error);
    });
}