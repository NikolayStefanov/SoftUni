const expect = require('chai').expect;
let StringBuilder = require('../StringBuilder');

describe('Check functionallity of StringBuilder class.', ()=>{
    it('should have the correct function properties',  ()=> {
        expect(StringBuilder.prototype.append).to.be.a('function')
        expect(StringBuilder.prototype.prepend).to.be.a('function')
        expect(StringBuilder.prototype.insertAt).to.be.a('function')
        expect(StringBuilder.prototype.remove).to.be.a('function')
        expect(StringBuilder.prototype.toString).to.be.a('function')
    });
    it('Check that StringBuilder should throws error', ()=>{
        expect(()=>{new StringBuilder(1)}).to.throw(TypeError);
    })
    it('The _stringArray must be correct save', ()=>{
        let inst = new StringBuilder('Koko');
        expect(inst._stringArray).deep.equal(['K', 'o','k','o']);
        let secInst = new StringBuilder();
        expect(secInst._stringArray).to.deep.equal([]);     
    })
    it('The append method should work correctly or throw error', ()=>{
        let inst = new StringBuilder('Koko');
        expect(()=>{inst.append(1)}).to.throw(TypeError);
        expect(inst.append('GT')).to.deep.equal(undefined);
        expect(inst._stringArray).to.deep.equal(['K', 'o','k','o','G','T'])
    })
    it('The prepend method should work correctly or throw error', ()=>{
        let inst = new StringBuilder('Koko');
        expect(()=>{inst.prepend(1)}).to.throw(TypeError);
        expect(inst.prepend('GT')).to.deep.equal(undefined);
        expect(inst._stringArray).to.deep.equal(['G', 'T','K', 'o','k','o'])
    })
    it('The insert at method should throw error', ()=>{
        let inst = new StringBuilder('Koko');
        expect(()=>{inst.insertAt(1)}).to.throw(TypeError);
    })
    it('The insert at method should insert correctly', ()=>{       
        let inst = new StringBuilder('Koko');
        expect(inst.insertAt('GT', 2)).to.equal(undefined);
        expect(inst._stringArray).to.be.deep.equal(['K','o','G','T','k','o']);
        inst.insertAt('GGG', 6);
        expect(inst._stringArray).to.be.deep.equal(['K','o','G','T','k','o','G','G','G']);
    })
    it('The remove method should remove correctly', ()=>{
        let inst = new StringBuilder('Koko');
        expect(inst.remove(1,1)).to.be.equal(undefined);
        expect(inst._stringArray).to.be.deep.equal(['K','k','o']);
        inst.remove(1,5);
        expect(inst._stringArray).to.be.deep.equal(['K']);
    })
    it('toString method should work correctly', ()=> {
        let inst = new StringBuilder('Koko');
        expect(inst.toString()).to.be.equal('Koko');
        inst.append('GTT');
        inst.prepend('TDI');
        expect(inst.toString()).to.be.equal('TDIKokoGTT');
    })
})