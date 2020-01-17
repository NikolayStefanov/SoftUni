function arrayJoin(arr){
    const delimeter = arr.pop();
    const result = arr.join(`${delimeter}`);
    return result;
}
console.log(arrayJoin(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-']));
