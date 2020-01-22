function solve(juices){
    let juiceObj = {};
    let bottleOrder = [];

    for (const element of juices) {
        let elementArgs = element.split(' => ')
        let fruit = elementArgs[0];
        let quantity = +elementArgs[1];
        if (juiceObj.hasOwnProperty(fruit)) {
            juiceObj[fruit] += quantity;
        }else{
            juiceObj[fruit] = quantity;
        }
        let chekTheQuantity = Math.floor(juiceObj[fruit] / 1000);
        if (chekTheQuantity > 0) {
            bottleOrder.push(fruit);
        }
    }

    let uniqueElements = [...new Set(bottleOrder)];
    let finalArr = [];
    for (const fruit of uniqueElements) {
        let chekTheQuantity = Math.floor(juiceObj[fruit] / 1000);
        finalArr.push(`${fruit} => ${chekTheQuantity}`);
    }

    finalArr.forEach(x=> console.log(x));
    
}
solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']);