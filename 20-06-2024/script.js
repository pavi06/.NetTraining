const users = [
    { username: 'Pavi', password: 'Pavi@123' },
];

var functionAddValidEffects = (element, attributeName) => {
    element.classList.remove("is-invalid");
    element.classList.add("is-valid");
    document.getElementById(`${attributeName}Valid`).innerHTML="valid input!";
    document.getElementById(`${attributeName}Invalid`).innerHTML="";
    return true;
}

var functionAddInValidEffects = (element, attributeName) => {
    element.classList.remove("is-valid");
    element.classList.add("is-invalid");
    document.getElementById(`${attributeName}Valid`).innerHTML="";
    document.getElementById(`${attributeName}Invalid`).innerHTML=`Please provide the valid ${attributeName}!`;
    return true;
}

var validateName = () =>{
    var element = document.loginForm.name;
    var regString = /[a-zA-Z]/g
    if(element.value && element.value.match(regString)){
        return functionAddValidEffects(element, 'name');
    }
    else{
        return functionAddInValidEffects(element, 'name');
    }
}

var validatePassword = () => {
    var regexExpression = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[@$&*_])(?=.*[0-9]).{6,}$/;
    var element = document.loginForm.password;
    if(element.value && element.value.match(regexExpression)){
        return functionAddValidEffects(element, 'password');
    }
    else{
        return functionAddInValidEffects(element, 'password');
    }
}

function validateLogin(username, password) {
    console.log(username)
    console.log(password)
    console.log(users.some(user => user.username === username && user.password === password));
    return users.some(user => user.username === username && user.password === password);
}

var validateAndLogin = () => {
    var res1 = validateName();
    var res2 = validatePassword();
    console.log(res1)
    console.log(res2)
    if( res1 && res2 && validateLogin(document.getElementById('name').value, document.getElementById('password').value)){
        document.getElementById('result').innerHTML="Login successfull!"
    }
    else{
        document.getElementById('result').innerHTML="Oops something went wrong! Invalid Username or Password!"
    }
}

// document.getElementById('btn').addEventListener('click',()=>{
//     validateAndLogin();
// });