function solve(){
    class Melon{
        constructor(weight, melonSort){
            if (new.target === Melon) {
                throw new Error('Abstract class cannot be instantiated directly')
            }
            this.weight = weight;
            this.melonSort = melonSort;
            this.element = '';
            
        }
        get elementIndex(){
            return this.weight * this.melonSort.length;
        }
        toString(){
            let result = ``;
            result += `Element: ${this.element}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
            return result;
        }
    }
    class Watermelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.element = 'Water'
        }
    }
    class Firemelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.element = 'Fire'

        }

    }
    class Earthmelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.element = 'Earth'

        }
    }
    class Airmelon extends Melon{
        constructor(weight, melonSort){
            super(weight, melonSort);
            this.element = 'Air'

        }
    }
    class Melolemonmelon extends Watermelon{
        
        constructor(weight, melonSort){
            super(weight,melonSort);
            this.conditions = ['Fire', 'Earth', 'Air','Water'];
        }
        
        get elementIndex(){
            return this.weight * this.melonSort.length;
        }
        morph(){
            let first = this.conditions.shift();
            this.element = first;
            this.conditions.push(first);
        }
    }
    return {Melon, Watermelon, Firemelon, Airmelon, Earthmelon, Melolemonmelon};
};

let a = solve();
let melon = new a.Melolemonmelon(100 ,'Kokich')
console.log(melon.toString());
