
$(() => {

    let i = 0;
    $("#park").click(() => {
        i = 1,
            $("#park").css("background-color", "lightgreen"),
            $("#unpark").css("background-color", "white"),
            $("#submit").text("Park")
    });
    $("#unpark").click(() => {
        i = 2,
            $("#unpark").css("background-color", "lightgreen"),
            $("#park").css("background-color", "white"),
            $("#submit").text("Unpark")
    });

    $("#submit").click(() => {
        if (i === 1) {
            park();

        }
        if (i === 2) {
            unpark();
        }

    });

    $("#validate").click(() => {
        checkPerson(i);
    });

    
});


function checkPerson(i){
    let inputName = $("#namebox").val()   

    //if Park is pressed
    if(i === 1){

        //Validate starwarscustomer and callback name to proceed
        validateUserFromSwapi(inputName, function(callback){
            let swapiActor = callback;
            console.log(swapiActor);

            //Check if customer has already parked
            if(swapiActor !== 0){
                getPersonRequestStatusCallback(swapiActor, function(callbackStatus){
                    console.log(callbackStatus)
                    if(callbackStatus === 200){
                        alert("You have already parked! Please Checkout(Unpark) before you can park again.");
                    }

                    //free to park if not found in db
                    if(callbackStatus === 404){
                        alert("Choose ship and Park!");
                        getStarShipsFromInput();

                        console.log("LAST: "+ swapiActor);

                        //call park and pass actor name
                        park(swapiActor);
                    }
                });
            }            
        });
    } 
    
    //if Unpark is pressed
    else if(i == 2){
        getPersonRequestStatusCallback(inputName, function(callbackStatus){
            if(callbackStatus === 404){
                alert("Are you sure you have parked? Spacepark cannot find any vehicle registred on you")
            }

            if(callbackStatus === 200){
                getPerson(inputName).then(function(result){
                    console.log("Spaceship ID: " + result.spaceshipID);
                });
            }
        }); 

        
    }

}

function park(personToPark) {
    console.log("inside park: " + personToPark);
}

function unpark(personToUnpark){
    console.log("inside unpark: " + personToUnpark);
}

// function unpark() {
//     let name = $("#namebox").val();
//     person(name);
// }

// let p = getSpaceship(1).then(result => result);
// p.then(result => console.log(result));

// getPerson("eric").then(function(result){
//     console.log(result.spaceshipID);
// });

//let ppp = getPerson("kalle").then(result => result);
//ppp.then(result => console.log(result));

//person("eric");

