function sortArr(arr){
    let sortedArr=[];
    sortedArr= arr.sort((a, b)=> {
        if (a.length === b.length) {
            return a.localeCompare(b);
        }else{
            return a.length-b.length;
        }
    });
    sortedArr.forEach(element => {
        console.log(element);   
    });
}
(sortArr(['Isacc',
'Theodor',
'Jack',
'Harrison',
'George']));

