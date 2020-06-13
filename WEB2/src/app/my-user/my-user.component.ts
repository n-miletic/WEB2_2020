import { Component,ChangeDetectorRef,ViewChildren, ContentChildren,forwardRef,OnInit, ContentChild, AfterViewInit, Renderer2, ViewChild, AfterViewChecked, ElementRef } from '@angular/core';
import { getLocaleDateTimeFormat } from '@angular/common';
import { FlightCardComponent } from '../flight-card/flight-card.component';

@Component({
  selector: 'app-my-user',
  templateUrl: './my-user.component.html',
  styleUrls: ['./my-user.component.css']
})
export class MyUserComponent implements OnInit, AfterViewChecked {
  @ViewChildren('ratestaywindow') toggleratewindow;
  MyUser : any;
  pass = ''
  pass_new = ''
  AllUsers: any;
  MyReservations:any;
  ReservationInvitations:any;
  
  MyPastReservations:any;
  togglecomment = new Array(50).fill(false);
  constructor() {
   
   }
 ngAfterViewChecked(){
  if(this.toggleratewindow != undefined){
    this.toggleratewindow.toArray().forEach(ref => ref.nativeElement.addEventListener('click',this.RateMe))
  }
 }
 editUser($event){
 console.log(this.MyUser)
 let toSend = {
   Name:this.MyUser.Name,
   LastName:this.MyUser.LastName,
   Username:this.MyUser.Username,
   Hash:this.pass,
   NewHash:this.pass_new,
   Email:this.MyUser.Email
 }
 fetch(`/DiemApi/User/Edit`, {
     
  method: 'post',
  body: JSON.stringify(toSend),
  headers: {
    'Content-Type': 'application/json',
    'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey"),
  },
}).then(res => res.json()).then((UserGift)=>{
  sessionStorage.setItem("tokenKey",UserGift.Token)
  sessionStorage.setItem("LoggedUser",JSON.stringify(UserGift.User))
  this.MyUser = UserGift.User;
});
 }
 updateLoggedUser(){
  fetch('/DiemApi/User/GetLogged',
  {
    headers:{
      'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
    }
  }
  ).then(res=> res.json()).then(
    user => {sessionStorage.setItem("LoggedUser",JSON.stringify(user)); this.MyUser = user}
  )
}
  ngOnInit(): void {
    this.MyUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
    console.log(this.MyUser?.FlightReservations[0])
    fetch('/DiemApi/User/GetAll/Logged',
    {
      headers:{
        'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
      }
    }).then(res => res.json()).then( users => this.AllUsers = users ).then(
      ()=>{
        console.log(this.MyUser)
        this.MyReservations = this.MyUser?.FlightReservations?.filter(u=> u.Invited_By == null && new Date().toLocaleDateString() < u.Flight.Flight_Departure_Time)
        this.MyPastReservations = this.MyUser?.FlightReservations?.filter(u=> u.Invited_By == null && new Date().toLocaleDateString() > u.Flight.Flight_Departure_Time)
        this.ReservationInvitations = this.MyUser?.FlightReservations?.filter(u=> u.Invited_By != null)
      }
    )
  }
  
  RateMe = ($event) =>  {
    let num = Number($event.target.id)
    this.togglecomment[num] = !this.togglecomment[num]
  }
  
  rate(review){
    fetch('/DiemApi/User/LeaveReview',{
      method : 'post',
      body: JSON.stringify(review),
      headers:{
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
      }
    }
    ).then(()=>{
      this.updateLoggedUser()
      this.togglecomment = new Array(50).fill(false);
    })
   
  }
  

  update(event){
    fetch('/DiemApi/User/GetLogged',
    {
      headers:{
        'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
      }
    }
    ).then(res=> res.json()).then(
      user => {sessionStorage.setItem("LoggedUser",JSON.stringify(user)); this.ngOnInit()}
    )
  }
}
