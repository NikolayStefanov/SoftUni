class Computer {
    constructor(ramMemory, cpuGHz, hddMemory){
        this.ramMemory = ramMemory;
        this.cpuGHz = cpuGHz;
        this.hddMemory= hddMemory;
        this.taskManager = [];
        this.installedPrograms = []; 
    }
    installAProgram(name, requiredSpace){
        if (this.hddMemory - requiredSpace < 0) {
            throw new Error('There is not enough space on the hard drive');
        }
        this.hddMemory-= requiredSpace;
        let newestProgram = {name: name, requiredSpace: requiredSpace}
        this.installedPrograms.push(newestProgram)
        return newestProgram;
    }
    uninstallAProgram(name){
        let targetProgram = this.installedPrograms.find(x=> x.name === name);
        if (!targetProgram) {
            throw new Error('Control panel is not responding');
        }
        this.hddMemory += targetProgram.requiredSpace;
        this.installedPrograms = this.installedPrograms.filter(x=> x.name !== name);
        return  this.installedPrograms;
    }
    openAProgram(name){
        let targetProgram = this.installedPrograms.find(x=> x.name === name)
        if (!targetProgram) {
            throw new Error(`The ${name} is not recognized`);
        }
        if (this.taskManager.some(x=> x.name === name)) {
            throw new Error(`The ${name} is already open`);
        }
        let neededRamMemory = (targetProgram.requiredSpace/this.ramMemory) * 1.5;
        let neededCpuGHz = ((targetProgram.requiredSpace/ this.cpuGHz)/ 500) * 1.5;

        let totalUsageOfRam = this.taskManager.reduce((a,b)=>  a+b.ramUsage ,0)
        let totalUsageOfCpuGHz = this.taskManager.reduce((a,b)=>  a+b.cpuUsage ,0)

        if (totalUsageOfRam+neededRamMemory >= 100) {
            throw new Error(`${name} caused out of memory exception`)
        }
        if (totalUsageOfCpuGHz+neededCpuGHz >= 100) {
            throw new Error(`${name} caused out of cpu exception`)
        }
        let newRunningProgram = {name: name, ramUsage: neededRamMemory, cpuUsage: neededCpuGHz}
        this.taskManager.push(newRunningProgram);
        return newRunningProgram;
    }
    taskManagerView(){
        let result = '';
        if (this.taskManager.length === 0) {
            return `All running smooth so far`;
        }
        for (const program of this.taskManager) {
            result += `Name - ${program.name} | Usage - CPU: ${program.cpuUsage.toFixed(0)}%, RAM: ${program.ramUsage.toFixed(0)}%\n`;
        }
        return result.trim();
    }
}
let computer = new Computer(4096, 7.5, 250000);

computer.installAProgram('Word', 7300);
computer.installAProgram('Excel', 10240);
computer.installAProgram('PowerPoint', 12288);
computer.uninstallAProgram('Word');
computer.installAProgram('Solitare', 1500);

computer.openAProgram('Excel');
computer.openAProgram('Solitare');
console.log(computer.installedPrograms);
console.log(('-').repeat(50)) // Separator
console.log(computer.taskManagerView());

