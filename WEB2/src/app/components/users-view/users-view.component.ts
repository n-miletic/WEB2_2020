import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'users-view',
  templateUrl: './users-view.component.html',
  styleUrls: ['./users-view.component.css']
})
export class UsersViewComponent implements OnInit {
 
  Users:any;
  CurrentUser:any;
  constructor() { }

  ngOnInit(): void {

    this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
    this.getUsers();
  }

  getUsers(){
    if (this.CurrentUser == null)
    fetch('/DiemApi/User/GetAll').then(
      data => data.json()
    ).then(
      users => {
        this.Users = users
        console.log(users)
      }
      )
      else
      fetch('/DiemApi/User/GetAll/Logged',{
        headers:{
          'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
        }
      }).then(
        data => data.json()
      ).then(
        users => {
          this.Users = users
          console.log(users)
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

  DetermineRelationship(userName:string,relationship:string):boolean{
    if(relationship == "friends")
    {
      console.log(this.CurrentUser)
      return this.CurrentUser.Friends.map(user => user.Username).includes(userName);
    }
    else if(relationship == "hasTheirRequest")
    {
      return   this.CurrentUser.PendingFriends.map(user => user.Username).includes(userName);
    }
    else if(relationship == "didTheySend")
    {
      return  this.CurrentUser.FriendRequestsSent.map(user => user.Username).includes(userName);
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
    }).then(()=>{this.getUsers(); this.updateLoggedUser()});
  }

}
