import { Component, OnInit,EventEmitter, Input, Output, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'select-seats',
  templateUrl: './select-seats.component.html',
  styleUrls: ['./select-seats.component.css']
})
export class SelectSeatsComponent implements OnInit,OnChanges {
  @Input() seats:any;
  @Output() emitSeat: EventEmitter<any> = new EventEmitter();
  seatsFirst = new Array();
  seatsFirstNum: any;
  seatsSecond = new Array();
  seatsSecondNum:any;
  selectedSeats:any;
  toEmit = new Array();
  constructor() {
  
   }

  ngOnChanges(changes:any):void{
    console.log(changes)
     if( changes?.seats  && changes.seats.firstChange != true){
      this.seats = changes.seats.currentValue.split('')
     this.again()
     }
     
  }
  ngOnInit(): void {
    console.log(this.seats)
    this.seats = this.seats.split('')
    let j = 0;
    for(let i = 0;i < this.seats.length;i++){
      if(j < 4)
        this.seatsFirst.push(this.seats[i])
      if(j > 3)
        this.seatsSecond.push(this.seats[i])
      if(j == 7)
        j = 0;
      else j++;
    }

  }
  again(){
    let j = 0;
    this.seatsFirst = new Array()
    this.seatsSecond = new Array()
    for(let i = 0;i < this.seats.length;i++){
      if(j < 4)
        this.seatsFirst.push(this.seats[i])
      if(j > 3)
        this.seatsSecond.push(this.seats[i])
      if(j == 7)
        j = 0;
      else j++;
    }
  }
  SelectSeat(seatSelection:string,index:number,value:number ){
    if(value == 1)
    return;
    let seatNum 
    if(seatSelection == '1'){
      let rowNum = Math.floor(index /4);
      seatNum = index + rowNum * 4;
      console.log(seatNum)
    }
    else if(seatSelection == '2'){
      let rowNum = Math.floor(index /4);
      seatNum = index + rowNum * 4 + 4;
      console.log(seatNum)
    }
    if(value == 0){

      this.seats[seatNum] = "2"
      this.toEmit.push(seatNum.toString());
    }
    else if(value == 2){
      this.seats[seatNum] = "0"
      this.toEmit.splice(this.toEmit.indexOf(this.toEmit.find(s=> s.id == seatNum.toString()),1))
    }
     
     console.log(this.toEmit);
     this.again();
  }
  EmitSeats(){
    let totoEmit = {
      allSeats :this.seats,
      chosenSeats: this.toEmit
    }
    this.emitSeat.emit(totoEmit);
  }

}
