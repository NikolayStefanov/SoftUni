function toggle() {
    let moreOrLess = document.querySelector("#accordion > div.head > span").textContent;
    if (moreOrLess === 'More') {
        document.querySelector("#accordion > div.head > span").textContent = 'Less'
        document.querySelector("#extra").style.display = 'block';
    }else{
        document.querySelector("#accordion > div.head > span").textContent = 'More'
        document.querySelector("#extra").style.display = 'none';
    }
}