function toggle(event) {
    var targetElement = $(event.target);
    if(targetElement.text()== 'More'){
        targetElement.text('Less');
        $('#extra').show();
    }else{
        targetElement.text('More')
        $('#extra').hide();
    }
}