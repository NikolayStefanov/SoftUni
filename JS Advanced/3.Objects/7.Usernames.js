function createCatalogue(arr){
    let uniqueNames = [...new Set(arr)];
    let orderedArr = uniqueNames.sort((a,b)=> a.length-b.length || a.localeCompare(b));
    orderedArr.forEach(x=> console.log(x));
};
createCatalogue(['Denise',
    'Ignatius',
    'Iris',
    'Isacc',
    'Indie',
    'Dean',
    'Donatello',
    'Enfuego',
    'Benjamin',
    'Biser',
    'Bounty',
    'Renard',
    'Rot']);