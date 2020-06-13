import { Component,ViewChildren, OnInit, AfterViewChecked, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-avio-company-view',
  templateUrl: './avio-company-view.component.html',
  styleUrls: ['./avio-company-view.component.css']
})
export class AvioCompanyViewComponent implements OnInit,AfterViewChecked {
  @ViewChildren('ratestaywindow') toggleratewindow;
  averageRating = 0;
  AvioCompanyId:string;
  allReviews;
  AvioCompany:any;
  isAvioAdminViewing = false;
  CurrentUser:any;
  promo=''
  SpecialFlights;
  isDiscounting = false;
  toggleDiscount = new Array(50).fill(false);
  toggleReserving = new Array(50).fill(false);
  AddFlightHidden:boolean;
  private sub: any;
  constructor(private route: ActivatedRoute) { }

  ngAfterViewChecked(){
    if(this.toggleratewindow != undefined){
      this.toggleratewindow.toArray().forEach(ref => ref.nativeElement.addEventListener('click',this.RateMe))
    }
   }
   RateMe = ($event) =>  {
     if(this.isAvioAdminViewing){
      let num = Number($event.target.id)
      this.toggleDiscount[num] = !this.toggleDiscount[num]
     }
     else{
      let num = Number($event.target.id)
      this.toggleReserving[num] = !this.toggleReserving[num]
     }
   
  }
  ngOnInit(): void {
    this.AddFlightHidden = true;
    this.sub = this.route.params.subscribe(params => {
      this.AvioCompanyId = params['id'];
  });
  this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
  
  fetch(`DiemApi/AvioCompany/Get/${this.AvioCompanyId}`)
    .then(res=>res.json())
    .then(company => {
      this.AvioCompany = company;
      if(company.Owner.Username == this.CurrentUser.Username)
        this.isAvioAdminViewing = true
      this.SpecialFlights =  this.AvioCompany?.Flights.filter(u=> u.Seats.split('').includes('5'))
      this.allReviews = this.AvioCompany.Flights.flatMap(s=>s.Reservations).flatMap(s=> s.Review)
      this.allReviews.forEach( review => this.averageRating += review.Stars)
      
      console.log(this.allReviews)
    });
  }
  EditAvio(event:any,toEdit:string){
    if(toEdit == 'Promo_description'){

      console.log(event.srcElement.value.replace('"',""));
      
    }

    let toSend = 
    {
      [toEdit] :  event.srcElement.value
    }
    fetch(`DiemApi/AvioCompany/Edit/${this.AvioCompany.Id}`, {
      method: 'post',
      body: JSON.stringify(toSend),
      headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
      }
  })
  }
  FinishDiscounting($event){
    this.toggleDiscount = new Array(50).fill(false)
  }
  ReserveAndClose($event){
    this.toggleReserving = new Array(50).fill(false)
  }
  AddFlightViewToggle(){
    this.AddFlightHidden = ! this.AddFlightHidden;
  }
  reload(){
    this.ngOnInit();
  }
}
