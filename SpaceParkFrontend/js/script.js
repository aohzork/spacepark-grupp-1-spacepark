
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

    //let isval = isValidated(isval);   
    
    let test;

    let personInDB = person(inputName);
    let personData;

    var proceed = 0;

    //if Park is pressed
    if(i === 1){
        validateUserFromSwapi(inputName, test);

        console.log(test);
        //check if person belong to starwars
        // try{
        //     let swActorResponseData = JSON.parse(swActorResponse.responseText);
        //     document.getElementById("errorMessage").innerHTML = [swActorResponseData.results[0].name] + ": " + "Have been verified";
            
        //     //check if person exist in database
        //     // try{
        //     //     personData = JSON.parse(personInDB.responseText);  
        //     //     alert("You have already parked. You have to unpark first!");         
        //     // } catch (error) {
        //     //     proceed = 1;
        //     //     alert(name + "  har blivit varifierad och kan gå vidare och parkera")
        //     //     getStarShipsFromInput();
        //     // }
        // } catch(error){
        //     document.getElementById("errorMessage").innerHTML = inputName + ": " + "Are not allowed to use Spaceport";
        // }
    } 
    
    //if Unpark is pressed
    // else if(i == 2){

    //     //
    //     try{
    //         personData = JSON.parse(personInDB.responseText);   
    //         proceed = 1;        
    //     } catch (error) {
    //         alert(name + "  måste parkera innan du kan checka ut")
    //     }
    // }

}





function park() {

}



// function unpark() {
//     let name = $("#namebox").val();
//     person(name);
// }

// let p = getSpaceship(1).then(result => result);
// p.then(result => console.log(result));

// let pp = getPerson("eric").then(result => result);
// pp.then(result => console.log(result));

// let ppp = getPerson("eric").then(result => result);
// ppp.then(result => console.log(result));

//let ppp = getPerson("kalle").then(result => result);
//ppp.then(result => console.log(result));

//person("eric");

