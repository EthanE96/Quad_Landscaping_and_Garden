var columnDefs = [
  {headerName: "Image", field: "imageUrl", cellRenderer: ({ value }) => `<img style="height: 250px; width: 250px" src=${value}/>`,
    minWidth: 300, maxWidth: 350},
  {headerName: "Plant Name", field: "plantName"},
  {headerName: "Plant Description", field: "plantDescrip", wrapText: true},
  {headerName: "Plant Water Amount", field: "plantWater" },
  {headerName: "Plant Sunlight", field: "plantSunlight"},
  {headerName: "Season", field: "season"}
];

// let the grid know which columns and what data to use
var gridOptions = {
      rowHeight: 200,
      pagination: true,
      paginationPageSize: 10,
      defaultColDef: {
        resizable: true,
        sortable: true, 
        filter: true,
        paginationAutoPageSize: true,
        pagination: true
    },
  columnDefs: columnDefs
};

function setAutoHeight() {
  gridOptions.api.setDomLayout('autoHeight');
  document.querySelector('#myGrid').style.height = '';
}


// setup the grid after the page has finished loading
document.addEventListener('DOMContentLoaded', function() {
    var gridDiv = document.querySelector('#myGrid');
    new agGrid.Grid(gridDiv, gridOptions);
});


fetch('https://quadlg-api.herokuapp.com/api/plants')
      .then(response => response.json())
      .then(data => {
        console.log(data)
        gridOptions.api.setRowData(data);
        gridOptions.api.sizeColumnsToFit();
        gridOptions.api.setDomLayout('autoHeight');
        document.querySelector('#myGrid').style.height = '';
      });