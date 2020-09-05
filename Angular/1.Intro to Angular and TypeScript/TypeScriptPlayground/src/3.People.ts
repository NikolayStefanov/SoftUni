abstract class Employee {
    protected moneyAmount: number = 0;
    constructor(name: string, age:number){
        this.name = name;
        this.age = age;
    }
    
    public name : string;
    public age : number;
    public salary: number = 0;
    public tasks: string[] = [];
    public work() : void{
        var currentTask = this.tasks.shift();
        this.tasks.push(currentTask!);
        console.log(currentTask);
    }

    public collectSalary(){
        return this.moneyAmount += this.salary;
    }
}

class Junior extends Employee{
    constructor(name: string, age: number, salary: number, ){
        super(name, age);
        this.salary = salary;
        this.tasks.push(`${this.name} is working on a simple task!`);
    }
}
class Senior extends Employee{
    constructor(name: string, age: number, salary: number, ){
        super(name, age);
        this.salary = salary;
        this.tasks.push(`${this.name} is working on a complicated task!`);
        this.tasks.push(`${this.name} is taking time off work!`);
        this.tasks.push(`${this.name} is supervising junior workers!`);
    }
}
class Manager extends Employee{
    constructor(name: string, age: number, salary: number, divident: number){
        super(name, age);
        this.salary = salary;
        this.divident = divident;
        this.tasks.push(`${this.name} scheduled a meeting!`);
        this.tasks.push(`${this.name} is preparing a quarterly report!`);
    }
    public divident : number = 0;
    public collectSalary(){
        return this.moneyAmount += (this.salary + this.divident);
    }
}

var juniorMan = new Junior('Nikolay', 23, 1500);
console.log('Junior employee: ')
console.log(juniorMan);
juniorMan.work();
console.log(juniorMan.collectSalary());
console.log('----------------------------------------------------------')

var seniorMan = new Senior('Nikolay', 23, 5000);
console.log('Senior employee: ')
console.log(seniorMan);
console.log('First work: '); 
seniorMan.work();
console.log('Second work: ')
seniorMan.work();
console.log(seniorMan.collectSalary());
console.log('----------------------------------------------------------')

var managerMan = new Manager('Nikolay', 23, 5000, 3000);
console.log('Manager employee: ')
console.log(managerMan);
managerMan.work();
console.log(`Manager first collect salary: ${managerMan.collectSalary()}`);
console.log(`Manager second collect salary: ${managerMan.collectSalary()}`);
console.log('----------------------------------------------------------')


