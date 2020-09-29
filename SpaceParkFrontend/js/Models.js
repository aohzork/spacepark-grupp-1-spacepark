
class Spaceship {
    constructor(person){
        this.ID;
        this.Person = person;
    }

    ToJsonString() {
        return JSON.stringify(this);
    }
}

class Person {
    constructor(name){
        this.ID;
        this.Name = name;
    }

    ToJsonString() {
        return JSON.stringify(this);
    }
}


class ParkingSpace{

    constructor(Spaceship, parkinglot){
        this.ID;
        this.SpaceShip=Spaceship
        this.ParkingLot=parkinglot
    }


}

