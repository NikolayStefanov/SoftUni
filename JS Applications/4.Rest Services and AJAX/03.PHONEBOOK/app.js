function attachEvents() {
    let createButton= document.querySelector("#btnCreate");
    createButton.addEventListener('click', createContact)
    let loadButton = document.querySelector("#btnLoad");
    loadButton.addEventListener('click', loadingFunc)
    let theUrl = `https://javascriptlearningprojec-43061.firebaseio.com/phonebook.json`;

    let contactList = document.querySelector("#phonebook");

    let nextElementId = 1;
    function loadingFunc(){
        contactList.innerHTML = '';
        allIDs = [];
        fetch(theUrl)
        .then(response=> {
            if(response.ok){
                return x.json()};
            })
        .then(data=> Object.entries(data).forEach(([id, userObj])=>{
            if (userObj) {
                nextElementId = (+id) + 1;
                let newLi = document.createElement('li');
                newLi.textContent = `${userObj.person}:${userObj.phone}`;

                let newButton = document.createElement('button');
                newButton.textContent = 'DELETE';
                
                newButton.addEventListener('click', ()=>{
                    fetch(`https://javascriptlearningprojec-43061.firebaseio.com/phonebook/${id}.json`,{
                        method: 'DELETE',
                    })
                    setTimeout(loadingFunc, 450);
                })
                newLi.appendChild(newButton);
                contactList.appendChild(newLi);

                
            }
            
        }))
        .catch((err)=> {
            throw new Error("This phone number doesn't exists!")
        })
        
    }
    function createContact(){
        let contactName = document.querySelector("#person").value;
        let contactNumber = document.querySelector("#phone").value;
        if (contactName && contactName) {
            let newPersonContact = {
                [nextElementId]: {
                    person: contactName,
                    phone: contactNumber
                }   
            }
            document.querySelector("#person").value = '';
            document.querySelector("#phone").value = '';
           fetch(`https://javascriptlearningprojec-43061.firebaseio.com/phonebook.json`, {
                method: 'PATCH',
                body: JSON.stringify(newPersonContact)
            })
            .then(()=> {loadingFunc()})
        }else{
            throw new Error('PersonName or Phone is incorrect!!!')
        }
        
    }
}

attachEvents();