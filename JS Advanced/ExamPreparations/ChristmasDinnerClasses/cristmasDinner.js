class ChristmasDinner{
    budget;
    constructor(budget){
        this.budgetS = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }
    get budgetG(){
        return this.budget;
    }
    set budgetS(num){
        if (num < 0) {
            throw new Error('The budget cannot be a negative number');
        }
        this.budget = num;
    }
    shopping(product){
        let [productName, productPrice] = product;
        if (!this.isBudgetEnough(+productPrice)) {
            throw new Error('Not enough money to buy this product');
        }
        this.products.push(productName);
        this.budget -= +productPrice;
        return  `You have successfully bought ${productName}!`
    }
    recipes(recipe){
        let recipeName = recipe['recipeName'];
        let neededProducts = recipe['productsList'];
        for (const prod of neededProducts) {
            if (!this.products.includes(prod)) {
                throw new Error('We do not have this product')
            }
        }
        this.dishes.push({'recipeName': recipeName, 'productsList': neededProducts})
        return `${recipeName} has been successfully cooked!`;
    }
    inviteGuests(name, dish){
        if (this.dishes.every(x=> x.recipeName !== dish)) {
            throw new Error('We do not have this dish');
        }
        if (Object.keys(this.guests).some(x=> x === name)) {
            throw new Error('This guest has already been invited')
        }
        this.guests[name] = dish;
        return `You have successfully invited ${name}!`

    }
    showAttendance(){
        let result = '';
        for (const guest in this.guests) {
          let targetFood = this.dishes.find(x=> x.recipeName === this.guests[guest])  
          result += `${guest} will eat ${this.guests[guest]}, which consists of ${targetFood.productsList.join(', ')}\n`;
        }
        return result.trim();
    }

    isBudgetEnough(price){
        return this.budgetG >= price; 
    }
}
let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());





