const expect = require('chai').expect;
let lookupChar = require('../CharLookup');

describe('Test is CharLookUp function work correctly', ()=>{
    it('The function should return undefined when first param is not string', ()=>{
        expect(lookupChar(1, 1)).to.be.equal(undefined, 'Function did not returned undefined!')
    })
    it('The function should return undefined when second param is not integer', ()=>{
        expect(lookupChar('Something', 'niki')).to.be.equal(undefined, 'Function did not returned undefined!')
    })
    it('The function should return undefined when second param is not integer', ()=>{
        expect(lookupChar('Something', 3.13)).to.be.equal(undefined, 'Function did not returned undefined!')
    })
    it('The function should return "Incorrect index" if index is equal than length', ()=>{
        expect(lookupChar('Something', 9)).to.be.equal('Incorrect index', 'Function did not returned Incorrect index!')
    })
    it('The function should return "Incorrect index" if index is more  than length', ()=>{
        expect(lookupChar('Something', 10)).to.be.equal('Incorrect index', 'Function did not returned Incorrect index!')
    })
    
    it('The function should return "Incorrect index" if index less than zero', ()=>{
        expect(lookupChar('Something', -1)).to.be.equal('Incorrect index', 'Function did not returned Incorrect index!')
    })
    it('The function should return correct result', ()=>{
        expect(lookupChar('Something', 0)).to.be.equal('S', 'Function did not returned "S"')
    })
    it('The function should return correct result', ()=>{
        expect(lookupChar('Something', 8)).to.be.equal('g', 'Function did not returned "S"')
    })
})