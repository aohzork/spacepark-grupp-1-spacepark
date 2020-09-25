/****************************************************
------------------ SPACESHIP CALLS ------------------
****************************************************/

//Method making a call to our api to post a spaceship.
const postSpaceship = async(spaceshipObject) => {
    try {

        //Do request
        let response = await fetch(`https://localhost:44350/api/v1.0/spaceship`, 
            {
                method: 'POST',
                headers: {'Content-Type': `application/json`},
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