class Stringer{
    innerString;
    innerLength;
    firstStr ='';
    constructor(firstStr, initialLength){
        this.innerString = firstStr;
        this.innerLength = initialLength;
        this.firstStr = firstStr;
    }

    increase(length){
        this.innerLength += length;
        
    }
    decrease(length){
        if (this.innerLength-length < 0) {
            this.innerLength = 0;
        }else{
            this.innerLength -= length;
        }  
    }
    toString(){
        return this.innerLength >= this.innerString.length ? `${this.innerString}` : `${this.innerString.slice(0, this.innerLength)}...`;
    }
}
let demo = new Stringer("Test", 5);
console.log(demo.toString());
demo.increase(15);
console.log(demo.toString());





