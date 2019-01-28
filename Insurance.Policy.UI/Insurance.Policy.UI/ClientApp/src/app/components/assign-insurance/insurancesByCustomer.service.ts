import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { AppSettings } from '../../models/appsettings.model';
import { InsurancesByCustomer } from '../../models/insurancesByCustomer.model';

@Injectable()
export class InsuranceByCustomerService {

    readonly apiEndPoint : string = AppSettings.API_URL + "/assign/";
    
    readonly httpOptions = {
        headers: new HttpHeaders({
        'Content-Type':  'application/json'
        })
    };

    assignations: InsurancesByCustomer[] = [];

    constructor(private http: HttpClient) {
        
    }

    getAssignations(customerId : number) {
        const uri = this.apiEndPoint + "/get/" + customerId;
        return this.http.get<InsurancesByCustomer[]>(uri, this.httpOptions);
    }

    save(assignations : InsurancesByCustomer[]) {
        const uri = this.apiEndPoint + "/save/";
        return this.http.post<boolean>(uri, JSON.stringify(assignations), this.httpOptions);
    }
}