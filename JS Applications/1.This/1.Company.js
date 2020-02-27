class Company{
    constructor(){
        this.departments = [];
    }
    addEmployee(username, Salary, Position, Department){
        if (!username || !Salary || !Position || !Department) {
            throw new Error(`Invalid input!`)
        }
        if (Salary < 0) {
            throw new Error(" Invalid input!")
        }
        let newEmployee = {name: username, salary: Salary, position: Position};
        if (!this.departments[Department]) {
            this.departments[Department] = [];
        }
        this.departments[Department].push(newEmployee);
        return `New employee is hired. Name: ${username}. Position: ${Position}`;
    }
    bestDepartment(){
      let avarageSalaryAndBestDepartment = this.highestAverageSalary();
      let bestDepartment =avarageSalaryAndBestDepartment[1];
      let averageSalary = avarageSalaryAndBestDepartment[0].toFixed(2);
      this.departments[bestDepartment] = this.departments[bestDepartment].sort((a,b)=>{
          if (a.salary === b.salary) {
              return a.name.localeCompare(b.name);
          }
          return b.salary-a.salary;
      })
      let result = '';
      result += `Best Department is: ${bestDepartment}\n`;
      result+= `Average salary: ${averageSalary}\n`
      for (const employee of this.departments[bestDepartment]) {
          result+= `${employee.name} ${employee.salary} ${employee.position}\n`
      }
      return result.trim();
    }
    highestAverageSalary(){
        let nameAndAverageSalary = [];
        let biggestAverageSalary = 0;
        let bestDep;
        let departments = Object.keys(this.departments);
        for (const name of departments) {
            let currAverageSalary = this.departments[name].reduce((acc, curr)=>{
                acc += curr.salary;
                return acc;
            }, 0) / this.departments[name].length;
            if (currAverageSalary > biggestAverageSalary) {
                biggestAverageSalary = currAverageSalary;
                bestDep = name;
            }
        }
        nameAndAverageSalary.push(biggestAverageSalary);
        nameAndAverageSalary.push(bestDep);
        return nameAndAverageSalary;
    }
}
let c = new Company();
c.addEmployee('Stanimir', 2000, 'engineer', 'Construction');
c.addEmployee('Pesho', 1500, 'electrical engineer', 'Construction');
c.addEmployee('Slavi', 500, 'dyer', 'Construction');
c.addEmployee('Stan', 2000, 'architect', 'Construction');
c.addEmployee('Stanimir', 1200, 'digital marketing manager', 'Marketing');
c.addEmployee('Pesho', 1000, 'graphical designer', 'Marketing');
c.addEmployee('Gosho', 1350, 'HR', 'Human resources');
console.log(c.bestDepartment());