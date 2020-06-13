import { Component, EventEmitter,OnInit, ViewChild, Output } from '@angular/core';
import { isGeneratedFile } from '@angular/compiler/src/aot/util';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  @ViewChild('repPass') repeatPass;
  @Output('imDone') done = new EventEmitter(); 
  Repeat_pass = ''
  Pass = ''
  constructor() { }

  ngOnInit(): void {
  }
  onChange(event:any){
    this[event.srcElement.name] = event.srcElement.value
   
 }
 onSubmit(event:any){
   if(this.Repeat_pass != this.Pass)
  {
    this.repeatPass.nativeElement.setCustomValidity("VERY VERY BAD JOB!");
  }
   let userForm = {
     Pass : this['Pass'] ,
     Username: this['Username'],
     Name: this['Name'],
     LastName :this['LastName'],
     Email:this['Email'],
     PhoneNumber:this['PhoneNumber']
   }
   fetch('/DiemApi/User/Register', {
     method: 'post',
     body: JSON.stringify(userForm),
     headers: {
         'Content-Type': 'application/json'
     }
 }).then(()=> 
 this.done.emit("great"))

  
  
 }
}
