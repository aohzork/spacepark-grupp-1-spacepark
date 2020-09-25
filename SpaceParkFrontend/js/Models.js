class Person {
    constructor(name){
        this.ID;
        this.Name = name;
    }

    ToJsonString() {
        return JSON.stringify(this);
    }
}