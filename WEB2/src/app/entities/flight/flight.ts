export class Flight {
    
    id: number;
    name: string;
    datetimedeparture: string;
    datetimearrival: string;
    traveltime: string;
    travellength: number;
    ticketprice: number;

    constructor(
        id: number,
        name: string,
        datetimedeparture: string,
        datetimearrival: string,
        traveltime: string,
        travellength: number,
        ticketprice: number
    ){
        this.id = id;
        this.name = name;
        this.datetimedeparture = datetimedeparture;
        this.datetimearrival = datetimearrival;
        this.traveltime = traveltime;
        this.travellength = travellength;
        this.ticketprice = ticketprice;
    }
}
