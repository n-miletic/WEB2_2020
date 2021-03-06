import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'admin-users-view',
  templateUrl: './admin-users-view.component.html',
  styleUrls: ['./admin-users-view.component.css']
})
export class AdminUsersViewComponent implements OnInit {

  Users:any;
  CurrentUser:any;
  AddCompanyViewHidden:boolean;
  SelectedUser:string;
  constructor() { }

  ngOnInit(): void {

    this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
    this.AddCompanyViewHidden = true;
    this.getUsers();
  }
  getUsers(){
      fetch('/DiemApi/User/GetHardcoreUsers',{
        headers:{
          'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
        }})
        .then(
        data => data.json()
      ).then(
        users => {
          this.Users = users
        }
        )

  }

  updateLoggedUser(){
    fetch('/DiemApi/User/GetLogged',
    {
      headers:{
        'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
      }
    }
    ).then(res=> res.json()).then(
      user => {sessionStorage.setItem("LoggedUser",JSON.stringify(user)); this.CurrentUser = user}
    )
  }


  Promote(username:string,role:string) {
    let toSend = {
      Username: username,
      Role:role
    };
    fetch(`/DiemApi/Admin/PromoteUser`, {
     
      method: 'post',
      body: JSON.stringify(toSend),
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey"),
      },
    }).then(()=>{this.getUsers(); this.updateLoggedUser()});
  }
  AddCompany(username:string){
    this.SelectedUser = username;
    this.AddCompanyViewHidden = false;
  }

  ViewCompany(username:string){
    //redirect
  }
  close(event:any){
    this.AddCompanyViewHidden = true;
  }



}
