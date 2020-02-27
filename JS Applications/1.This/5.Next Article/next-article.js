function getArticleGenerator(articles){
    let articlesCopy = [...articles];
    let contentRef = document.querySelector("#content");
    return function(){
        if (articlesCopy.length === 0) {
            return;
        }
        let result = articlesCopy[0];
        articlesCopy = articlesCopy.slice(1);
        let resultElement  =document.createElement('article');
        resultElement.innerHTML = result;
        contentRef.appendChild(resultElement);
    }
}