import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'userlist',
  templateUrl: './users-view.component.html',
  styleUrls: ['./users-view.component.css']
})
export class UsersViewComponent implements OnInit {
 @Input() Users:any;
 @Input() CurrentUser:any;
 @Input() TableName:string;
  constructor() { }

  ngOnInit(): void {
  }

  DetermineRelationship(userName:string,relationship:string):boolean{
    if(relationship == "friends")
    {
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
    })
  }

}
