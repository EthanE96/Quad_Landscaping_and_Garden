// function getPlants(){ //GET METHOD
//   const plantsAPI = "https://quadlg-api.herokuapp.com/api/plants";

//   fetch(plantsAPI)
//   .then(function (respone) {
//     console.log(respone);
//     return respone.json();
//   })
//   .then(function (json) {
//     let htmlTitle = "";
//     let htmlDescrip = "";
//     json.forEach((plant) => {
//       htmlTitle += plant.plantName ;
//       htmlDescrip += plant.plantDescrip ; });
//     document.getElementById("name").innerHTML = htmlTitle;
//     document.getElementById("descrip").innerHTML = htmlDescrip;
//   })
//   .catch(function (error) {
//     console.log(error);
//   });
// }

function getPlants(){ //GET METHOD
  const plantsAPI = "https://quadlg-api.herokuapp.com/api/plants";

  fetch(plantsAPI)
  .then(function (respone) {
    console.log(respone);
    return respone.json();
  })
  .then(function (json) {
    let htmlTitle =" <div class=\"modal fade\" id=\"exampleModal\" tabindex=\"-1\" aria-labelledby=\"exampleModalLabel\" aria-hidden=\"true\"> "
      + " <div class=\"modal-dialog\"> " 
      + " <div class=\"modal-content\"> "
      + " <div class=\"modal-header\"> ";
    json.forEach((plant) => {
      let count = 1;
      htmlTitle += "<h5 class=\"modal-title\" id=\"exampleModalLabel\"> " + plant.plantName + "</h5>" 
      + "<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"modal\" aria-label=\"Close\">< /button> "
      + "</div>"
      +    "<div class=\"modal-body\">"
      +     plant.plantDescrip 
      +   "</div>"
      +    "<div class=\"modal-footer\">"
      +     "<button type=\"button\" class=\"btn btn-secondary\" data-bs-dismiss=\"modal\">Close</button>"
      +     "<button type=\"button\" class=\"btn btn-primary\">Save changes</button>"
      +     "</div>"
      +     "</div>"
      +   "</div>"
      + "</div>" ;
      count ++;
    });
    document.getElementById("modal").innerHTML = htmlTitle;
  })
  .catch(function (error) {
    console.log(error);
  });
}
