class Library {
    constructor(libraryName){
        this.libraryName = libraryName;
        this.subscribers =[];
        this.subscriptionTypes = {
            normal: libraryName.length,
            special: libraryName.length*2,
            vip: Number.MAX_SAFE_INTEGER,
        } 
    }

    subscribe(name, type){
        let types = Object.keys(this.subscriptionTypes);
        if (types.every(x=> x!== type)) {
            throw new Error(`The type ${type} is invalid`);
        }
        let theSubscriber = {};
        if (this.subscribers.every(x=> x.name!==name)) {
            theSubscriber = {
                name: name,
                type: type,
                books: []
            }
            this.subscribers.push(theSubscriber);
        }else{
            theSubscriber = this.subscribers.find(x=> x.name === name);
            theSubscriber.type = type;
        }
        return theSubscriber;
    }
    unsubscribe(name){
        if (this.subscribers.every(x=> x.name != name)) {
            throw new Error(`There is no such subscriber as ${name}`)
        }
        this.subscribers = this.subscribers.filter(x=> x.name !== name);
        return this.subscribers;
    }
    receiveBook(subscriberName, bookTitle, bookAuthor){
        if (this.subscribers.every(x=> x.name !== subscriberName)) {
            throw new Error(`There is no such subscriber as ${subscriberName}"`)
        }
        let targetSubscriber = this.subscribers.find(x=> x.name === subscriberName);
        let subscriberType = targetSubscriber.type;
        let subscriberBooksCount = targetSubscriber.books.length;
        if (subscriberBooksCount < this.subscriptionTypes[subscriberType]) {
            let theBook = {title: bookTitle, author: bookAuthor};
            targetSubscriber.books.push(theBook);
            return targetSubscriber;
        }else{
            throw  new Error(`You have reached your subscription limit ${this.subscriptionTypes[subscriberType]}!`)
        }
    }
    showInfo (){
        let result = '';
        if (this.subscribers.length>0) {
            for (const subscriber of this.subscribers) {
                result+= `Subscriber: ${subscriber.name}, Type: ${subscriber.type}\n`
                let bookArr = []
                for (const book of subscriber.books) {
                    bookArr.push(`${book.title} by ${book.author}`);
                }
                result+= `Received books: ${bookArr.join(', ')}\n`
            }
        }else{
            result += `${this.libraryName} has no information about any subscribers`
        }
        return result;
    }
}
let lib = new Library('Lib');

lib.subscribe('Peter', 'normal');
lib.subscribe('John', 'special');

lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');

console.log(lib.showInfo());


