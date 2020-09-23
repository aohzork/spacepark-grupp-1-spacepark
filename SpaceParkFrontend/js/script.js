
//IsParked("Eric").then(response => console.log(response.json())).catch(error => console.error(`Request failed: ${error}`));
//console.log(IsParked("Eric"));
let name = "Luke Skywalker";
fetch(`https://localhost:44350/api/v1.0/person/${name}`).then(res => console.log(res.json())).catch(console.error);