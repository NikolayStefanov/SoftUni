(function solve(){
    Array.prototype.last = function(){
        return this[this.length-1];
    }
    Array.prototype.skip = function(n){
        let newArr = this.slice(n);
        return newArr;
    }
    Array.prototype.take = function(n){
        let newArr = this.slice(0, n);
        return newArr;
    }
    Array.prototype.sum = function(){
        let resultSum = this.reduce((acc,curr)=> acc + curr, 0)
        return resultSum;
    }
    Array.prototype.average = function(){
        let averageResult = this.sum()/ this.length;
        return averageResult;
    }
}())
let arr = [1,2,3,4,5,6,7,8,9];
console.log(arr.last());
console.log(arr.skip(3));
console.log(arr.take(5));
console.log(arr.sum());
console.log(arr.average());




