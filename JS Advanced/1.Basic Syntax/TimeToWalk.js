function walkingTime(steps, studentFootprint, speed){
    let totalRests = Math.floor((steps * studentFootprint)/500);
    let distance = steps * studentFootprint;
    let meterInHourSpeed = speed / 0.28;
    let time = distance/speed/1000*60;
    let totalTimeInSeconds = Math.ceil((totalRests + time) *60);
    let result = new Date(null, null, null, null, null, totalTimeInSeconds);


    console.log(result.toTimeString().split(' ')[0]);
//T = разстоянието/ скоростта
}
walkingTime(4000, 0.60, 5);