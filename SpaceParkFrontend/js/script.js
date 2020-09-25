$("#submit").click(getParkedPerson("Eric"))

function GetPersonFronSwapi()
{

    fetch("https://localhost:44350/api/v1.0/person/Eric").catch(function(error) {
        alert('There has been a problem with your fetch operation: ' + error.message);
})};


