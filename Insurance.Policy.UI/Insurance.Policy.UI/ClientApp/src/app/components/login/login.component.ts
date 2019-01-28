import { Component, OnInit } from "@angular/core";
import { UserLogin } from '../../models/user-login.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from './login.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: "login",
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [UserService]
})

export class LoginComponent implements OnInit {

  userLogin = new UserLogin();
  isLoading = false;
  invalidForm : boolean = true;
  form: FormGroup;

  constructor(private formBuilder : FormBuilder, 
    private userService : UserService,
    private router : Router,
    private snackBar : MatSnackBar) {

  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      UserName: ['', Validators.required],
      Password: ['', Validators.required]
    });

    this.form.valueChanges.subscribe(data => {
      this.invalidForm = this.form.invalid;
    });
  }

  logIn() {
    if(this.form.valid) {
      this.userLogin.UserName = this.form.controls.UserName.value;
      this.userLogin.Password = this.form.controls.Password.value;

      this.userService.getUser(this.userLogin).subscribe(data => {
        if(data){
          sessionStorage.setItem('UserName', data.UserName);
          this.router.navigate(['/home']);
        } else {
          this.snackBar.open('Usuario y/o contraseña incorrectos. Intenta nuevamente.', "Ok", {duration : 5000});
        }
      });

      this.isLoading = true;
    }
  }
}
