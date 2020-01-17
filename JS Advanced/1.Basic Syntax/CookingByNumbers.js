function cookingOperation(arr){
    let theNum = parseInt(arr[0]);
    arr.shift();
    for (const element of arr) {
        switch (element) {
            case 'chop':
                theNum /= 2;
                break;
            case 'dice':
                theNum = Math.sqrt(theNum);
                break;
            case 'spice':
                theNum += 1;
                break;
            case 'bake':
                theNum *= 3;
                break;
            case 'fillet':
                theNum *= 0.80;
                break;
        }
        console.log(theNum);
        
    }
}
cookingOperation(['32', 'chop', 'chop', 'chop', 'chop',
    'chop']);