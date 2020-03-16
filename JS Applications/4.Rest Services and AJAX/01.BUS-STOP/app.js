function getInfo() {
    let inputId = document.querySelector("#stopId").value;
    let theURL = `https://judgetests.firebaseio.com/businfo/${inputId}.json`
    document.querySelector("#buses").innerHTML = '';

    fetch(theURL)
    .then(response=> response.json())
    .then(data=> {
        document.querySelector("#stopName").textContent = data.name;
        Object.entries(data.buses).forEach(([busNumber, minutes])=>{
            let li = document.createElement('li');
            li.innerHTML = `Bus ${busNumber} arrives in ${minutes} minutes`;
            document.querySelector("#buses").appendChild(li);
        })
    })
    .catch((err)=>{
        document.querySelector("#stopName").textContent = 'Error';
    })
    document.querySelector("#stopId").value = ''
}