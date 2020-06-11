import { Component,EventEmitter,Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'invite-users-view',
  templateUrl: './invite-users-view.component.html',
  styleUrls: ['./invite-users-view.component.css']
})
export class InviteUsersViewComponent implements OnInit {
  @Input() Users:any;
  @Output() Next = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }
  InviteUser(user:any){
    this.Next.emit(user)
  }

}
