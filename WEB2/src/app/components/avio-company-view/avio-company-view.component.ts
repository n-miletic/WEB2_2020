import { Component,ViewChildren, OnInit, AfterViewChecked } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-avio-company-view',
  templateUrl: './avio-company-view.component.html',
  styleUrls: ['./avio-company-view.component.css']
})
export class AvioCompanyViewComponent implements OnInit,AfterViewChecked {
  @ViewChildren('ratestaywindow') toggleratewindow;
  AvioCompanyId:string;
  AvioCompany:any;
  CurrentUser:any;
  isDiscounting = false;
  toggleDiscount = new Array(50).fill(false);
  AddFlightHidden:boolean;
  private sub: any;
  constructor(private route: ActivatedRoute) { }

  ngAfterViewChecked(){
    if(this.toggleratewindow != undefined){
      this.toggleratewindow.toArray().forEach(ref => ref.nativeElement.addEventListener('click',this.RateMe))
    }
   }
   RateMe = ($event) =>  {
    let num = Number($event.target.id)
    this.toggleDiscount[num] = !this.toggleDiscount[num]
  }
  ngOnInit(): void {
    this.AddFlightHidden = true;
    this.sub = this.route.params.subscribe(params => {
      this.AvioCompanyId = params['id'];
  });
  this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
  fetch(`DiemApi/AvioCompany/Get/${this.AvioCompanyId}`)
    .then(res=>res.json())
    .then(company => {this.AvioCompany = company});
  }
  EditAvio(event:any,toEdit:string){
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
  AddFlightViewToggle(){
    this.AddFlightHidden = ! this.AddFlightHidden;
  }
  reload(){
    this.ngOnInit();
  }
}
