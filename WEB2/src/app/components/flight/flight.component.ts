import { Component,ChangeDetectorRef, OnInit } from '@angular/core';
import { Flight } from 'src/app/entities/flight/flight'
import { getLocaleDateTimeFormat } from '@angular/common';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css']
})
export class FlightComponent implements OnInit {
  searchResult
  transitsActive = false;
  priceActive = false;
  durationActive = false;
  ShowFlights:any;
  CurrentUser ;
  Reserving = false;
  filterWinActive = true; //PROMENI
  seats:string;
  Flights:any;
  tripType = ['Return', 'One Way'];
  cabinClass = ['Economy', 'Premium Economy', 'Business Class', 'First Class'];
  seatNums = [ 'How many seats do you need?',1,2,3,4,5,6,7,8,9,10];
  FlightClasses = ['Select class','Economy', 'Bussiness','First class'];
 

  fromprice = 0
  toprice = 0
  fromhours = 0
  tohours = 0

  seatSearch;
  constructor(private ref:ChangeDetectorRef) { }

  ngOnInit(): void {
    
    // this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
    //  fetch("/DiemApi/Flights")
    // .then(data => data.json())
    // .then(flights => {this.Flights = flights;})
  }
  transitsToggle(){
    this.transitsActive = !this.transitsActive;
    this.filterBaby();
  }
  OpenReserveWindow(){
    this.Reserving = true;
  }
  getAddress(place:any){
    this[place[0]] = place[1]
   }
  ReserveAndClose(getReservationDetails:any){
    this.Reserving = false;
    //Reload
  }

  onChange(event:any){
      this[event.srcElement.name] = event.srcElement.value.replace(/ /g,'')
   
 }
 
 filter(event:any){
   console.log("HEJ GURL")
  this[event.srcElement.name] = event.srcElement.value.replace(/ /g,'')
  if(this.fromprice != 0 || this.toprice != 0)
        this.priceActive = true;
      else
        this.priceActive = false;
      if(this.fromhours != 0 || this.tohours != 0)
        this.durationActive = true;
      else this.durationActive = false;
  this.filterBaby();
}
filterBaby(){
  let toShow = this.Flights
  if(!isNaN(this.fromprice) )
    toShow = this.Flights.filter(u=> u.Price >this.fromprice)
  if(!isNaN(this.toprice) )
    toShow = toShow.filter(u=>u.Price < this.toprice)
  if(!isNaN(this.fromhours) )
    toShow = toShow.filter(u=> {console.log(u.Flight_Duration);console.log(new Date(u.FlightDuration))} ) // THIS IS STUPID BUT WHATEVER
  if(!isNaN(this.tohours) )

  this.ShowFlights = toShow;
}
 onSubmit(event:any){
  
   let flightForm = {
    To_Location : this['to'].formatted_address ,
     From_Location: this['from'].formatted_address,
     Flight_Departure_Time: this['datum_poletanja'],
     Flight_Arrival_Time :this['datum_sletanja'],
     Free_seats : this['seatSearch'],
     Flight_class:this['FlightClass']
   }
   console.log(flightForm)
   fetch(`/DiemApi/Flights/SearchFlights`, {
     method: 'post',
     body: JSON.stringify(flightForm),
     headers: {
         'Content-Type': 'application/json'
        // 'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey"),
     }
 }).then( res => res.json()).then(searchRes => {this.Flights = searchRes;this.ShowFlights = searchRes;})
  
  
 }
  

}
