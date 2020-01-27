function returnCountAndType() {
    let typeCount = {};
    for (const arg of arguments) {
        console.log(`${typeof(arg)}: ${arg}`);

        if (!typeCount[typeof (arg)]) {
            typeCount[typeof (arg)] = 0;
        }
        typeCount[typeof (arg)]++;
    }
    let sortedArr = Object.entries(typeCount).sort((a, b) => {
        return b[1] - a[1];
    });;
    for (const ele of sortedArr) {
        console.log(`${ele[0]} = ${ele[1]}`);
    }

}

returnCountAndType('cat', 42, function () {
    console.log('Hello world!');
});