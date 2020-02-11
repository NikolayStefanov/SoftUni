const expect = require('chai').expect;
let mathEnforcer = require('../MathEnforcer');

describe('Check if mathEnforcer works correctly.', ()=> {
    it('AddFive method should return undefined if parameter is not number.', ()=>{
        let actualResult = mathEnforcer.addFive('gosho');
        expect(actualResult).to.be.equal(undefined, 'Returned value is not undefined!')
    });
    it('SubstractTen method should return undefined if parameter is not number.', ()=>{
        let actualResult = mathEnforcer.subtractTen('gosho');
        expect(actualResult).to.be.equal(undefined, 'Returned value is not undefined!')
    });
    it('SUM method should return undefined if parameter is not number.', ()=>{
        let actualResult = mathEnforcer.sum('gosho', 1);
        expect(actualResult).to.be.equal(undefined, 'Returned value is not undefined!')
    });
    it('SUM method should return undefined if parameter is not number.', ()=>{
        let actualResult = mathEnforcer.sum(1, '1');
        expect(actualResult).to.be.equal(undefined, 'Returned value is not undefined!')
    });

    it('AddFive method should work correctly!', ()=>{
        let actualResult = mathEnforcer.addFive(1);
        expect(actualResult).to.be.equal(6, 'Returned value is not 6!')
    });
    it('AddFive method should work correctly!', ()=>{
        let actualResult = mathEnforcer.addFive(1.9);
        expect(actualResult).to.be.closeTo(6.9, 0.01 ,'Returned value is not 6.9!')
    });
    it('SubstractTen method should works correct', ()=>{
        let actualResult = mathEnforcer.subtractTen(6);
        expect(actualResult).to.be.equal(-4, 'Returned value is not -4')
    });
    it('SubstractTen method should works correct', ()=>{
        let actualResult = mathEnforcer.subtractTen(6.25);
        expect(actualResult).to.be.closeTo(-3.75, 0.01, 'Returned value is not -3.75')
    });
    it('SubstractTen method should works correct', ()=>{
        let actualResult = mathEnforcer.subtractTen(10);
        expect(actualResult).to.be.equal(0, 'Returned value is not 0')
    });
    it('SUM method should works correct', ()=>{
        let actualResult = mathEnforcer.sum(1, 1);
        expect(actualResult).to.be.equal(2, 'Returned value is not 2')
    });
    it('SUM method should works correct', ()=>{
        let actualResult = mathEnforcer.sum(-15, -10);
        expect(actualResult).to.be.equal(-25, 'Returned value is not -25')
    });
    it('SUM method should works correct', ()=>{
        let actualResult = mathEnforcer.sum(15, 10);
        expect(actualResult).to.be.equal(25, 'Returned value is not 2')
    });
    it('SUM method should works correct', ()=>{
        let actualResult = mathEnforcer.sum(5.5, 4.2);
        expect(actualResult).to.be.closeTo(9.7, 0.01, 'Result is INCORRECT.')
    });
});