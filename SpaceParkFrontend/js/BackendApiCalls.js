/****************************************************
------------------ SPACESHIP CALLS ------------------
****************************************************/

//Method making a call to our api to delete a spaceship by id.
const deleteSpaceship = async(id) => {    
    try 
    {
        let response = await fetch(`https://localhost:44350/api/v1.0/spaceship/${id}`,
            {method: "DELETE"}
        );

        console.log(response);
        return response;
    }
    catch(error)        
    {
        console.error(error);
    }
}