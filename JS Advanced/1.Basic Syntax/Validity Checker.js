

function solve(arr = new Array()){

    
    let x1 = arr[0];
    let y1 = arr[1];
    let x2 = arr[2];
    let y2 = arr[3];

    let func = (a, b, c, d) => Math.sqrt(Math.pow(Math.abs(a - c), 2) + Math.pow(Math.abs(b - d), 2)) % 1 === 0;

    
    console.log(`{${x1}, ${y1}} to {0, 0} is ${func(x1, y1, 0, 0) ? "valid" : "invalid"}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${func(x2, y2, 0, 0) ? "valid" : "invalid"}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${func(x1, y1, x2, y2) ? "valid" : "invalid"}`);
}

solve([2, 1, 1, 1]);