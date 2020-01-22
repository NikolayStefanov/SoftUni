function carProducing(arr) {

    let result = arr.reduce((acc, curr, index, array) => {
        let [brand, model, producedCars] = curr.split('|').map(x => x.trim());
        if (!acc[brand]) {
            acc[brand] = {
                [model]: +producedCars
            };
        } else {
            if (!acc[brand].hasOwnProperty(model)) {
                acc[brand][model] = +producedCars;
            } else {
                acc[brand][model] += +producedCars;
            }
        }
        return acc;
    }, {})

    for (const key in result) {
        console.log(key);
        for (const innerKey in result[key]) {
            console.log(`###${innerKey} -> ${result[key][innerKey]}`);
        }
    }

}


carProducing(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
]);