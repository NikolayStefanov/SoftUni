function solve(worker){
    if (worker.dizziness) {
        let additionalWater = 0.1 * worker.weight * worker.experience;
        worker.levelOfHydrated += additionalWater; 
        worker.dizziness= false;
    }
    return worker
}
let person = { wweight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false };
console.log(solve(person));
