function attachEvents() {
    const loadButtonRef = document.querySelector("body > aside > button");
    const addButtonRef = document.querySelector("#addForm > button");

    loadButtonRef.addEventListener('click', listAllCatches);
    addButtonRef.addEventListener('click', createACatch)


    async function listAllCatches(e) {
        try {
            let currCatchInfo = document.querySelector("#catches > div")
            document.querySelector("#catches").innerHTML = '';

            let theUrl = 'https://fisher-game.firebaseio.com/catches.json';
            let response = await fetch(theUrl);
            if (response.ok && response.status < 400) {
                let data = await response.json();
                Object.entries(data).forEach(([key, valueObj]) => {
                    let newCatch = currCatchInfo.cloneNode(true);
                    let resultNewCatch = fillUpNewCatch(key, valueObj, newCatch)
                    document.querySelector("#catches").appendChild(resultNewCatch);
                })
            } else {
                throw Error('The problem is in Response');
            }

        } catch (error) {
            console.error(error)
        }


    }
    async function createACatch(e) {
        let inputAngler = document.querySelector("#addForm > input.angler");
        let inputWeight = document.querySelector("#addForm > input.weight");
        let inputSpecies = document.querySelector("#addForm > input.species");
        let inputLocation = document.querySelector("#addForm > input.location");
        let inputBait = document.querySelector("#addForm > input.bait");
        let inputCatchingTime = document.querySelector("#addForm > input.captureTime");
        try {
            if (inputAngler.value && inputWeight.value && inputSpecies.value && inputLocation.value && inputBait.value && inputCatchingTime.value) {
                let newCatch = {
                    angler: inputAngler.value,
                    bait: inputBait.value,
                    captureTime: inputCatchingTime.value,
                    location: inputLocation.value,
                    species: inputSpecies.value,
                    weight: inputWeight.value
                }
                    inputAngler.value = '';
                    inputBait.value = '';
                    inputCatchingTime.value = '';
                    inputWeight.value = '';
                    inputLocation.value = '';
                    inputSpecies.value = '';

                let theUrl = 'https://fisher-game.firebaseio.com/catches.json';
                await fetch(theUrl, {
                    method: 'POST',
                    body: JSON.stringify(newCatch),
                })
            } else {
                throw Error('All inputs should be filled up!')
            }
        } catch (error) {
            console.error(error)
        }

    }
    async function deleteCatch(e){
        let catchId = e.target.parentNode.getAttribute('data-id');
        let theUrl = `https://fisher-game.firebaseio.com/catches/${catchId}.json`;
        try {
            await fetch(theUrl, {
                method: 'DELETE'
            })
            listAllCatches();
        } catch (error) {
            console.error(error)
        }
        
    }
    async function updateCatch(e){
        let parent = e.target.parentNode;
        let theId = parent.getAttribute('data-id');
        let theUrl = `https://fisher-game.firebaseio.com/catches/${theId}.json`;

        let currAngler = parent.querySelector('.angler').value;
        let currWeight = parent.querySelector('.weight').value;
        let currSpecies = parent.querySelector('.species').value;
        let currLocation = parent.querySelector('.location').value;
        let currBait = parent.querySelector('.bait').value;
        let currCatchingTime = parent.querySelector('.captureTime').value;
        let newSameCatch = {
            angler: currAngler,
            weight: currWeight,
            species: currSpecies,
            location: currLocation,
            bait: currBait,
            captureTime: currCatchingTime
        }


        await fetch(theUrl, {
            method:'PUT',
            body: JSON.stringify(newSameCatch)
        })
    }

    function fillUpNewCatch(dataId, obj, newEle) {
        newEle.setAttribute('data-id', dataId);
        let angler = newEle.querySelector('.angler');
        let weight = newEle.querySelector('.weight');
        let species = newEle.querySelector('.species');
        let location = newEle.querySelector('.location');
        let bait = newEle.querySelector('.bait');
        let captureTime = newEle.querySelector('.captureTime')
        angler.setAttribute('value', obj.angler)
        weight.setAttribute('value', obj.weight);
        species.setAttribute('value', obj.species);
        location.setAttribute('value', obj.location);
        bait.setAttribute('value', obj.bait);
        captureTime.setAttribute('value', obj.captureTime);
        let deleteButton = newEle.querySelector('.delete');
        let updateButton = newEle.querySelector('.update');
        deleteButton.addEventListener('click', deleteCatch);
        updateButton.addEventListener('click', updateCatch);
        return newEle

    }
}

attachEvents();