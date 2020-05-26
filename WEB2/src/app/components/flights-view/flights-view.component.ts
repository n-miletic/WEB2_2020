import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'flights-view',
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
    })
  }

  getAddress(place:any){
   this[place[0]] = place[1]
  }
  onChange(event:any){
     this[event.srcElement.name] = event.srcElement.value
    
  }
  onSubmit(event:any){
    console.log(this)
    let flightForm = {
      toLocation : this['to'].formatted_address ,
      fromLocation: this['from'].formatted_address,
      Flight_Departure_Time: this['datum_poletanja'],
      Flight_Arrival_Time :this['datum_sletanja'],
      price:this['cena']
    }

    fetch('/DiemApi/Flights/Add', {
      method: 'post',
      body: JSON.stringify(flightForm),
      headers: {
          'Content-Type': 'application/json'
      }
  })
    console.log(flightForm)
   
   
  }

}
