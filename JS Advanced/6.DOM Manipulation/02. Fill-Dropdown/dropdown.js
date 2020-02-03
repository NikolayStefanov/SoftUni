function addItem() {
    document.querySelector("body > article > input[type=button]:nth-child(6)").onclick = addItem();

    function addItem(e) {
        let text = document.querySelector("#newItemText").value;
        let value = document.querySelector("#newItemValue").value;

        let selectMenu = document.querySelector("#menu");
        let newOption = document.createElement('option');
        newOption.value = value;
        newOption.textContent = text;
        selectMenu.appendChild(newOption);

        document.querySelector("#newItemText").value = '';
        document.querySelector("#newItemValue").value = '';
    }
}