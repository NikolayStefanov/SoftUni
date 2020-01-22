function arraySequence(jsonArr){
    let uniqueArrays = [];
    let stringArr = [];
    let parsedJsonArr = jsonArr.map(x=> JSON.parse(x)).map(arr=> arr.sort((a,b)=> b-a));

    for (const arr of parsedJsonArr) {
        let stringifyArr = JSON.stringify(arr);
        stringArr.push(stringifyArr);
    }
    
    let uniqueStringArrs = [...new Set(stringArr)];    
    for (const strArr of uniqueStringArrs) {
        uniqueArrays.push(JSON.parse(strArr));
    }

    uniqueArrays.sort((a,b)=> a.length-b.length);
    for (const arr of uniqueArrays) {
        console.log(`[${arr.join(', ')}]`);     
    }
}
arraySequence(['[-3, -2, -1, 0, 1, 2, 3, 4]',
    '[10, 1, -17, 0, 2, 13]',
    '[4, -3, 3, -2, 2, -1, 1, 0]']);