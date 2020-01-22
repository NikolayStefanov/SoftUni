function solve(arr) {
    let sortedArr = arr.sort((a, b) => a.localeCompare(b));
    let elementsInObj = [];
    for (const el of sortedArr) {
        let args = el.split(' : ');
        let product = args[0];
        let price = +args[1];
        let currObj = {
            name: product,
            price: price,
        };
        elementsInObj.push(currObj)
    }
    let data = elementsInObj.reduce((r, e) => {
        // get first letter of name of current element
        let group = e.name[0];
        // if there is no property in accumulator with this letter create it
        if (!r[group]) r[group] = {
            children: [e]
        }
        // if there is push current element to children array for that letter
        else r[group].children.push(e);
        return r;
    }, {})

    for (const key in data) {
        console.log(key);
        let finalArr = data[key].children;
        for (const element of finalArr) {
            console.log(`  ${element.name}: ${element.price}`);
        }
    }
}
solve(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10'
]);