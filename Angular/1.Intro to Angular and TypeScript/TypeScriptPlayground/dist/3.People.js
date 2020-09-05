"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Employee = /** @class */ (function () {
    function Employee(name, age) {
        this.moneyAmount = 0;
        this.salary = 0;
        this.tasks = [];
        this.name = name;
        this.age = age;
    }
    Employee.prototype.work = function () {
        var currentTask = this.tasks.shift();
        this.tasks.push(currentTask);
        console.log(currentTask);
    };
    Employee.prototype.collectSalary = function () {
        return this.moneyAmount += this.salary;
    };
    return Employee;
}());
var Junior = /** @class */ (function (_super) {
    __extends(Junior, _super);
    function Junior(name, age, salary) {
        var _this = _super.call(this, name, age) || this;
        _this.salary = salary;
        _this.tasks.push(_this.name + " is working on a simple task!");
        return _this;
    }
    return Junior;
}(Employee));
var Senior = /** @class */ (function (_super) {
    __extends(Senior, _super);
    function Senior(name, age, salary) {
        var _this = _super.call(this, name, age) || this;
        _this.salary = salary;
        _this.tasks.push(_this.name + " is working on a complicated task!");
        _this.tasks.push(_this.name + " is taking time off work!");
        _this.tasks.push(_this.name + " is supervising junior workers!");
        return _this;
    }
    return Senior;
}(Employee));
var Manager = /** @class */ (function (_super) {
    __extends(Manager, _super);
    function Manager(name, age, salary, divident) {
        var _this = _super.call(this, name, age) || this;
        _this.divident = 0;
        _this.salary = salary;
        _this.divident = divident;
        _this.tasks.push(_this.name + " scheduled a meeting!");
        _this.tasks.push(_this.name + " is preparing a quarterly report!");
        return _this;
    }
    Manager.prototype.collectSalary = function () {
        return this.moneyAmount += (this.salary + this.divident);
    };
    return Manager;
}(Employee));
var juniorMan = new Junior('Nikolay', 23, 1500);
console.log('Junior employee: ');
console.log(juniorMan);
juniorMan.work();
console.log(juniorMan.collectSalary());
console.log('----------------------------------------------------------');
var seniorMan = new Senior('Nikolay', 23, 5000);
console.log('Senior employee: ');
console.log(seniorMan);
console.log('First work: ');
seniorMan.work();
console.log('Second work: ');
seniorMan.work();
console.log(seniorMan.collectSalary());
console.log('----------------------------------------------------------');
var managerMan = new Manager('Nikolay', 23, 5000, 3000);
console.log('Manager employee: ');
console.log(managerMan);
managerMan.work();
console.log("Manager first collect salary: " + managerMan.collectSalary());
console.log("Manager second collect salary: " + managerMan.collectSalary());
console.log('----------------------------------------------------------');
