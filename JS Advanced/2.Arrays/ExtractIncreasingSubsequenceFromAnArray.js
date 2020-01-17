function solve(numArr){
let finalArr = numArr.reduce((acc, curr)=>{
        if(curr>=Math.max(...acc)){
            acc.push(curr);
        }
    return acc;
    }, []).forEach(element => {
        console.log(element);      
    });
    
}
solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]);