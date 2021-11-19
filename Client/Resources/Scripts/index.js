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
      document.getElementById("test").innerHTML = html;
    })
    .catch(function (error) {
      console.log(error);
    });
}

//GET: api/plants/5

//POST: api/plants
function addPlant() {
  const newText = document.getElementById("editPlantName").value;
  const plantAPIURL = "https://localhost:5001/api/plant/";

  fetch(plantAPIURL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ plantName: newText }),
  }).then((respone) => {
    console.log(respone);
    AllPlants();
  });
}

//PUT: api/plants/5
function editPlant() {
  const postEditID = document.getElementById("editID").value;
  const postEditText = document.getElementById("editText").value;
  const editApiUrl = "https://localhost:5001/api/plant/" + postEditID;

  fetch(editApiUrl, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(postEditText),
  }).then((respone) => {
    console.log(respone);
    AllPlants();
  });
}

// DELETE: api/plants/5
function removePlant() {
  const ppostID = document.getElementById("deletePost").value;
  const deleteApiUrl = "https://localhost:5001/api/plant/" + ppostID;

  fetch(deleteApiUrl, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
    },
  }).then((respone) => {
    console.log(respone);
    AllPlants();
  });
}

function reseedDatabase() {
  const temp = 1;
  const editText = "reseed";
  const editApiUrl = "https://localhost:5001/api/plants/" + temp;

  fetch(editApiUrl, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(editText),
  }).then((respone) => {
    console.log(respone);
    getPosts();
  });
}