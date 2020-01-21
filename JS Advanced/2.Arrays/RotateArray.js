function rotateTheArr(arr){
    let counter = Number(arr.pop());
    for (let index = 1; index <= counter; index++) {
        let currLast = arr.pop();
        arr.unshift(currLast);
    }
    console.log(arr.join(' '));
    
}
rotateTheArr(['Banana',
'Orange',
'Coconut',
'Apple',
'15']);

