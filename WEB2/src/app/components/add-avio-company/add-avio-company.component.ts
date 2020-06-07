import { Component,Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-avio-company',
  templateUrl: './add-avio-company.component.html',
  styleUrls: ['./add-avio-company.component.css']
})
export class AddAvioCompanyComponent implements OnInit {
  @Input() ownerUsername: string;
  constructor() { }

  ngOnInit(): void {
  }

  getAddress(place:any){
   this[place[0]] = place[1]
  }
  onChange(event:any){
     this[event.srcElement.name] = event.srcElement.value
    
  }
  onSubmit(event:any){
    console.log(this)
    let companyForm = {
      Name : this['Name'],
      Address: this['Address'],
      Promo_description: this['Promo_description'],
      Logo :this['Logo'],
      OwnerUsername:this.ownerUsername
    }

    fetch('/DiemApi/Admin/AddAvioCompany', {
      method: 'post',
      body: JSON.stringify(companyForm),
      headers: {
          'Content-Type': 'application/json'
      }
  })
    console.log(companyForm)
   
   
  }

}
