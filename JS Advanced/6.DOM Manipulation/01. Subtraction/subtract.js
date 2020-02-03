function subtract() {
    let firstNum = +(document.querySelector("#firstNumber").value);
    let secondNum = +(document.querySelector("#secondNumber").value);
    let result = firstNum-secondNum;
    document.querySelector("#result").textContent = result;
}