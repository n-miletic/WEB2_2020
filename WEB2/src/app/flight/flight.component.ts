import { Component, OnInit } from '@angular/core';
import { Flight } from 'src/app/entities/flight/flight'

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css']
})
export class FlightComponent implements OnInit {

  tripType = ['Return', 'One Way'];
  cabinClass = ['Economy', 'Premium Economy', 'Business Class', 'First Class'];
  travellers = ['1 adult', '2 adults', '1 adult and 1 child', '1 adult and 2 children', 
                '2 adults and 1 child', '2 adults and 2 children'];

  
  submitted = false;

  onSubmit() { this.submitted = true; }
  constructor() { }

  ngOnInit(): void {
  }

}
