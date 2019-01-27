import { Component } from "@angular/core";
import { UserLogin } from '../../models/user-login.model';

@Component({
  selector: "app-login",
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent {

  userLogin = new UserLogin();
  isLoading = false;

  constructor() {

  }

  login() {
    this.isLoading = true;
  }
}
