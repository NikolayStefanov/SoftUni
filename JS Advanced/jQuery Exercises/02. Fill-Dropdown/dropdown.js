function addItem() {
    var text = $('#newItemText').val();
    var value = $('#newItemValue').val();

    var newOption = $('<option>').text(text).val(value);

    $('#newItemText').val('');
    $('#newItemValue').val('');
    $('#menu').append(newOption);
}