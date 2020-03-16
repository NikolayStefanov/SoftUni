function solve() {

    let theUrl = `https://judgetests.firebaseio.com/schedule/`
    let currentStopId = 'depot';
    let currentStop = '';

    function depart() {
        const url = theUrl + currentStopId + '.json';
        fetch(url)
        .then(x=> x.json())
        .then(data => loadStop(data))
    }

    function arrive() {
        document.querySelector("#info > span").textContent = `Arriving at ${currentStop.name}`;
        document.querySelector("#depart").disabled = false;
        document.querySelector("#arrive").disabled = true;
        
    }
    function loadStop(data){
        currentStop = data;
        document.querySelector("#info > span").textContent = `Next stop ${currentStop.name}`;
        currentStopId = currentStop.next;
        document.querySelector("#depart").disabled = true;
        document.querySelector("#arrive").disabled = false;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();