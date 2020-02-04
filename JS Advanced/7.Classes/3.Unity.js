class Rat{
    #rats;
    constructor(name){
        this.name = name;      
        this.#rats = []; 
    }

    unite(otherRat) {
        if (otherRat.constructor.name== "Rat") {
            this.#rats.push(otherRat);
        }
    }
    getRats(){
        return this.#rats;
    }

    toString(){
        let result = '';
        result+= `${this.name}\n`
        this.#rats.forEach(rat => {
            result+= `##${rat.name}\n`
        });
        return result;
    }
}

let rat1 = new Rat('Koko');
let rat2 = new Rat('Dani');
rat1.unite(rat2);
rat1.unite(new Rat('Peshko'));
console.log(rat1.toString());
