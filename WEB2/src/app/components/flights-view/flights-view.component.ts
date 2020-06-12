import { Component,ChangeDetectorRef,EventEmitter,Input, OnInit, Output } from '@angular/core';


@Component({
  selector: 'add-flight',
  templateUrl: './flights-view.component.html',
  styleUrls: ['./flights-view.component.css']
})
export class FlightsViewComponent implements OnInit {
  classType = ['Select class','Economy', 'Bussiness','First class'];
  numTransits= [{label:'First',shown:true,value:null}, {label:'Second',shown:false,value:null},{label:'Third',shown:false,value:null},{label:'Fourth',shown:false,value:null},{label:'Fifth',shown:false,value:null}];
  // AllFlights;
  @Input() AvioCompanyId: string;
  @Output() reload: EventEmitter<any> = new EventEmitter()
  constructor(private ref: ChangeDetectorRef) { }
  ngOnInit(): void {
    // fetch("/DiemApi/Flights")
    // .then(data => {
    //   this.AllFlights = data;
    // })
  }

  getAddress = (place:any) => {
    if(place[0].includes('transit')){
      this.numTransits[parseInt(place[0].slice(-1)) + 1].shown = true
      this.numTransits[parseInt(place[0].slice(-1)) + 1].value = place[1].formatted_address
      this.ref.detectChanges();
      return;
    }
    
   this[place[0]] = place[1]
   
  }
  onChange(event:any){
     this[event.srcElement.name] = event.srcElement.value.replace(/ /g,'')
    
  }
  wipe(){
    this['to'] = null;
    this['from'] = null
    this['datum_poletanja'] = null;
    this['datum_sletanja'] = null;
    this['price'] = null
    this['FlightClass'] = null
    this['seats'] = null;
    this.numTransits= [{label:'First',shown:true,value:null}, {label:'Second',shown:false,value:null},{label:'Third',shown:false,value:null},{label:'Fourth',shown:false,value:null},{label:'Fifth',shown:false,value:null}];
  }
  onSubmit(event:any){
    
    let flightForm = {
      toLocation : this['to'].formatted_address ,
      fromLocation: this['from'].formatted_address,
      Flight_Departure_Time: this['datum_poletanja'],
      Flight_Arrival_Time :this['datum_sletanja'],
      price:this['price'],
      FlightClass : this['FlightClass'],
      transits:this.numTransits.map(u=> u.value).filter(u=> u!= null),
      seats : this['seats']
    }
    console.log(flightForm)
    console.log(this)
    fetch(`/DiemApi/AvioCompany/${this.AvioCompanyId}/Flights/Add`, {
      method: 'post',
      body: JSON.stringify(flightForm),
      headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey"),
      }
  }).then(()=> {this.reload.emit("reload"); this.wipe()})
   
   
  }

}
