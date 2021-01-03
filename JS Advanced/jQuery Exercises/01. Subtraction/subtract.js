$(()=> $('#substractButton').on('click', subtract));

function subtract() {
    let firstNum = parseFloat($('#firstNumber').val());
    let secondNum = parseFloat($('#secondNumber').val());
    
    var result = firstNum - secondNum;
    $('#result').text(result.toFixed(2));
}