import { Component, OnInit } from '@angular/core';
import { Flight } from 'src/app/entities/flight/flight'

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css']
})
export class FlightComponent implements OnInit {
  CurrentUser ;
  seats:string;
  Flights:any;
  tripType = ['Return', 'One Way'];
  cabinClass = ['Economy', 'Premium Economy', 'Business Class', 'First Class'];
  travellers = ['1 adult', '2 adults', '1 adult and 1 child', '1 adult and 2 children', 
                '2 adults and 1 child', '2 adults and 2 children'];

  
  submitted = false;

  onSubmit() { this.submitted = true; }
  constructor() { }

  ngOnInit(): void {
    this.seats = "00000000000000000000000000000000000000";
    this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
     fetch("/DiemApi/Flights")
    .then(data => data.json())
    .then(flights => {this.Flights = flights;})
  }

}
