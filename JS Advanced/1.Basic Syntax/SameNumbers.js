function allNumbersAreSame(number) {
    let numberAsString = number.toString();
    let finalResult = 0;
    let areSame = true;
    for (let index = 0; index < numberAsString.length - 1; index++) {
        if (numberAsString[index] != numberAsString[index + 1]) {
            areSame = false;
        }
    }
    console.log(areSame);
    for (let index = 0; index < numberAsString.length; index++) {
        let currChar = numberAsString[index];
        let currNumber = parseInt(currChar);
        finalResult += currNumber;
    }
    console.log(finalResult);
}
allNumbersAreSame(22222);