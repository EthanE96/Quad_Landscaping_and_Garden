//api fetch
fetch('https://quadlg-api.herokuapp.com/api/plants')
      .then(response => response.json())
      .then(data => {
        console.log(data)
        gridOptions.api.setRowData(data);
        gridOptions.api.sizeColumnsToFit();
        gridOptions.api.setDomLayout('autoHeight');
        document.querySelector('#myGrid').style.height = '';
});

var columnDefs = [
  {headerName: "ID", field: "id", editable: false, filter: false, width: 100},
  {headerName: "Image", field: "imageUrl", cellRenderer: ({ value }) => `<img style="height: 250px; width: 250px; margin-left: -25px; text-align: center;" src=${value}/>`,
      minWidth: 250, maxWidth: 350, cellStyle: {textAlign: 'center'}},
  {headerName: "Plant Name", field: "plantName"},
  {headerName: "Plant Description", field: "plantDescrip", wrapText: true},
  {headerName: "Plant Water Amount", field: "plantWater" },
  {headerName: "Plant Sunlight", field: "plantSunlight"},
  {headerName: "Season", field: "season"}
];

// let the grid know which columns and what data to use
var gridOptions = {
      rowHeight: 200,
      headerHeight: 75,
      pagination: true,
      paginationPageSize: 10,
      rowClass: 'row-class',
      editType: 'fullRow',

      getRowClass: params => {
        if (params.node.rowIndex % 2 === 0) {
          return 'evens';
        }
        else {
          return 'odds';
        }
      },
      onRowValueChanged: onRowValueChanged,

      onRowEditingStarted: function (event) {
        console.log('row editing');
      },
      onRowEditingStopped: function (event) {
        console.log('stopped row editing');
      },

      defaultColDef: {
        editable: true,
        sortable: true, 
        filter: true,
        paginationAutoPageSize: true,
        pagination: true
    },
  columnDefs: columnDefs
}

function newPlantButton(){
  const imageUrlEle = document.getElementById("imageURLEle").value;
  const plantNameEle = document.getElementById("plantNameEle").value;
  const plantDescripEle = document.getElementById("plantDescripEle").value;
  const plantWaterEle = document.getElementById("plantWaterEle").value;
  const plantSunlightEle = document.getElementById("plantSunlightEle").value;
  const seasonEle = document.getElementById("seasonEle").value;
  const newPlant = "https://quadlg-api.herokuapp.com/api/plants/";

  fetch(newPlant, {
    method: "POST",
    headers: {
      "Content-Type": 'application/json'
    },
    body: JSON.stringify({imageUrl: imageUrlEle,
      plantName: plantNameEle,
      plantDescrip: plantDescripEle,
      plantWater: plantWaterEle,
      plantSunlight: plantSunlightEle,
      season: seasonEle})
    })
      .then((respone) => {
        console.log(respone);
        getPlants();
      })
}

function deleteButton(){
  const deleteID = document.getElementById("deleteElement").value;
  const deletePlant = "https://quadlg-api.herokuapp.com/api/plants/" + deleteID;
  
  fetch(deletePlant, {
    method: "DELETE",
    headers: {
            "Content-Type": 'application/json'
        }
  }).then((respone)=>{
    console.log(respone);
    getPlants();
  })
}

function onRowValueChanged(event) {
  var data = event.data;
  console.log(
    'onRowValueChanged: (' +
      data.id +
      ', ' +
      data.imageUrl +
      ', ' +
      data.plantName +
      ', ' +
      data.plantDescrip +
      ', ' +
      data.plantWater +
      ', '+
      data.plantSunlight +
      ', ' +
      data.season +
      ')'
  );
  deletePlant(data);
  createPlant(data);
}

function deletePlant(data){
  const deletePlant = "https://quadlg-api.herokuapp.com/api/plants/" + data.id;
  fetch(deletePlant, {
    method: "DELETE",
    headers: {"Content-Type": 'application/json'},
  }).then((response)=>{
      console.log(response);
  });
}

function createPlant(data){
  const newPlant = "https://quadlg-api.herokuapp.com/api/plants/";
  fetch(newPlant, {
    method: "POST",
    headers: {"Content-Type": 'application/json'},
    body: JSON.stringify({id: data.id,
      imageUrl: data.imageUrl,
      plantName: data.plantName,
      plantDescrip: data.plantDescrip,
      plantWater: data.plantWater,
      plantSunlight: data.plantSunlight,
      season: data.season  
    })
  }).then((response) => {
    console.log(response);
    getPlants();
  })
}

function setAutoHeight() {
  gridOptions.api.setDomLayout('autoHeight');
  document.querySelector('#myGrid').style.height = '';
}

// setup the grid after the page has finished loading
document.addEventListener('DOMContentLoaded', function() {
    var gridDiv = document.querySelector('#myGrid');
    new agGrid.Grid(gridDiv, gridOptions);
});


function getPlants(){
  fetch('https://quadlg-api.herokuapp.com/api/plants')
        .then(response => response.json())
        .then(data => {
          console.log(data)
          gridOptions.api.setRowData(data);
          gridOptions.api.sizeColumnsToFit();
          gridOptions.api.setDomLayout('autoHeight');
          document.querySelector('#myGrid').style.height = '';
  });
}
  