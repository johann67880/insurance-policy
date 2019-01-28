import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { AppSettings } from '../../models/appsettings.model';
import { Insurance } from '../../models/insurance.model';

@Injectable()
export class InsuranceService {

    readonly apiEndPoint : string = AppSettings.API_URL + "/insurance/";
    
    readonly httpOptions = {
        headers: new HttpHeaders({
        'Content-Type':  'application/json'
        })
    };

    insurances: Insurance[] = [];

    constructor(private http: HttpClient) {
        
    }

    getAll() {
        const uri = this.apiEndPoint + "/getall/";
        return this.http.get<Insurance[]>(uri, this.httpOptions);
    }

    update(insurance : Insurance) {
        const uri = this.apiEndPoint + "/update/";
        return this.http.put<boolean>(uri, JSON.stringify(insurance), this.httpOptions);
    }

    save(insurance : Insurance) {
        const uri = this.apiEndPoint + "/save/";
        return this.http.post<boolean>(uri, JSON.stringify(insurance), this.httpOptions);
    }

    delete(insurance : Insurance) {
        const uri = this.apiEndPoint + "/delete/" + insurance.Id;
        return this.http.delete<boolean>(uri, this.httpOptions);
    }
}