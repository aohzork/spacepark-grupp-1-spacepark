/****************************************************
------------------ SPACESHIP CALLS ------------------
****************************************************/

//Method making a call to our api to fetch a spaceship by ID.
const getSpaceship = async(id) => {
    try 
    {
        let response = await fetch
        (
            `https://localhost:44350/api/v1.0/spaceship/${id}`
        );

        console.log(response);

        let json = response.json();
        return json;
    } 
    catch (error) 
    {
        console.error(error);
    }
};