let Parser = require("../solution.js");
let expect = require("chai").expect;
describe("MyTests", () => {
    it('Tests for the constructor', ()=>{
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        expect(parser.data).to.be.deep.equal([ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ])
        expect(parser._log).to.be.deep.equal(['0: getData']);
        expect(parser._log.length).to.be.equal(1);
        parser.removeEntry("Nancy");
        expect(parser.data.length).to.be.equal(2)

    })
    it('Tests for Print method', ()=>{
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        let actual = parser.print();
        let expected = `id|name|position\n0|Nancy|architect\n1|John|developer\n2|Kate|HR`
        expect(parser._log[0]).to.be.equal('0: print');
        expect(actual).to.be.equal(expected);
        parser.removeEntry('Kate')
        expect(parser.print()).to.be.equal('id|name|position\n0|Nancy|architect\n1|John|developer')
    })
    it('Tests for addEntries  method', ()=>{
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        expect(parser._log).to.be.deep.equal([]);
        expect(parser.addEntries('parser.addEntries("Steven:tech-support Edd:administrator')).to.be.equal('Entries added!')
        expect(parser._log).to.be.deep.equal(['0: addEntries'])
        expect(parser.data.length).to.be.deep.equal(5)
    })
    it('Tests for removeEntries method', ()=>{
        let parser = new Parser('[ {"Nancy":"architect"},{"John":"developer"},{"Kate": "HR"} ]');
        expect(()=>{parser.removeEntry('Niki')}).to.throw(Error)
        let targetPerson = parser.data.find(x=> x.hasOwnProperty('Nancy'));
        expect(targetPerson.hasOwnProperty('deleted')).to.be.false;
        let removedPerson = parser.removeEntry("Kate");
        expect(removedPerson).to.be.equal('Removed correctly!');
    })

});