import { Component,Input,Output,EventEmitter, OnInit } from '@angular/core';

@Component({
  selector: 'discount-div-avio',
  templateUrl: './discount-div-avio.component.html',
  styleUrls: ['./discount-div-avio.component.css']
})
export class DiscountDivAvioComponent implements OnInit {

  @Input() Flight:any;
  Seats:any;
  CurrentUser:any;
  new_price = 0
  doneSelectingSeats= false;
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
    this.SelectedSeats = null;
    
    this.alertClose.emit();
  }
  NextStep(seats:any){
    this.doneSelectingSeats = true;
    this.SelectedSeats = seats.chosenSeats;
    
  }
   
  SendDiscount(){
     this.SelectedSeats.forEach((u,index)=> this.SelectedSeats[index] = parseInt(u))
    let toSend;
      toSend = {
        seatsToDiscount : this.SelectedSeats,
        slashedPrice:this.new_price,
        FlightId : this.Flight.Id
      }
      console.log(toSend)
      fetch('/DiemApi/AdminAvio/Flight/AddDiscount', {
        method: 'post',
        body: JSON.stringify(toSend),
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
        }
    }).then(()=> this.close())
    
  }
  

}
