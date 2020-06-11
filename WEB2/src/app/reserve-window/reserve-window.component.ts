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
  passport;
  PersonCounter = 0;
  first_name = ''
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
    this.Seats = null;
    this.passport = '';
    this.PersonCounter = 0;
    this.first_name = '';
    this.last_name = '';
    this.SelectedSeats = null;
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
    let toSend;
    if(this.PersonCounter == 0){
      toSend = {
        Seat : this.SelectedSeats[this.PersonCounter],
        Passport : this.passport,
        FlightId : this.Flight.Id
      }
      fetch('/DiemApi/User/AddFlightReservation', {
        method: 'post',
        body: JSON.stringify(toSend),
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
        }
    })
    }else{
        toSend = {
          Name: this.first_name,
          last_name : this.last_name,
          Seat : this.SelectedSeats[this.PersonCounter],
          Passport : this.passport,
          FlightId : this.Flight.Id
        }
        fetch('/DiemApi/User/AddRandomFlightReservation', {
          method: 'post',
          body: JSON.stringify(toSend),
          headers: {
              'Content-Type': 'application/json',
              'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
          }
      })

    }
    this.first_name = ''
    this.last_name = ''
    this.passport = ''
    this.PersonCounter++;
    this.Seats[this.SelectedSeats[this.PersonCounter]] = "3";
    this.Seats = this.Seats.toString().replace(/,/g,'');
    if(this.PersonCounter  == this.SelectedSeats.length - 1)
      this.close();
  }
  InviteNext(User:any){
    let toSend = {
      InvitedUsername : User.Username,
      Seat : this.SelectedSeats[this.PersonCounter],
      FlightId : this.Flight.Id
    }
    fetch('/DiemApi/User/InviteReservation', {
      method: 'post',
      body: JSON.stringify(toSend),
      headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
      }
  })
    this.first_name = ''
    this.last_name = ''
    this.PersonCounter++;
    this.Seats[this.SelectedSeats[this.PersonCounter]] = "3";
    this.Seats = this.Seats.toString().replace(/,/g,'');
    if(this.PersonCounter  == this.SelectedSeats.length - 1)
      this.close();
  }

}
