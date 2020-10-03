
/****************************************************
------------------ SPACESHIP CALLS ------------------
****************************************************/

//Method making a call to our api to fetch a spaceship by ID.
const getSpaceship = async (id) => {
    try {
        let response = await fetch
            (
                `https://localhost:44350/api/v1.0/spaceship/${id}`,
                { method: "GET" }
            );
        let data = await response.json();

        console.log(response);

        let obj = new Spaceship();
        obj = obj.MapFromJson(JSON.stringify(data));
        return obj;
    }
    catch (error) {
        console.error(error);
    }
};

//Method making a call to our api to post a spaceship.
const postSpaceship = async (spaceshipObject) => {
    try {

        //Do request
        let response = await fetch(`https://localhost:44350/api/v1.0/spaceship`,
            {
                method: 'POST',
                headers: { 'Content-Type': `application/json` },
                body: spaceshipObject.ToJsonString()
            });

        //Log the response to console
        console.log(response);

        //Get the response body as json and return it
        let json = response.json();
        return json;
    } catch (error) {
        console.error(error);
    }
};

//Method making a call to our api to delete a spaceship by id.
const deleteSpaceship = async (id) => {
    try {
        //Save the person that belongs to the ship to delete it after the ship has been deleted
        let person = getSpaceship(id).then(result => JSON.parse(result));
        let response = await fetch(`https://webapibackendsw.azurewebsites.net/api/v1.0/spaceship/${id}`,
            { method: "DELETE" }
        );

        console.log(response);
        return response;
    }
    catch (error) {
        console.error(error);
    }
}


/****************************************************
------------------- PERSON CALLS --------------------
****************************************************/
function getPersonRequestStatusCallback(name, callback) {
    let url = `https://localhost:44350/api/v1.0/person/${name}`;

    let request = new XMLHttpRequest();
    request.open("GET", url);

    request.onload = function () {
        //console.log(request.status);
        callback(request.status);

        try {
            let data = JSON.parse(request.responseText);
            console.log(data.name);
        } catch (error) {
            console.log("no person in db with that name");
        }
    };
    request.send();
}



//Method making a call to our api to fetch a person by name.
const getPerson = async (name, callback) => {
    try {
        let response = await fetch(`https://localhost:44350/api/v1.0/person/${name}`,
            { method: 'GET' });
        let data = await response.json();

        console.log(response);

        let obj = new Person();
        obj = obj.MapFromJson(JSON.stringify(data));
        
        return obj;
    } catch (error) {
        //console.error(error);
        alert("Du måste parkera innan du kan checka ut")
    }
};

//Method making a call to our api to post a person by name.
const postPerson = async (personObject) => {
    try {

        //Do request
        let response = await fetch(`https://localhost:44350/api/v1.0/person`,
            {
                method: 'POST',
                headers: { 'Content-Type': `application/json` },
                body: personObject.ToJsonString()
            });

        //Log the response to console
        console.log(response);

        //Get the response body as json and return it
        let json = response.json();
        return json;
    } catch (error) {
        console.error(error);
    }
};

//Method making a call to our api to delete a person by name.
const deletePerson = async (name) => {
    try {
        let response = await fetch(`https://webapibackendsw.azurewebsites.net/api/v1.0/person/${name}`,
            { method: 'DELETE' });
        return response.json;
    } catch (error) {
        console.error(error);
    }
};


const deletePersonById = async (id) => {
    try {
        let response = await fetch(`https://webapibackendsw.azurewebsites.net/api/v1.0/person/${id}`,
            { method: 'DELETE' });
        return response.json;
    } catch (error) {
        console.error(error);
    }
};



const deleteParkingSpace = async (id) => {
    try {
        let response = await fetch(`https://webapibackendsw.azurewebsites.net/api/v1.0/ParkingSpace/${id}`,
            { method: 'DELETE' });
        return response.json;
    } catch (error) {
        console.error(error);
    }
};

const postParkingSpace = async (ParkingSpaceObject) => {
    try {

        //Do request
        let response = await fetch(`https://webapibackendsw.azurewebsites.net/api/v1.0/ParkingSpace`,
            {
                method: 'POST',
                headers: { 'Content-Type': `application/json` },
                body: ParkingSpaceObject.ToJsonString()
            });

        //Log the response to console
        console.log(response);

        //Get the response body as json and return it
        let json = response.json();
        return json;
    } catch (error) {
        console.error(error);
    }
};
