export const theUrl = `https://remotedatabasesoftunijsapps.firebaseio.com/`;

export async function createBook(e) {
    e.preventDefault();
    let bookName = document.querySelector("#title");
    let bookAuthor = document.querySelector("#author");
    let bookIdsn = document.querySelector("#isbn");

    let obj = {
        title: bookName.value,
        author: bookAuthor.value,
        isbn: bookIdsn.value
    }
    
    bookName.value = '';
    bookAuthor.value = '';
    bookIdsn.value = '';
    
    let targetUrl = theUrl + 'books.json';
    await fetch(targetUrl, {
        method: 'POST',
        body: JSON.stringify(obj)
    });

    listAllBooks();
}

export async function listAllBooks(e) {
    let targetUrl = theUrl + 'books.json';

    try {
        let response = await fetch(targetUrl);
        if (!response.ok) {
            throw Error('The problem is in response!');
        }
        
        let tableRowStructure = document.createElement('tr');
        tableRowStructure.innerHTML = `
        <td>TEST Title</td>
        <td>TEST Author</td>
        <td>TEST isbn</td>
        <td>
            <button>Edit</button>
            <button>Delete</button>
        </td>`
        
        
        let tableBody = document.querySelector("body > table > tbody");
        tableBody.innerHTML = '';
        
        let data = await response.json();
        
        Array.from(Object.values(data)).forEach(bookInfo =>{
            let tempRow = tableRowStructure.cloneNode(true);
            let finalTableRow = makeFinalTableRow(tempRow, bookInfo);
            
            tableBody.appendChild(finalTableRow);
        })

    } catch (error) {
        console.error(error)
    }
}

function fillUpInput(e){
    let targetTR = e.target.parentNode;

    if (targetTR.tagName === 'TD') {
        return;
    }
    
    let bookTitle = targetTR.querySelector('td:nth-child(1)').textContent;
    let bookAuthor = targetTR.querySelector('td:nth-child(2)').textContent;
    let bookIsbn = targetTR.querySelector('td:nth-child(3)').textContent;

    document.querySelector("#title").value = bookTitle;
    document.querySelector("#author").value = bookAuthor;
    document.querySelector("#isbn").value = bookIsbn; 
}
function findId(data, title, author,isbn){
    let theID;
    Object.entries(data).forEach(([id, obj])=>{
        if (obj.title === title && obj.author === author && obj.isbn === isbn) {
            theID= id;
        }
    })
    return theID
}

function makeFinalTableRow(tableRow, bookInfo){
     
    tableRow.querySelector('td:nth-child(1)').textContent = bookInfo.title;
    tableRow.querySelector('td:nth-child(2)').textContent = bookInfo.author;
    tableRow.querySelector('td:nth-child(3)').textContent = bookInfo.isbn;
    
    let editButton = tableRow.querySelector('td:nth-child(4) button:nth-child(1)');
    let deleteButton = tableRow.querySelector('td:nth-child(4) > button:nth-child(2)');

    editButton.addEventListener('click', editFunc)
    deleteButton.addEventListener('click', deleteFunc)
    tableRow.addEventListener('click', fillUpInput)
    return tableRow;
}

async function editFunc(e){
    let parentNode = e.target.parentNode.parentNode;

    let bookTitle = parentNode.querySelector('td:nth-child(1)').textContent;
    let bookAuthor = parentNode.querySelector('td:nth-child(2)').textContent;
    let bookIsbn = parentNode.querySelector('td:nth-child(3)').textContent;

    try {
        let response = await fetch(theUrl + 'books.json');
        let data = await response.json();
    
    let targetId = findId(data, bookTitle, bookAuthor, bookIsbn);

    let newTitle =document.querySelector("#title").value;
    let newAuthor =document.querySelector("#author").value;
    let newIsbn = document.querySelector("#isbn").value;
    if (newTitle === '' || newAuthor === '' || newIsbn === '') {
        throw Error('First you should make changes!');
    }
    let newObj = {
        title: document.querySelector("#title").value,
        author: document.querySelector("#author").value,
        isbn: document.querySelector("#isbn").value
    }
    let theFinalTargetId = `${theUrl}books/${targetId}.json`
    await fetch(theFinalTargetId, {
        method: 'PUT',
        body: JSON.stringify(newObj)
    })

    document.querySelector("#title").value = '';
    document.querySelector("#author").value = '';
    document.querySelector("#isbn").value = '';

    listAllBooks();
    } catch (error) {
        console.error(error);
        
    }

    
    
}
async function deleteFunc(e){
    let targetTr = e.target.parentNode.parentNode;
    let bookTitle = targetTr.querySelector('td:nth-child(1)').textContent;
    let bookAuthor = targetTr.querySelector('td:nth-child(2)').textContent;
    let bookIsbn = targetTr.querySelector('td:nth-child(3)').textContent;

    let response = await fetch(theUrl + 'books.json');
    let data = await response.json();
    
    let targetId = findId(data, bookTitle, bookAuthor, bookIsbn);
    let theFinalTargetId = `${theUrl}books/${targetId}.json`

    await fetch(theFinalTargetId, {
        method: 'DELETE'
    })

    listAllBooks();

    
}