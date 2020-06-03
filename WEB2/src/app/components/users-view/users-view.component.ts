import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-users-view',
  templateUrl: './users-view.component.html',
  styleUrls: ['./users-view.component.css']
})
export class UsersViewComponent implements OnInit {
 
  Users:any;
  CurrentUser:any;
  constructor() { }

  ngOnInit(): void {
    this.getUsers();
    this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
  }

  getUsers(){
    fetch('/DiemApi/User/GetAll').then(
      data =>{
        this.Users = data;
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
      user => sessionStorage.setItem("LoggedUser",JSON.stringify(user))
    )
  }

  DetermineRelationship(userName:string,relationship:string):boolean{
    if(relationship == "friends")
    {
      if(this.CurrentUser.Friends == null)
        return false;
      else return this.CurrentUser.Friends.some(friend => friend.Username == userName);
    }
    else if(relationship == "hasTheirRequest")
    {
      return this.Users.find(user => user.Username == userName).Friends.some(friend => friend.Username == this.CurrentUser.Username)
    }
  }

  HandleRequests(username:string,operation:string) {
    let toSend = {
      Username: username
    };
    fetch(`/DiemApi/User/${operation}Request`, {
     
      method: 'post',
      body: JSON.stringify(toSend),
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey"),
      },
    }).then(()=>{this.getUsers()});
  }

}
