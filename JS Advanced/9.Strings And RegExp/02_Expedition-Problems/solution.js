function solve() {
    let coordinateRegEx = RegExp('(east|north).*?([0-9]{2})[^,]*?[,][^,]*?([0-9]{6})', 'gmi');
    let key = document.querySelector("#string").value;
    let messageNeib = RegExp(`(${key})(?<theMessage>.*?)${key}`, 'gmi')
    let text = document.querySelector("#text").value;

    let theMessage = messageNeib.exec(text)[2];
    let textMatches = coordinateRegEx.exec(text);

    let eastDirection ; 
    let northDirection ;
    
    
    while(textMatches){
        if (textMatches[1].toLowerCase()=== 'east') {
            eastDirection = `${textMatches[2]}.${textMatches[3]} E`;;
        }
        if (textMatches[1].toLowerCase()=== 'north') {
            northDirection = `${textMatches[2]}.${textMatches[3]} N`
        }
        textMatches = coordinateRegEx.exec(text);
    }

    
    document.querySelector("#result").innerHTML = `
    <p>${northDirection}</p>
    <p>${eastDirection}</p>
    <p>Message: ${theMessage}</p>
    `
}