"use strict";
var Ticket = /** @class */ (function () {
    function Ticket(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
    return Ticket;
}());
function problemSolve(descriptions, sortingCriteria) {
    var tickets = [];
    for (var _i = 0, descriptions_1 = descriptions; _i < descriptions_1.length; _i++) {
        var description = descriptions_1[_i];
        var descriptionTockens = description.split('|', 3);
        var currentDestination = descriptionTockens[0];
        var currentPrice = +(+descriptionTockens[1]).toFixed(2);
        var currentStatus = descriptionTockens[2];
        tickets.push(new Ticket(currentDestination, currentPrice, currentStatus));
    }
    if (sortingCriteria == 'price') {
        tickets.sort(function (a, b) { return a.price - b.price; });
    }
    else if (sortingCriteria == 'destination') {
        tickets.sort(function (a, b) { return a.destination.localeCompare(b.destination); });
    }
    else {
        tickets.sort(function (a, b) { return a.status.localeCompare(b.status); });
    }
    return tickets;
}
var result = problemSolve([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
], 'status');
console.log(JSON.stringify(result));
