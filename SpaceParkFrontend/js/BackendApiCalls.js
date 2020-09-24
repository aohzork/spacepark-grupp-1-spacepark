//Method making a call to our api to fetch a person by name.
const getPerson = async(name) => {
    try {
        let response = await fetch(`https://localhost:44350/api/v1.0/person/${name}`, 
            {method: 'GET'});
        return response.json();
    } catch (error) {
        console.error(error);
    }
};
    
//Method making a call to our api to delete a person by name.
const deletePerson = async(name) => {
    try {
        let response = await fetch(`https://localhost:44350/api/v1.0/person/${name}`, 
            {method: 'DELETE'});
        return response.json;
    } catch (error) {
        console.error(error);
    }
};