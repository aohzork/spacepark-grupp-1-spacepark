/****************************************************
------------------- PERSON CALLS --------------------
****************************************************/

//Method making a call to our api to fetch a person by name.
const getPerson = async(name) => {
    try {
        let response = await fetch(`https://localhost:44350/api/v1.0/person/${name}`, 
            {method: 'GET'});
        let json = response.json();
        return json;
    } catch (error) {
        console.error(error);
    }
};

//Method making a call to our api to post a person by name.
const postPerson = async(personObject) => {
    try {
        //Turn object into Json-string
        let asJson = JSON.stringify(personObject);

        //Do request
        let response = await fetch(`https://localhost:44350/api/v1.0/person`, 
            {
                method: 'POST',
                headers: {'Content-Type': `application/json`},
                body: asJson
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
