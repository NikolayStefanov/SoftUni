(function solve(){
    String.prototype.ensureStart= function(str){
        let result = this.toString();
        let resultBeginning = result.substring(0, str.length);
        if (resultBeginning !== str) {
            result = `${str}${this}`;
            return result;
        }
        return result;
    };
    String.prototype.ensureEnd = function(str){
        let result = this.toString();
        let resultEnd  = result.substring(result.length- str.length)
        if (resultEnd !== str) {
            result = `${this}${str}`;
            return result;
        }
        return this.toString();
    }
    String.prototype.isEmpty = function(){
        let result = false;
        if (this.length === 0) {
            result = true;
        }
        return result;
    };
    String.prototype.truncate = function(n){
        if (this.length <= n) {
            return this.toString();
        }else if(this.includes('...') && this.length-3 < n){
            return '.'.repeat(n);
        }
        else if(this.length > n){
           let lastSpaceIndex = this.indexOf(" ", n-3);
           if (lastSpaceIndex+3 > n) {
               let counter = 4;
               while(lastSpaceIndex+3> n){
                lastSpaceIndex = this.indexOf(' ', n-counter)
                counter++;
               }
           }
           let slicedPart = this.slice(0, lastSpaceIndex);

           if (lastSpaceIndex > -1) {
               if (n+3 >= slicedPart.length) {
                   return slicedPart+ '...'
               }
           }else{
               return slicedPart.slice(0, n-3)+ '...'
           }
        }
    }
    String.format = function(text, params){
        let inputText = arguments[0];
        let parameters = Array.from(arguments).slice(1)
        const myRegExp = new RegExp('{([0-9])}', 'gmi')
        let match = myRegExp.exec(inputText);
        let matchesArr = [];
        while(match){
            matchesArr.push(match[0]);
            match = myRegExp.exec(inputText);
        }
        for (let index = 0; index < parameters.length; index++) {
            if (!parameters[index] || !matchesArr[index]) {
                break;
            }else{
                inputText = inputText.replace(matchesArr[index], parameters[index])
            }
        }
        return inputText ;  
    }
}())

var testString = 'the quick brown fox jumps over the lazy dog';
console.log(testString.truncate(6));
console.log(testString.truncate(10));
testString = String.format('The {0} {1} {2}fox','quick', 'brown', 'fuckin', 'dsabdas');
console.log(testString);

