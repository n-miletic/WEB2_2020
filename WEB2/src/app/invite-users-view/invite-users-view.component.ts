import { Component,EventEmitter,Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-invite-users-view',
  templateUrl: './invite-users-view.component.html',
  styleUrls: ['./invite-users-view.component.css']
})
export class InviteUsersViewComponent implements OnInit {
  @Input() Users:any;
  @Output() heresuruser = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }
  InviteUser(username:string){
    this.heresuruser.emit(username)
  }

}
