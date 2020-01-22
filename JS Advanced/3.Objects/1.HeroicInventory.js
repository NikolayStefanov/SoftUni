function createHero(arr){
    let listOfHeroes = [];
    for (let index = 0; index < arr.length; index++) {
        let theHero = {};
        let currHeroInfo = arr[index].split(' / ');

        theHero['name'] = currHeroInfo[0];
        theHero['level'] = +(currHeroInfo[1]);
        theHero['items'] = [];
        if(currHeroInfo.length > 2){
            let currHeroGuns = currHeroInfo[2].split(', ');
            theHero['items'] = currHeroGuns;
        }
        
        listOfHeroes.push(theHero);     
    }
    return JSON.stringify(listOfHeroes);
}


