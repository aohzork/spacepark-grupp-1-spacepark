//Method making a call to our api to fetch a person by name.
const getPerson = async(name) => 
    fetch(`https://localhost:44350/api/v1.0/person/${name}`)
    .then( response => {
        return response.json();
    })
    .catch(console.error);
    
//Method making a call to our api to delete a person by name.
const deletePerson = async(name) => {
    try {
        let result = await fetch(`https://localhost:44350/api/v1.0/person/${name}`, 
            {method: 'DELETE'});
        return result;
    } catch (error) {
        console.error(error);
    }
};