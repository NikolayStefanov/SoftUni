const isOddOrEven = require('../EvenOrOdd');
let expect = require('chai').expect;

describe('test is the result is even, odd or undefined', ()=>{
    it('The function should return undefined', ()=>{
        let expected = undefined;
        let actualResult = isOddOrEven(1);
        expect(actualResult).to.be.equal(expected, 'The function doesnt return UNDEFINED!')
    })
    it('The function should return even', ()=> {
        let expected = 'even';
        let actualResult = isOddOrEven('Nikola');
        expect(actualResult).to.be.equal(expected, 'The function doesnt return EVEN!')
    })
    it('The function should return odd', ()=>{
        let expected = 'odd';
        let actualResult = isOddOrEven('Nikolay');
        expect(actualResult).to.be.equal(expected, 'The function doesnt return ODD!')
    })
});