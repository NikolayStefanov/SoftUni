let expect = require('chai').expect;
let BookStore = require('../02. Book Store_Ресурси');

describe('Tests for Book Store Class', ()=>{
    it('Tests for constructon', ()=>{
        let bookStore = new BookStore('Store');
        expect(bookStore.name).to.be.equal('Store');
        expect(bookStore.books).to.be.deep.equal([]);
        expect(bookStore.workers).to.be.deep.equal([]);
    })
    it('Tests for stockBook method', ()=>{
        let bookStore = new BookStore('Store');
        expect(bookStore.stockBooks(['Vikings-Travis Fimmel', 'Last Action Hero-Arnold'])).to.be.deep.equal([{title: 'Vikings', author: 'Travis Fimmel'}, {title: 'Last Action Hero', author: 'Arnold'}])
        expect(bookStore.books.length).to.be.equal(2);
        let actual = bookStore.books.find(x=> x.title === 'Vikings');
        expect(actual).to.be.deep.equal({title: 'Vikings', author: 'Travis Fimmel'});
    })
    it('Tests for hire method', ()=>{
        let bookStore = new BookStore('Store');
        expect(bookStore.hire('Niki', 'seller')).to.be.equal('Niki started work at Store as seller');
        expect(()=>{bookStore.hire('Niki', 'upravitel')}).to.throw(Error, 'This person is our employee');
    })
    it('Tests for fire method', ()=>{
        let bookStore = new BookStore('Store');
        expect(()=>{bookStore.fire('Niki')}).to.throw(Error,"Niki doesn't work here")
        expect(bookStore.hire('Niki', 'seller')).to.be.equal('Niki started work at Store as seller');
        expect(bookStore.workers.length).to.be.equal(1);
        expect(bookStore.fire('Niki')).to.be.equal('Niki is fired');
        expect(bookStore.workers.length).to.be.equal(0);
    })
    it('Tests for sellBook method', ()=>{
        let bookStore = new BookStore('Store');
        bookStore.hire('Niki', 'seller');
        bookStore.hire('Poly', 'colega');
        bookStore.stockBooks(['Vikings-Travis Fimmel', 'Last Action Hero-Arnold'])
        let nikiAcc = bookStore.workers.find(x=> x.name === 'Niki');
        expect(nikiAcc.booksSold).to.be.equal(0);
        expect(bookStore.books.length).to.be.equal(2);
        bookStore.sellBook('Last Action Hero', 'Niki');
        expect(bookStore.books.length).to.be.equal(1);
        expect(nikiAcc.booksSold).to.be.equal(1);
        expect(()=>{bookStore.sellBook('Poly', 'Terminator')}).to.throw(Error)
        expect(()=>{bookStore.sellBook('Johnny', 'Vikings')}).to.throw(Error)

    })
    it('Tests for printWorkers method', ()=>{
        let bookStore = new BookStore('Store');
        bookStore.hire('Niki', 'seller');
        bookStore.hire('Poly', 'colega');
        bookStore.stockBooks(['Vikings-Travis Fimmel', 'Last Action Hero-Arnold'])
        bookStore.sellBook('Last Action Hero', 'Niki');
        let expectedRes = 'Name:Niki Position:seller BooksSold:1\n'+ 'Name:Poly Position:colega BooksSold:0'
        let actualRes =  bookStore.printWorkers();
        expect(actualRes).to.be.equal(expectedRes);
    })
})