import {
  Component,
  ViewChild,
  OnInit,
  EventEmitter,
  AfterViewInit,
  Input,
  Output,
  ViewEncapsulation,
} from '@angular/core';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css'],
})
export class LogInComponent implements OnInit {
  @Output() setCookie: EventEmitter<any> = new EventEmitter();
  cookie: JSON;
  constructor() {}

  ngOnInit(): void {}
  onChange(event: any) {
    this[event.srcElement.name] = event.srcElement.value;
  }
  onSubmit(event: any) {
    console.log(this);
    let credentials = {
      Username: this['Username'],
      Password: this['Password'],
    };

    fetch('/DiemApi/User/SignIn', {
      method: 'post',
      body: JSON.stringify(credentials),
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then((res) => res.json())
      .then((UserGift) => {
        console.log(UserGift)
        sessionStorage.setItem("tokenKey",UserGift.Token)
        sessionStorage.setItem("LoggedUser",JSON.stringify(UserGift.User))
        console.log(sessionStorage)
      }).then(

      );
  }
}
