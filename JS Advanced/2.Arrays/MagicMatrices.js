function sameRowColValue(matrix){
    resultCols = matrix.reduce((acc, currArr)=> {
        currArr.forEach((b, i) => {
            acc[i] = (acc[i] || 0) + b;
        });
        return acc;
    }, []);
    console.log(resultCols.reduce((a, b)=> 
    {return (a === b)?a:(!b);}) === resultCols[0]);
}
sameRowColValue([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]);