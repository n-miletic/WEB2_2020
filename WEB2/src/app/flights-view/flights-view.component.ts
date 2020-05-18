import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-flights-view',
  templateUrl: './flights-view.component.html',
  styleUrls: ['./flights-view.component.css']
})
export class FlightsViewComponent implements OnInit {

  AllFlights;
  constructor() { }

  ngOnInit(): void {
    fetch("/DiemApi/Flights")
    .then(data => {
      this.AllFlights = data;
      console.log(data);
    })
  }

}
