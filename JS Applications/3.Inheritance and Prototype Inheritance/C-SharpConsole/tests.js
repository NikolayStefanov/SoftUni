let expect = require('chai').expect;
const console = require('./5.C-Sharp Console');

describe('Tests for C-Sharp Console Class', ()=>{
    it('Test with string', ()=>{
        expect(console.writeLine('Nikolay')).to.be.equal('Nikolay')
    })
    it('Test for object', ()=>{
        let obj = {
            name: 'Nikolay',
            age: 22,
            power: 'infinity'
        }
        expect(console.writeLine(obj)).to.be.equal('{"name":"Nikolay","age":22,"power":"infinity"}');
    })
    it('Error if arguments are not string', ()=>{
        expect(()=>{console.writeLine(123,{})}).to.throw(TypeError)

    })
    it('Range Error if params > from placeholders', ()=>{
        expect(()=>{console.writeLine('Az {0} sum {1}', 'ne', 'nikolay', 'be')}).to.throw(RangeError)
    })
    it('Range error if number in placeholders are incorect', ()=>{
        expect(()=>{console.writeLine('Az {0} sum {2}', 'ne', 'nikolay')}).to.throw(RangeError)
    })
    it('Should work correctly', ()=>{
        expect(console.writeLine('Az {0} sum {1}', 'ne', 'nikolay')).to.be.equal('Az ne sum nikolay')
    })
})