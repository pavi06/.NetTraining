var validateLocation = () =>{
    var location = document.getElementById("location").value;
    if(location && location.match('/[a-zA-Z]/g')){
        element.classList.remove("is-invalid");
        element.classList.add("is-valid");
        document.getElementById("locationValid").innerHTML="valid input!";
        document.getElementById("locationInvalid").innerHTML="";
        return true;
    }
    else{
        element.classList.remove("is-valid");
        element.classList.add("is-invalid");
        document.getElementById("locationValid").innerHTML="";
        document.getElementById("locationInvalid").innerHTML="Please provide the valid location!";
        return false;
    }
}

var validateDate = () =>{
    var date = document.getElementById("checkInDate").value;
    if(date && date>= new Date().getFullYear()){
        date.classList.remove("is-invalid");
        date.classList.add("is-valid");
        document.getElementById("checkInDateValid").innerHTML="valid input!";
        document.getElementById("checkInDateInvalid").innerHTML="";
        return true;
    }
    else{
        date.classList.remove("is-valid");
        date.classList.add("is-invalid");
        document.getElementById("checkInDateValid").innerHTML="";
        document.getElementById("checkInDateInvalid").innerHTML="Please provide the valid date!";
        return false;
    }
}

var validateAndGet = () => {
    if(validateLocation() && validateDate()){
        // fetch(){

        // }
    }
}