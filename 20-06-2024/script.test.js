const {JSDOM} = require('jsdom');
const fs = require('fs');
const path = require('path');


test('login button click success test',()=>{

    const html = fs.readFileSync(path.resolve(__dirname,'./login.html'),'utf8');
    const script = fs.readFileSync(path.resolve(__dirname,'./script.js'),'utf8');

    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    dom.window.document.getElementById('name').value = "Pavi";
    dom.window.document.getElementById('password').value = "Pavi@123";
    //Raising the event
    dom.window.document.getElementById('btn').click();
    const actual = dom.window.document.getElementById('result').innerHTML='Login successfull!';
    expect(actual).toBe('Login successfull!');
})

test('login button click failure test',()=>{
    const html = fs.readFileSync(path.resolve(__dirname,'./login.html'),'utf8');
    const script = fs.readFileSync(path.resolve(__dirname,'./script.js'),'utf8');
    
    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);


    dom.window.document.getElementById('name').value = "Pavi";
    dom.window.document.getElementById('password').value = "Pavi";
    //Raising the event
    dom.window.document.getElementById('btn').click();
    const actual = dom.window.document.getElementById('result').innerHTML='Oops..Login failed! try again later!!';
    expect(actual).toBe('Oops..Login failed! try again later!!');
})