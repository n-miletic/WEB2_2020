import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-avio-company-view',
  templateUrl: './avio-company-view.component.html',
  styleUrls: ['./avio-company-view.component.css']
})
export class AvioCompanyViewComponent implements OnInit {
  AvioCompanyId:string;
  AvioCompany:any;
  CurrentUser:any;
  AddFlightHidden:boolean;
  private sub: any;
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.AddFlightHidden = true;
    this.sub = this.route.params.subscribe(params => {
      this.AvioCompanyId = params['id'];
  });
  this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
  fetch(`DiemApi/AvioCompany/Get/${this.AvioCompanyId}`)
    .then(res=>res.json())
    .then(company => {this.AvioCompany = company;console.log(company)});
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
    console.log(toSend);
  }
  AddFlightViewToggle(){
    this.AddFlightHidden = ! this.AddFlightHidden;
  }
  reload(){
    this.ngOnInit();
  }
}
