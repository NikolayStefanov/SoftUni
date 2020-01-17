function addOrRemoveElements(arr){
    let commands = {
        counter: 1,
        add: (theArray, num)=>[...theArray, num],
        remove:(theArray)=>[...theArray.slice(0, theArray.length-1)]
    }
    let result = arr.reduce((acc, curr)=>{
        acc = commands[curr](acc, commands.counter);
        commands.counter++;
        return acc;
    },[]);

    return result.length===0 ? 'Empty' : result.join('\n');
    
}
console.log(addOrRemoveElements(['add',
'add',
'remove',
'add',
'add']));

