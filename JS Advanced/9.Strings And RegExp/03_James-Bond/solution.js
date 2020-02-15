function solve() {
    let [key, ...fullText] = JSON.parse(document.querySelector("#array").value);
    const regEx = RegExp(`(^| )${key}[ ]+([A-Z#$%!]{8,})([ \.,]|$)`, 'gmi');
    let matchArray = [];

    for (const text of fullText) {
    let match = regEx.exec(text);

    while(match){
        matchArray.push(match[2])
        match = regEx.exec(text);
    }
    
    let finalText = text;
    let wordReg = RegExp('([A-Z|#$%!]{8,})')
    for (const word of matchArray) {
        if (wordReg.test(word)) {
            let newWord = word.replace(/!/g, '1').replace(/%/g, '2').replace(/#/g, '3').replace(/\$/g, '4').toLowerCase();
            finalText = finalText.replace(word, newWord);
        }
    }
    
    document.querySelector("#result").innerHTML += `<p>${finalText}</p>`
}
}
