import {ElementRef, Component,Input,EventEmitter, OnInit, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'add-avio-company',
  templateUrl: './add-avio-company.component.html',
  styleUrls: ['./add-avio-company.component.css']
})
export class AddAvioCompanyComponent implements OnInit {
  @Input() ownerUsername: string;
  @ViewChild('Logoref') Logoref : ElementRef;
  @Output() imDone: EventEmitter<any> = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }

  getAddress(place:any){
   this[place[0]] = place[1]
  }
  onChange(event:any){
    if(event.srcElement.name != "Logo")
      this[event.srcElement.name] = event.srcElement.value;
  }
  onSubmit=(event:any)=>{
    
    var pic = this.Logoref.nativeElement.files[0]
    var reader
    
       reader = new FileReader();
      reader.onloadend = () => {
          let companyForm = {
            Name : this['Name'],
            Address: this['Address'].formatted_address,
            Promo_description: this['Promo_description'],
            Logo :reader.result.replace(/^data:.+;base64,/, ''),
            OwnerUsername:this.ownerUsername
          }
          fetch('/DiemApi/Admin/AddCompany', {
            method: 'post',
            body: JSON.stringify(companyForm),
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
            }
        })
          this.imDone.emit("BYE")
        }
        reader.readAsDataURL(pic)
   
   
  }

}
