import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-my-user',
  templateUrl: './my-user.component.html',
  styleUrls: ['./my-user.component.css']
})
export class MyUserComponent implements OnInit {

  MyUser : any;
  AllUsers: any;
  constructor() { }

  ngOnInit(): void {
    this.MyUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
  }
  afterEdit(){
    fetch('/DiemApi/User/GetLogged',
    {
      headers:{
        'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
      }
    }
    ).then(res=> res.json()).then(
      user => {sessionStorage.setItem("LoggedUser",JSON.stringify(user)); this.ngOnInit()}
    )
  }

}
