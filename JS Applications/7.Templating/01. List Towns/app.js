let elements = {
    loadButton: document.querySelector("#btnLoadTowns"),
    resultDiv: document.querySelector("#root"),
    inputText: document.querySelector("#towns"),

}

function solve() {

    elements.loadButton.addEventListener('click', (e) => {
        e.preventDefault();
        let inputText = elements.inputText.value;
        elements.inputText.value = '';
        let cities = inputText.split(', ').filter(x=> x!== '');

        applyCitiesTemplate(cities);

    })


}
async function applyCitiesTemplate(cities) {

    try {
        let response = await fetch('./template.hbs');
        let data = await response.text();
        if (cities.length > 0) {
            let template = Handlebars.compile(data);
            let resultHtml = template({cities});
            elements.resultDiv.innerHTML = resultHtml;
        }else{
            elements.resultDiv.innerHTML = '';
        }

    } catch (error) {
        console.error(error);
    }

}
solve();