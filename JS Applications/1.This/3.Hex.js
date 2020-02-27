class Hex{
    constructor(value){
        this.value = value;
    }
    valueOf(){
        return this.value;
    }
    toString(){
        return '0x'+ this.value.toString(16).toUpperCase();
    }
    plus(number){
        let newHex;
        if (typeof(number)=== 'number') {
            newHex = new Hex(number+this.value);
        }
        else{
            newHex = new Hex(number.value + this.value);
        }
        return newHex;
    }
    minus(number){
        let newHex;
        if (typeof(number)=== 'number') {
            newHex = new Hex(number+this.value);
        }else{
            newHex = new Hex(this.value-number.value);
        }
        return newHex;
    }
    parse(string){
        let parsedNum = parseInt(string, 16);
        return parsedNum
    }

}
let FF = new Hex(255);
console.log(FF.toString());
let temp = FF.valueOf() + 1
console.log(temp == 256);
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');