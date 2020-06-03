import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  onChange(event:any){
    this[event.srcElement.name] = event.srcElement.value
   
 }
 onSubmit(event:any){
   let userForm = {
     Pass : this['Pass'] ,
     Username: this['Username'],
     Name: this['Name'],
     LastName :this['LastName'],
     Email:this['Email'],
     PhoneNumber:this['PhoneNumber']
   }
   console.log(userForm)
   fetch('/DiemApi/User/Register', {
     method: 'post',
     body: JSON.stringify(userForm),
     headers: {
         'Content-Type': 'application/json'
     }
 })
   console.log(userForm)
  
  
 }
}
