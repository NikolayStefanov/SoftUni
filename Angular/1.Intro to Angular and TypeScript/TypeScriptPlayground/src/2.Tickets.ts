class Ticket {
    constructor(destination: string, price: number, status: string) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
    destination: string;
    price: number;
    status: string;
}
function problemSolve (descriptions : Array<string>, sortingCriteria : string): Ticket[] {
    

    var tickets: Ticket[] = [];

    for (const description of descriptions) {
        var descriptionTockens = description.split('|', 3)
        var currentDestination : string = descriptionTockens[0];
        var currentPrice : number = +(+descriptionTockens[1]).toFixed(2);
        var currentStatus :string = descriptionTockens[2];

        tickets.push(new Ticket(currentDestination, currentPrice, currentStatus));
    }
    

    if(sortingCriteria == 'price'){
        tickets.sort((a, b)=> {return a.price-b.price});
    }else if(sortingCriteria == 'destination'){
        tickets.sort((a, b)=> { return a.destination.localeCompare(b.destination)});
    }else{
        tickets.sort((a, b)=> {return a.status.localeCompare(b.status)});
    }
    return tickets;
}

var result = problemSolve([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
    ],
    'status');

console.log(JSON.stringify(result));