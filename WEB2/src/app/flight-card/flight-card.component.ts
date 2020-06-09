import { Component,Input, OnInit } from '@angular/core';

@Component({
  selector: 'flight-card',
  templateUrl: './flight-card.component.html',
  styleUrls: ['./flight-card.component.css']
})
export class FlightCardComponent implements OnInit {

  constructor() { }
  @Input() Flight: any;
  ngOnInit(): void {
  }

}
