import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Flight } from '../entities/flight/flight';

@Component({
  selector: 'reserve-window',
  templateUrl: './reserve-window.component.html',
  styleUrls: ['./reserve-window.component.css']
})
export class ReserveWindowComponent implements OnInit {
  @Input() Flight:any;
  Seats:any;
  CurrentUser:any;
  PersonCounter = 0;
  first_name = ''
  inviteDiv = false;
  last_name = ''
  SelectedSeats:any;
  @Output() alertClose = new EventEmitter();
  constructor() { }
  ngOnInit(): void {
    this.Seats = this.Flight.Seats;
    this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
    console.log(this.Flight)
  }
  close(){
    this.alertClose.emit();
  }
  NextStep(seats:any){
    this.SelectedSeats = seats.chosenSeats;
    seats.allSeats[seats.chosenSeats[this.PersonCounter]] = "3";
    this.Seats = seats.allSeats.toString().replace(/,/g,'');
    if(this.PersonCounter == 0){
      this.first_name = this.CurrentUser.Name
      this.last_name = this.CurrentUser.LastName
    }
  }
   
  ReserveAndNext(){
    this.inviteDiv = true;
    this.first_name = ''
    this.last_name = ''
    this.PersonCounter++;
    this.Seats[this.SelectedSeats[this.PersonCounter]] = "3";
    this.Seats = this.Seats.toString().replace(/,/g,'');
  }
  InviteNext(){
    this.first_name = ''
    this.last_name = ''
    this.PersonCounter++;
    this.Seats[this.SelectedSeats[this.PersonCounter]] = "3";
    this.Seats = this.Seats.toString().replace(/,/g,'');
  }

}
