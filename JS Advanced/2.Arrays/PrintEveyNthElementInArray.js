function printNthElement(arr){
const nthStep = +arr.pop();
for (let index = 0; index < arr.length; index+= nthStep) {
    console.log(arr[index]);
}
}
printNthElement(['dsa',
    'asd',
    'test',
    'tset',
    '2']);