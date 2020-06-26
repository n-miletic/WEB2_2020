import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  CurrentUser: any;
  
  constructor() {
    this.updateUser()
   }
  updateUser(){
    fetch('/DiemApi/User/GetLogged',
    {
      headers:{
        'Authorization': 'Bearer ' + sessionStorage.getItem("tokenKey")
      }
    }
    ).then((res)=> {
      if(res.status != 200)
      {
        return Promise.reject("error");
      }
      return res.json()
    }).then(
      user =>  this.CurrentUser = user
    )
  }
  logOut(){
    this.CurrentUser = undefined;
    sessionStorage.clear();
  }
}
