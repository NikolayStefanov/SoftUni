function attachEventsListeners() {
    var targetButtons = $('div>input[value=Convert]');
    targetButtons.each(element=>{
        targetButtons[element].addEventListener('click', convertTime);
    })
}
function convertTime(){
    switch($(this).attr('id')) {
        case 'daysBtn':
            var inputDays = $(this).prev().val();
            fromDays(inputDays);
          break;
        case 'hoursBtn':
            var inputHours = $(this).prev().val();
            fromHours(inputHours)
          break;
        case 'minutesBtn':
            var inputMinutes = $(this).prev().val();
            fromMinutes(inputMinutes)
          break;
        default:
            var inputSeconds = $(this).prev().val();
            fromSeconds(inputSeconds)
      }
}

function fromDays(inputDays){
    var hours = inputDays * 24;
    $('#hours').val(hours);

    var minutes =  inputDays * 24 * 60;
    $('#minutes').val(minutes);

    var seconds = inputDays * 24 * 60 * 60;
    $('#seconds').val(seconds);
}
function fromHours(inputHours){
    var days = inputHours / 24;
    $('#days').val(days);

    var minutes = inputHours * 60;
    $('#minutes').val(minutes);

    var seconds = inputHours * 60 * 60;
    $('#seconds').val(seconds);
}
function fromMinutes(inputMinutes){
    var days = inputMinutes / 60 / 24;
    $('#days').val(days);

    var hours = inputMinutes / 60;
    $('#hours').val(hours);

    var seconds = inputMinutes * 60;
    $('#seconds').val(seconds);
}
function fromSeconds(inputSeconds){
    var days = inputSeconds / 60 / 60 / 24;
    $('#days').val(days);

    var hours = inputSeconds / 60 / 60;
    $('#hours').val(hours);

    var minutes = inputSeconds / 60;
    $('#minutes').val(minutes);
}