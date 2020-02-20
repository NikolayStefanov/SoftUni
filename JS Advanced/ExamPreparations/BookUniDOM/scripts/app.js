function solve() {
    document.querySelector("body > form > button").addEventListener('click', addBookFunc);
    function addBookFunc(e){
        e.preventDefault();
        let bookName = document.querySelector("body > form > input[type=text]:nth-child(2)").value;
        let bookYear = +(document.querySelector("body > form > input[type=number]:nth-child(4)").value);
        let bookPrice = +(document.querySelector("body > form > input[type=number]:nth-child(6)").value);
        if (typeof(bookName) === 'string' && bookName !== '' 
        && typeof(bookYear) === 'number' && bookYear >0 
        && typeof(bookPrice) === 'number' && bookPrice> 0) {
            let currBook = document.createElement('div');
            currBook.className = 'book';
            let pNameAndYear = document.createElement('p');
            pNameAndYear.textContent = `${bookName} [${bookYear}]`;

            if (bookYear >= 2000) {
                let buyButton = document.createElement('button');
                buyButton.textContent = `Buy it only for ${bookPrice.toFixed(2)} BGN`;
                let moveToOldSectonButton = document.createElement('button');
                moveToOldSectonButton.textContent = `Move to old section`;
                currBook.appendChild(pNameAndYear);
                currBook.appendChild(buyButton);
                currBook.appendChild(moveToOldSectonButton);
                document.querySelector("#outputs > section:nth-child(2) > div").appendChild(currBook);
                buyButton.addEventListener('click', buyTheBookFromNewBooks);
                moveToOldSectonButton.addEventListener('click', moveTheBook);
            }else{
                let buyButton = document.createElement('button');
                let oldBookPrice = (bookPrice * 0.85).toFixed(2);
                buyButton.textContent = `Buy it only for ${oldBookPrice} BGN`;
                currBook.appendChild(pNameAndYear);
                currBook.appendChild(buyButton);
                document.querySelector("#outputs > section:nth-child(1) > div").appendChild(currBook);
                buyButton.addEventListener('click', buyTheBookFromOldBooks);
            }
        }
    }
    function buyTheBookFromNewBooks(e){
        let profit = +(e.target.textContent.split(' ')[4])
        e.target.parentNode.remove();
        
        let currProfit = document.querySelector("body > h1:nth-child(3)").textContent.split(' ')[3];
        profit+= +(currProfit);
        document.querySelector("body > h1:nth-child(3)").textContent = `Total Store Profit: ${profit.toFixed(2)} BGN`
    }
    function moveTheBook(e){
        let currBookPrice = +(e.target.parentNode.querySelector('button').textContent.split(' ')[4]);
        let newPrice = currBookPrice * 0.85;
        e.target.parentNode.querySelector('button').textContent =  `Buy it only for ${newPrice.toFixed(2)} BGN`
        let fullBook = e.target.parentNode;
        fullBook.querySelectorAll('button')[1].remove();
        document.querySelector("#outputs > section:nth-child(1) > div").appendChild(fullBook);
    }
    function buyTheBookFromOldBooks(e){
        let profit = +(e.target.textContent.split(' ')[4])
        e.target.parentNode.remove();
        let currProfit = document.querySelector("body > h1:nth-child(3)").textContent.split(' ')[3];
        profit+= +(currProfit);
        document.querySelector("body > h1:nth-child(3)").textContent = `Total Store Profit: ${profit.toFixed(2)} BGN`
    }

}