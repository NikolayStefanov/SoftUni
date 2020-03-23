import { monkeys } from "./monkeys.js";

solve();
async function solve(){
    let response = await fetch("./monkeyHbsTemplate.hbs");
    let monkeyTemplate = await response.text();
    
    let theTemplate = Handlebars.compile(monkeyTemplate);
    
    let theResultHtml = theTemplate({monkeys});
    document.querySelector("body > section > div").innerHTML = theResultHtml;

    let buttons = document.querySelectorAll("body section div button");
    Array.from(buttons).forEach(but=> {
        but.addEventListener('click', showInfo)
    })
}

function showInfo(e){
    let targetP = e.target.nextElementSibling;
    if (targetP.style.display === 'block') {
        targetP.style.display = 'none'
    }else{
    targetP.style.display = 'block';
    }
}