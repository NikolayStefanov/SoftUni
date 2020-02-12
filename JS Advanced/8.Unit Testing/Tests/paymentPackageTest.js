const expect = require('chai').expect;
const should = require('chai').should();

const PaymentPackage = require('../PaymentPackage');

describe('Test the paymentPackage to work correctly', () => {
    it("test constructor with 0 or 1 parameter - throw exception", () => {
        const payment = () => {
            new PaymentPackage("HR Services")
        };
        expect(payment).to.throw(Error);
        expect(()=>{new PaymentPackage()}).to.throw(Error);
    });
    it("test constructor with wrong parameters - throw exception", () => {
        expect(()=>{new PaymentPackage(0,0)}).to.throw(Error);
        expect(()=>{new PaymentPackage('',0)}).to.throw(Error);
        expect(()=>{new PaymentPackage('HR Services','0')}).to.throw(Error);
        expect(()=>{new PaymentPackage('HR Services', -1)}).to.throw(Error);

    });
    it('Test for constructor to set values correctly', () => {
        const payment = new PaymentPackage('HR Services', 1500)

        expect(payment.name).to.be.equal('HR Services')
        expect(payment.value).to.be.equal(1500);
    })
    it('Test for default values', () => {
        const payment = new PaymentPackage('HR Services', 1500)
        expect(payment.VAT).to.be.equal(20);
        expect(payment.active).to.be.true;
    })
    it('Test name setter', ()=>{
        const payment = new PaymentPackage('HR Services', 1500)
        expect(()=>{payment.name = 0}).to.throw(Error);
        expect(()=>{payment.name = ''}).to.throw(Error);
        expect(payment.name).to.be.equal('HR Services');
        payment.name = 'SomethingNew';
        expect(payment.name).to.be.equal('SomethingNew');
    })
    it('Test value setter', ()=>{
        const payment = new PaymentPackage('HR Services', 1500)
        expect(()=>{payment.value = -1}).to.throw(Error);
        expect(()=>{payment.value = '0'}).to.throw(Error);
        expect(payment.value).to.be.equal(1500);
        payment.value = 0;
        expect(payment.value).to.be.equal(0);
    })
    it('Test VAT setter', ()=>{
        const payment = new PaymentPackage('HR Services', 1500)
        expect(()=>{payment.VAT = -1}).to.throw(Error);
        expect(()=>{payment.VAT = '0'}).to.throw(Error);
        expect(payment.VAT).to.be.equal(20);
        payment.VAT = 10;
        expect(payment.VAT).to.be.equal(10);
    })
    it('Test active setter', ()=>{
        const payment = new PaymentPackage('HR Services', 1500)
        expect(()=>{payment.active = 0}).to.throw(Error);
        expect(payment.active).to.be.true;
        payment.active =false;
        expect(payment.active).to.be.false;
    })
    it('Test toString method to work correctly', ()=>{
        const payment = new PaymentPackage('HR Services', 1500)
        let actualOutput = payment.toString();

        const expectedOutput = `Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800`;
        expect(actualOutput).to.be.equal(expectedOutput);
        payment.active = false;
        let inactiveExpectedOutput = `Package: HR Services (inactive)\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800`;
        expect(payment.toString()).to.be.equal(inactiveExpectedOutput);
    })
})