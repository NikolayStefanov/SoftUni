function GreatestDivisor(number1, number2){
let greatestDivisor;
if (number1 >= number2) {
    for (let index = number2; index >= 0; index--) {
        if (number1%index == 0 && number2%index == 0) {
            greatestDivisor = index;
            break;
        }
    }
}
else{
    for (let index = number1; index >= 0; index--) {
        if (number1%index == 0 && number2%index == 0) {
            greatestDivisor = index;
            break;
        }
    }
}
console.log(greatestDivisor);
}
GreatestDivisor(1534, 175);