import { Component,Input,Output,EventEmitter, OnInit } from '@angular/core';

@Component({
  selector: 'offer-card',
  templateUrl: './offer-card.component.html',
  styleUrls: ['./offer-card.component.css']
})
export class OfferCardComponent implements OnInit {

  constructor() { }
  @Input() Flight: any;
  @Input() shut_up:any;
  Seat:any;
  passport = ''
  CurrentUser:any;
  @Output() alertDone = new EventEmitter();
  ngOnInit(): void {
    this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
    this.Seat = this.Flight.Seats.split('').findIndex(u=> u == '5')
  }
  
  updateLoggedUser(){
    fetch('/DiemApi/User/GetLogged',
    {
      headers:{
        'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
      }
    }
    ).then(res=> res.json()).then(
      user => {sessionStorage.setItem("LoggedUser",JSON.stringify(user)); this.CurrentUser = user;this.alertDone.emit("close")}
    )
  }
  fastreserve(){
    let toSend = {
      FlightId : this.Flight.Id,
      Seat : this.Seat,
      Passport : this.passport
    }
    fetch(`DiemApi/User/AddFastFlightReservation`, {
      method: 'post',
      body: JSON.stringify(toSend),
      headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
      }
  }).then(()=>this.updateLoggedUser() )
  
  }
  
}
