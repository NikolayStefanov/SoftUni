async function makeCats(){
    let response = await fetch('./catPartialTemplate.hbs');
    let data = await response.text();
    
    Handlebars.registerPartial('cat', data)
    
    let allCatsTemplate = await fetch('./catTemplate.hbs').then((r)=> r.text());

    let template = Handlebars.compile(allCatsTemplate);
    let resultHtml = template({cats})
    document.querySelector("#allCats").innerHTML = resultHtml;

    let buttons = Array.from(document.querySelectorAll(".showBtn"))
    buttons.forEach((btn)=> btn.addEventListener('click', changeButton))
}
function changeButton(e){
    let hidedDiv = e.target.nextElementSibling;
    let buttonText = e.target.textContent;
    if (buttonText === 'Show status code') {
        hidedDiv.style.display = 'block';
        e.target.textContent = 'Hide status code'

    }else{
        hidedDiv.style.display = 'none';
        e.target.textContent = 'Show status code'

    }
}
makeCats();