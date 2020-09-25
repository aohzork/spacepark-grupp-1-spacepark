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
        //Turn object into Json
        let asJson = JSON.stringify(personObject);

        //Do preflight request
        

        //Do actual request
        let response = await fetch(`https://localhost:44350/api/v1.0/person`, 
            {
                method: 'POST',
                //headers: {'Content-Type': `plain/text`},
                body: '{"name":"Crappa Crapsson"}'
            });
        //let json = response.json()
        //return response.json();
    } catch (error) {
        console.error(error);
    }
};

const postPersonTwo = async(personObject) => {
    $.ajax({
        type: "POST",
        crossDomain: true,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(personObject),
        url: "https://localhost:44350/api/v1.0/person"        
    });    
}
