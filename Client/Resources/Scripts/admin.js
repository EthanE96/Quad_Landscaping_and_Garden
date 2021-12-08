$(document).ready(function(){
	// Activate tooltip
	$('[data-toggle="tooltip"]').tooltip();
	
	// Select/Deselect checkboxes
	var checkbox = $('table tbody input[type="checkbox"]');
	$("#selectAll").click(function(){
		if(this.checked){
			checkbox.each(function(){
				this.checked = true;                        
			});
		} else{
			checkbox.each(function(){
				this.checked = false;                        
			});
		} 
	});
	checkbox.click(function(){
		if(!this.checked){
			$("#selectAll").prop("checked", false);
		}
	});
});

function getPlants(value){ //GET METHOD
  const plantsAPI = "https://quadlg-api.herokuapp.com/api/plants";

  fetch(plantsAPI)
  .then(function (respone) {
    console.log(respone);
    return respone.json();
  })
  .then(function (json) {
    let MTitle = "";
    let MDescrip = "";

        json.forEach((plant) => {
            if (plant.plantName = value){
                MTitle = plant.plantName;
                MDescrip = plant.plantDescrip;
            }
        document.getElementById("Mname").innerHTML = MTitle;
        document.getElementById("Mdescrip").innerHTML = MDescrip;
        });
        $('#genModal').modal('show'); 
    })
  .catch(function (error) {
    console.log(error);
  });
}