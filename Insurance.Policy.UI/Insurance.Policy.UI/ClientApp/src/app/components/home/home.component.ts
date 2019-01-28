import { Component, OnInit } from '@angular/core';
import {UserService} from '../login/login.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [UserService]
})
export class HomeComponent implements OnInit {

  constructor(private userService : UserService) { }

  ngOnInit() {
  }

  logOut() {
    this.userService.logout();
  }

}
