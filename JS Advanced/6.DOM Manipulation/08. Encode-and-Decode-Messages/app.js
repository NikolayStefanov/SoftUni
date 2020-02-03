function encodeAndDecodeMessages() {
    let firstButton = document.querySelectorAll("button");
    firstButton[0].addEventListener('click', sendHandler);
    firstButton[1].addEventListener('click', reveiveHandler);
    function sendHandler(e){
        let textboxes = document.querySelectorAll("textarea");
        let input = textboxes[0].value;
        let encodedText = '';
        for (let index = 0; index < input.length; index++) {
            let currNumber = input.charCodeAt(index)
            encodedText += String.fromCharCode(currNumber+1);
        }
        document.querySelectorAll("textarea")[0].value = '';
        document.querySelectorAll("textarea")[1].value = encodedText;    
    }
    function reveiveHandler(e){
        let currText =  document.querySelectorAll("textarea")[1].value;
        decodedText = '';
        for (let index = 0; index < currText.length; index++) {
            let currNumber = currText.charCodeAt(index);
            decodedText+= String.fromCharCode(currNumber-1);
        }
        document.querySelectorAll("textarea")[1].value = decodedText;
    }
}