function dbComponentSolving(arr) {
    let systemArr = arr.reduce((acc, currEl, index) => {
        let [systemName, systemComponent, systemSubcomponent] = currEl.split('|').map(x => x.trim());
        if (!acc[systemName]) {
            acc[systemName] = {[systemComponent]: [systemSubcomponent]};
        } else {
            if (!acc[systemName][systemComponent]) {
                acc[systemName][systemComponent] = [systemSubcomponent];
            } else {
                acc[systemName][systemComponent].push(systemSubcomponent)
            }
        }
        return acc;
    }, {});


    let sortedDB = Object.keys(systemArr).sort((a, b) => {
        return Object.keys(systemArr[b]).length - Object.keys(systemArr[a]).length || a.localeCompare(b)
    });

     console.log(Object.values(systemArr['Lambda']['CoreA']));
     
    for (const systemName of sortedDB) {
        console.log(systemName);
        let components =Object.keys(systemArr[systemName]).sort((a,b)=>{
            return systemArr[systemName][b].length-systemArr[systemName][a].length;
        })
        for (const key of components) {
            console.log(`|||${key}`);
            for (const subComp of systemArr[systemName][key]) {
                console.log(`||||||${subComp}`);

            }
        }
    }
}
dbComponentSolving(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security'
]);