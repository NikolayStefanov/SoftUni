import {createBook, listAllBooks} from './firebaseUrlAndCallbacks.js';
function solve() {
    let submitButtonRef = document.querySelector("body > form > button");
    submitButtonRef.addEventListener('click', createBook) 
    
    let loadAllBooksRef = document.querySelector('#loadBooks');
    loadAllBooksRef.addEventListener('click', listAllBooks)
}
solve();