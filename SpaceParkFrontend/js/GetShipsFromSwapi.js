validateButton();


function validateButton() {
    if (document.getElementById("namebox").value === "" || document.getElementById("namebox").value === null) {
        document.getElementById("validate").disabled = true;
    }
    else {
        document.getElementById('validate').disabled = false;
    }
}

function getStarShipsFromInput() {
    let input = document.getElementById("namebox").value;
    getStarShipsFromSwapi(input)
}


function getStarShipsFromSwapi(input) {
    let url = `https://swapi.dev/api/people/?search=${input}`
    let request = new XMLHttpRequest();
    request.open("GET", url);
    request.onload = function () {
        let data = JSON.parse(request.responseText);

        try {
            let starShips = [data.results[0].starships];
            fetchShips(starShips);
            document.getElementById("errorMessage").innerHTML = "";
        }
        catch (error) {
            document.getElementById("errorMessage").innerHTML = input + ": " + "Are not allowed to use SpacePark";
        }
    }
    request.send();
}

function fetchShips(shipsUrl) {

    $("#search_categories").empty();
    shipsUrl[0].forEach(url => {
        fetch(url)
            .then(response => response.json())
            .then(json => {
                let sel = document.getElementById("search_categories");
                let opt = document.createElement("option");
                opt.appendChild(document.createTextNode(json.name));
                sel.appendChild(opt);

            });
    });
}