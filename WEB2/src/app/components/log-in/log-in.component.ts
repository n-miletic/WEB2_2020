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
import { UserService } from 'src/app/user-service.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css'],
})
export class LogInComponent implements OnInit {
  @Output() imDone: EventEmitter<any> = new EventEmitter();
  constructor(private UserService:UserService) {}

  ngOnInit(): void {}
  onChange(event: any) {
    this[event.srcElement.name] = event.srcElement.value;
  }
  onSubmit(event: any) {
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
      .then((res) =>{
        if(res.status != 200)
          return Promise.reject("Bad")
       return  res.json()
      })
      .then((UserGift) => {
        
        sessionStorage.setItem("tokenKey", UserGift)
        this.UserService.updateUser();
        this.imDone.emit("BYE")

      })
  }
}
