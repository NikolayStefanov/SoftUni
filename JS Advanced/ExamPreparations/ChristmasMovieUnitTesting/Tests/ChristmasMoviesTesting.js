let expect = require('chai').expect;
let ChristmasMovies = require('../02. Christmas Movies_Resources');

describe('Testing Christmas Movie class', ()=>{
    it('Test the constructor of christmasMovie', ()=>{
        let christmasMovies =  new ChristmasMovies();
        expect(christmasMovies.watched).to.be.deep.equal({});
        expect(christmasMovies.actors).to.be.deep.equal([]);
        expect(christmasMovies.movieCollection).to.be.deep.equal([]);
    })
    it('Testing buyMovie method', ()=>{
        let christmasMovies =  new ChristmasMovies();
        let actual = christmasMovies.buyMovie('Vikings', ['Ragnar', 'Bjorn', 'Ube', 'Ragnar']);
        expect(actual).to.be.equal('You just got Vikings to your collection in which Ragnar, Bjorn, Ube are taking part!')
        let movieCol = christmasMovies.movieCollection.find(x=> x.name === 'Vikings');
        expect(movieCol.actors).to.be.deep.equal(['Ragnar', 'Bjorn', 'Ube']);
        expect(()=> {christmasMovies.buyMovie('Vikings', ['', 'Bjorn', 'Ube', 'Ragnar'])}).to.throw(Error, 'You already own Vikings in your collection!');
    })
    it('Testing discardMovie method', ()=>{
        let christmasMovies =  new ChristmasMovies();
        christmasMovies.buyMovie('Vikings', ['Ragnar', 'Bjorn', 'Ube', 'Ragnar']);
        christmasMovies.buyMovie('Terminator', ['Arnold', 'John']);
        expect(()=>{christmasMovies.discardMovie('Game Of Throwns')}).to.throw(Error);
        christmasMovies.watchMovie('Vikings');
        let actual = christmasMovies.discardMovie('Vikings');
        expect(()=>{christmasMovies.discardMovie('Terminator')}).to.throw(Error, 'Terminator is not watched!');
        expect(actual).to.be.equal('You just threw away Vikings!');
        let movieCollectionChechForDeletedMovie = christmasMovies.movieCollection.every(x=> x.name !== 'Vikings')
        expect(movieCollectionChechForDeletedMovie).to.be.true;
        let checkWatchedMovieList = !christmasMovies.watchMovie.hasOwnProperty('Vikings');
        expect(checkWatchedMovieList).to.be.true;
    })
    it('Testing watchMovie method', ()=>{
        let christmasMovies =  new ChristmasMovies();
        christmasMovies.buyMovie('Vikings', ['Ragnar', 'Bjorn', 'Ube', 'Ragnar']);
        christmasMovies.buyMovie('Terminator', ['Arnold', 'John']);
        expect(()=>{christmasMovies.watchMovie('Game Of Throwns')}).to.throw(Error, 'No such movie in your collection!')
        christmasMovies.watchMovie('Vikings');
        let actual = christmasMovies.watched['Vikings'];
        expect(actual).to.be.equal(1);
        christmasMovies.watchMovie('Vikings');
        actual = christmasMovies.watched['Vikings'];
        expect(actual).to.be.equal(2);
    })
    it('Testing favouriteMovie method', ()=>{
        let christmasMovies =  new ChristmasMovies();
        christmasMovies.buyMovie('Vikings', ['Ragnar', 'Bjorn', 'Ube', 'Ragnar']);
        christmasMovies.buyMovie('Terminator', ['Arnold', 'John']);
        expect(()=>{christmasMovies.favouriteMovie()}).to.throw(Error, 'You have not watched a movie yet this year!')
        christmasMovies.watchMovie('Vikings');
        christmasMovies.watchMovie('Vikings');
        christmasMovies.watchMovie('Vikings');
        christmasMovies.watchMovie('Terminator');
        expect(christmasMovies.favouriteMovie()).to.be.equal('Your favourite movie is Vikings and you have watched it 3 times!')
    })
    it('Testing mostStarredActor method', ()=>{
        let christmasMovies =  new ChristmasMovies();
        expect(()=>{christmasMovies.mostStarredActor()}).to.throw(Error, 'You have not watched a movie yet this year!')
        christmasMovies.buyMovie('Vikings', ['Ragnar', 'Bjorn', 'Ube', 'Ragnar']);
        christmasMovies.buyMovie('Terminator', ['Arnold', 'John']);
        christmasMovies.buyMovie('Hesoyam', ['Ragnar', 'Niki', 'Polu']);
        expect(christmasMovies.mostStarredActor()).to.be.equal('The most starred actor is Ragnar and starred in 2 movies!')
    })
})