import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from "@angular/router";
import { AppSettings } from '../../models/appsettings.model';
import { UserLogin } from '../../models/user-login.model';

@Injectable()
export class UserService {

    readonly apiEndPoint : string = AppSettings.API_URL + "/user/";
    
    readonly httpOptions = {
        headers: new HttpHeaders({
        'Content-Type':  'application/json'
        })
    };

    constructor(private http: HttpClient, private router : Router) {
        
    }

    logout() {
        sessionStorage.clear();
        this.router.navigate(['/login'])
    }

    isLoggedIn() : boolean {
        if(sessionStorage.getItem('UserName')) {
            return true;
        }

        return false;
    }

    getUser(user : UserLogin) {
        const uri = this.apiEndPoint + "/getuser/";
        return this.http.post<UserLogin>(uri, JSON.stringify(user), this.httpOptions);
    }
}