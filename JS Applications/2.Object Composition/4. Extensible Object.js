function solution(){
    let myObj ={
        extend: function(template){
            Object.keys(template).forEach((key)=>{
                if (typeof template[key] === 'function') {
                    Object.getPrototypeOf(this)[key] = template[key];
                }else{
                    myObj[key] = template[key]; 
                }
            })
        }
    } 
    myObj.extend({
        someProp1: '11111111111111111',
        someProp2: '222222222222222222',
        func1: function(){
            console.log('FUNCFUNCFUNC');;
        }
    });

    return myObj;

}
let obj = solution();
console.log(obj);
