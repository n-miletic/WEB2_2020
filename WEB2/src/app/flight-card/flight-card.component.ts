import { Component,EventEmitter,Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'flight-card',
  templateUrl: './flight-card.component.html',
  styleUrls: ['./flight-card.component.css']
})
export class FlightCardComponent implements OnInit {

  constructor() { }
  @Input() Flight: any;
  @Input() shut_up:any;
  CurrentUser:any;
  @Output() alertReserve = new EventEmitter();
  ngOnInit(): void {
    this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
  }
  reserve(){
    this.alertReserve.emit("OPEN THE DAMN THING")
  }
  
  

}
