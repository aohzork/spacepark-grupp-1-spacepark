class Spaceship {

    constructor(person){
        this.ID;
        this.Person = person;
    }

    ToJsonString() {
        return JSON.stringify(this);
    }
} 