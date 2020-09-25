//Method making a call to our api to fetch a person by name.
const getParkedPerson = async(name) => 
    fetch(`https://localhost:44350/api/v1.0/person/${name}`)
    .then( response => {
        console.log(response)
        return response.json();
    })
    .catch(console.error);