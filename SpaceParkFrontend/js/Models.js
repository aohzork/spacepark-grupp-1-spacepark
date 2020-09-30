class Person {
    constructor(){
        this.ID = "";
        this.Name = "";
    }

    ToJsonString() {
        return JSON.stringify(this);
    }

    MapFromJson(jsonString) {
        let myMap = JSON.parse(jsonString);        
        let obj = new Person();

        obj = myMap;

        return obj;        
    }
}

class Spaceship {
    constructor(){
        this.ID = "";
        this.Person = new Person();
    }

    ToJsonString() {
        return JSON.stringify(this);
    }

    MapFromJson(jsonString) {
        let myMap = JSON.parse(jsonString);        
        let obj = new Spaceship();

        obj = myMap;

        return obj;        
    }
}


class ParkingSpace{

    constructor(Spaceship, parkinglot){
        this.ID;
        this.SpaceShip=Spaceship
        this.ParkingLot=parkinglot
    }


}

