function solve() {
    let toLabel = document.querySelector("#selectMenuTo");
    let firstElement = document.querySelector("#selectMenuTo > option:nth-child(1)");
    let hexadecimal = document.createElement("option");
    let binary = document.createElement("option");

    binary.innerText = "Binary";
    binary.value = 'binary';
    hexadecimal.innerText = 'Hexadecimal';
    hexadecimal.value = 'hexadecimal';

    toLabel.appendChild(binary);
    toLabel.appendChild(hexadecimal);

    let buttonConvert = document.querySelector("#container > button");

    function convert() {
        let numberValue = +(document.getElementById('input').value);

        if (toLabel.value == "hexadecimal") {
            let hexadecimalResult = numberValue.toString(16);
            if (typeof(hexadecimalResult) === 'string') {
                hexadecimalResult = hexadecimalResult.toUpperCase();
            }
            let resultElement = document.querySelector("#result");
            resultElement.value = hexadecimalResult;
        } else {
            let binary = +(numberValue).toString(2);
            let resultElement = document.querySelector("#result");
            resultElement.value = binary;
        }

    }
    buttonConvert.addEventListener("click", convert);
}