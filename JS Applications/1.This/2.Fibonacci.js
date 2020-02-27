function getFibonator(){
    let prevFib = 0;
    let currFib = 1;
    return function fib(){
        let result = currFib;
        [currFib, prevFib] = [prevFib + currFib, currFib]
        return result;
    }
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8