let SkiResort = require('../solution');
let expect = require('chai').expect;
describe('SkiResort', function () {
    it('SkiResort constructor should work correct', () => {
        let temp = new SkiResort('Some');
        expect(temp.name).to.be.equal('Some');
        expect(temp.voters).to.be.equal(0);
        expect(temp.hotels).to.be.deep.equal([]);
    })
    it('Best Hotel method should work correct', () => {
        let temp = new SkiResort('Some');
        expect(temp.bestHotel).to.be.equal('No votes yet');
        temp.build("Sun", 10);
        temp.build('Avenue', 5)
        temp.book('Sun', 5);
        temp.book('Avenue', 5);
        temp.leave('Sun', 3, 2);
        temp.leave('Avenue', 3, 3);
        let actual = temp.bestHotel;
        expect(actual).to.be.equal('Best hotel is Avenue with grade 9. Available beds: 3')
    })
    it('Test of method Build', () => {
        let temp = new SkiResort('Some');
        expect(() => {temp.build('', 1)}).to.throw(Error);
        expect(() => {temp.build('Sun', 0)}).to.throw(Error);

        let actual = temp.build('Sun', 10);

        expect(actual).to.be.equal('Successfully built new hotel - Sun');
        expect(temp.hotels[0].name).to.be.equal('Sun');
        expect(temp.hotels.length).to.be.equal(1);
        actual = temp.build('Avenue', 5);
        expect(actual).to.be.equal('Successfully built new hotel - Avenue');
        expect(temp.hotels.length).to.be.equal(2);
        expect(temp.hotels[1].name).to.be.equal('Avenue');

        let targetHotel = temp.hotels.find(x=> x.name === 'Sun');
        expect(targetHotel.beds).to.be.equal(10);
        expect(targetHotel.points).to.be.equal(0);
    })
    it('Tests for Book method', () => {
        let temp = new SkiResort('Some');
        temp.build('Sun', 10);
        expect(() => {temp.book('', 1)}).to.throw(Error);
        expect(() => { temp.book('Sun', 0)}).to.throw(Error);
        expect(() => {temp.book('Bachkovo', 1)}).to.throw(Error, 'There is no such hotel');
        expect(() => {temp.book('Sun', 11)}).to.throw(Error, 'There is no free space');

        let actual = temp.book('Sun', 1);
        expect(actual).to.be.equal('Successfully booked');
        let targetHotel = temp.hotels.find(x=> x.name === 'Sun');
        expect(targetHotel.beds).to.be.equal(9);
        temp.book('Sun', 3);
        expect(targetHotel.beds).to.be.equal(6);

    })
    it('Test for Leave method', () => {
        let temp = new SkiResort('Some');
        temp.build('Sun', 10);
        temp.book('Sun', 5);
        expect(() => { temp.leave('', 1, 0)}).to.throw(Error);
        expect(() => {temp.leave('Sun', 0, 0)}).to.throw(Error);
        expect(() => {temp.leave('Bachkovo', 1, 0)}).to.throw(Error);

        let targetHotel = temp.hotels.find(x => x.name === 'Sun');
        expect(targetHotel.name).to.be.equal('Sun');
        expect(targetHotel.beds).to.be.equal(5);
        let actual = temp.leave('Sun', 3, 2);
        expect(actual).to.be.equal(`3 people left Sun hotel`)
        expect(targetHotel.points).to.be.equal(6);
        expect(targetHotel.beds).to.be.equal(8);
        expect(temp.voters).to.be.equal(3);
        temp.leave('Sun', 2, 2)
        expect(temp.voters).to.be.equal(5);
        expect(targetHotel.beds).to.be.equal(10);
        expect(targetHotel.points).to.be.equal(10);
    })
    it('Test for AverageGrade method', () => {
            let temp = new SkiResort('Some');
            expect(temp.averageGrade()).to.be.equal('No votes yet');
            temp.build("Sun", 10);
            temp.build('Avenue', 5)
            temp.book('Sun', 5);
            temp.book('Avenue', 5);
            temp.leave('Sun', 3, 2);
            temp.leave('Avenue', 3, 3);
            temp.book('Avenue', 3);
            temp.leave('Avenue', 3, 0.5);
            let actual  = temp.averageGrade();
            expect(actual).to.be.equal('Average grade: 1.83');
    })
});