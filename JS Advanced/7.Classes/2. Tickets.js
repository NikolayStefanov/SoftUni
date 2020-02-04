function manageTickets(ticketsInfo, sorting){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    let tickets = ticketsInfo.reduce((acc, curr) => {
        let [currDestination, currPrice, currStatus] = curr.split('|').map(x=> x.trim());
        let currTicket = new Ticket(currDestination, +currPrice, currStatus);
        acc.push(currTicket);
        return acc;
    }, [])
    
    switch (sorting) {
        case 'status':
            tickets.sort((a,b)=> {
                return a.status.localeCompare(b.status);
            })
            break;
        case 'price':
            tickets.sort((a,b)=> {
                return a.price-b.price;
            })
            break;
    
        default:
            tickets.sort((a,b)=> {
                return a.destination.localeCompare(b.destination);
            });
            break;
    }
    
    return tickets;
}

manageTickets(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'price');