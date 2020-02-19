function solution() {
    document.querySelector("body > div > section:nth-child(1) > div > button").addEventListener('click', addGift);
    function addGift(e){
        let giftName = document.querySelector("body > div > section:nth-child(1) > div > input[type=text]").value;
        let newListItem = document.createElement('li');
        
        newListItem.className = 'gift';
        newListItem.textContent = giftName;
        let theUL = document.querySelector("body > div > section:nth-child(2) > ul");
        theUL.appendChild(newListItem);
        document.querySelector("body > div > section:nth-child(1) > div > input[type=text]").value = '';

        let alphabeticallyList = document.querySelectorAll("body > div > section:nth-child(2) > ul li");
        let alphabeticalArray = [];
        for (const li of alphabeticallyList) {
            let currElement = li.textContent.replace('SendDiscard', '');
            alphabeticalArray.push(currElement);
        }
        alphabeticalArray = alphabeticalArray.sort((a,b)=> a.localeCompare(b))
        for (let index = 0; index < alphabeticalArray.length; index++) {
            alphabeticallyList[index].textContent = alphabeticalArray[index];
            let sendButton = document.createElement('button');
            let discardButton = document.createElement('button');
            sendButton.textContent = 'Send';
            sendButton.id = 'sendButton';
            discardButton.textContent = 'Discard';
            discardButton.id = 'discardButton'
            
            alphabeticallyList[index].appendChild(sendButton);
            alphabeticallyList[index].appendChild(discardButton);
            sendButton.addEventListener('click', sendButtonClicked);
            discardButton.addEventListener('click', discardButtonClicked)
        }
    };
    function sendButtonClicked(e){
        let giftName = e.target.parentNode.textContent.replace('SendDiscard', '').trim();
        e.target.parentNode.remove();
        let newListItem = document.createElement('li');
        newListItem.className = 'gift';
        newListItem.textContent = giftName
        document.querySelector("body > div > section:nth-child(3) > ul").appendChild(newListItem)
        
    }
    function discardButtonClicked(e){
        let giftName = e.target.parentNode.textContent.replace('SendDiscard', '').trim();
        e.target.parentNode.remove();
        let newListItem = document.createElement('li');
        newListItem.className = 'gift';
        newListItem.textContent = giftName
        document.querySelector("body > div > section:nth-child(4) > ul").appendChild(newListItem)
    }
}