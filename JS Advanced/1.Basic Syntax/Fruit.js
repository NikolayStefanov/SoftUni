function myFunc(fruit, weight, pricePerKg) {
    let kilograms = weight / 1000;
    let finalPrice = kilograms * pricePerKg;

    console.log(`I need $${finalPrice.toFixed(2)} to buy ${kilograms.toFixed(2)} kilograms ${fruit}.`);
}
myFunc('apple', 3653, 1.56);