function radarAction(arr){
    let roadRulz = {
        motorway : 130,
        interstate : 90,
        city : 50,
        residential : 20
    };
    let key = arr[1];
    let speed = arr[0];
    let substract = speed - roadRulz[key];
    if(substract>0 && substract <= 20){
        console.log('speeding');
    }
    else if(substract > 20 && substract <= 40){
        console.log('excessive speeding');        
    }
    else if(substract > 40){
        console.log('reckless driving');
        
    } 
}
radarAction([170, 'motorway']);