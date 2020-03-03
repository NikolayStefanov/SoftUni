function solve(carObj){
    let carFactory = {
        model: carObj.model,
    }
    const smallEngine = { power: 90, volume: 1800 }
    const normalEngine = { power: 120, volume: 2400 }
    const monsterEngine= { power: 200, volume: 3500 }
    
    const hatchback = { type: 'hatchback', color: carObj.color }
    const coupe = { type: 'coupe', color: carObj.color }

    let wheelsize = carObj.wheelsize;
    if (wheelsize % 2 === 0) {
        wheelsize--;
    }

    if (carObj.power <= 90) {
        carFactory.engine = smallEngine;
    }else if(carObj.power <= 120){
        carFactory.engine = normalEngine;
    }else{
        carFactory.engine = monsterEngine;
    }

    if (carObj.carriage === 'hatchback') {
        carFactory.carriage = hatchback;
    }else{
        carFactory.carriage = coupe;
    }

    carFactory.wheels = [wheelsize,wheelsize,wheelsize,wheelsize]

    return carFactory;
}
console.log(solve({model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17}));
