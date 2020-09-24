class Person {
    constructor(name){
        this.Name = name;
    }
}

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
        let asJson = JSON.stringify(personObject);
        let response = await fetch(`https://localhost:44350/api/v1.0/person/`, 
            {
                method: 'POST',
                //mode: 'no-cors',
                //headers: {'Content-Type': 'application/json'},
                body: asJson
            });
        let json = response.json();
        return json;
    } catch (error) {
        console.error(error);
    }
};

const postPersonTwo = async(personObject) => {
    $.ajax({
        type: "POST",
        crossDomain: true,
        dataType: "json",
        data: JSON.stringify(personObject),
        url: "https://localhost:44350/api/v1.0/person",
        contentType: "application/json"
    });    
}
