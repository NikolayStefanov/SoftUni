function attachEvents() {
    let refreshButton =  document.querySelector("#refresh");
    let textField = document.querySelector("#messages");
    let databaseUrl ='https://rest-messanger.firebaseio.com/messanger.json';

    let sentButton = document.querySelector("#submit");
    sentButton.addEventListener('click', ()=>{
        let theName = document.querySelector("#author").value;
        let theContent = document.querySelector("#content").value;
        if (theName && theContent) {
            let theNewMessage = {
                author: theName,
                content: theContent,
            }
            document.querySelector("#author").value = '';
            document.querySelector("#content").value = '';
            fetch(databaseUrl, {
                method: 'POST',
                body: JSON.stringify(theNewMessage)
            }).then(()=> {refreshTheChat()})
            
        }else{
            throw new  Error('Incorrect Name or Message!')
        }
    })

    refreshButton.addEventListener('click', refreshTheChat)

    function refreshTheChat(e){
        textField.value = '';
        fetch(databaseUrl)
        .then(response=> {
            if (response.ok) {
              return  response.json()}
            })
        .then(data=> Object.values(data).forEach((user=>{
            textField.value += `${user.author}: ${user.content}\n`
        })))
    }
}

attachEvents();