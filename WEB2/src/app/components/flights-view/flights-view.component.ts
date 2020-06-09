import { Component,EventEmitter,Input, OnInit, Output } from '@angular/core';


@Component({
  selector: 'add-flight',
  templateUrl: './flights-view.component.html',
  styleUrls: ['./flights-view.component.css']
})
export class FlightsViewComponent implements OnInit {

  // AllFlights;
  @Input() AvioCompanyId: string;
  @Output() reload: EventEmitter<any> = new EventEmitter()
  constructor() { }
  ngOnInit(): void {
    // fetch("/DiemApi/Flights")
    // .then(data => {
    //   this.AllFlights = data;
    // })
  }

  getAddress(place:any){
   this[place[0]] = place[1]
  }
  onChange(event:any){
     this[event.srcElement.name] = event.srcElement.value
    
  }
  onSubmit(event:any){
    let flightForm = {
      toLocation : this['to'].formatted_address ,
      fromLocation: this['from'].formatted_address,
      Flight_Departure_Time: this['datum_poletanja'],
      Flight_Arrival_Time :this['datum_sletanja'],
      price:this['cena']
    }

    fetch(`/DiemApi/AvioCompany/${this.AvioCompanyId}/Flights/Add`, {
      method: 'post',
      body: JSON.stringify(flightForm),
      headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey"),
      }
  }).then(()=> this.reload.emit("reload"))
   
   
  }

}
