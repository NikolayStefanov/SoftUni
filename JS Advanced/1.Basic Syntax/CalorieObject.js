function calorieObject(arr){
let obj = {};
for (let index = 0; index < arr.length; index+=2) {
    obj[arr[index]] = parseInt(arr[index+1]);
}
console.log(obj);
}
calorieObject(['Potato', '93', 'Skyr', '63',
'Cucumber', '18', 'Milk', '42'])