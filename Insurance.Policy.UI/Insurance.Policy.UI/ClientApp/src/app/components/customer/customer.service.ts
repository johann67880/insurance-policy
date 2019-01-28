import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { AppSettings } from '../../models/appsettings.model';
import { Customer } from '../../models/customer.model';

@Injectable()
export class CustomerService {

    readonly apiEndPoint : string = AppSettings.API_URL + "/customer/";
    
    readonly httpOptions = {
        headers: new HttpHeaders({
        'Content-Type':  'application/json'
        })
    };

    insurances: Customer[] = [];

    constructor(private http: HttpClient) {
        
    }

    getAll() {
        const uri = this.apiEndPoint + "/getall/";
        return this.http.get<Customer[]>(uri, this.httpOptions);
    }

    update(customer : Customer) {
        const uri = this.apiEndPoint + "/update/";
        return this.http.put<boolean>(uri, JSON.stringify(customer), this.httpOptions);
    }

    save(customer : Customer) {
        const uri = this.apiEndPoint + "/save/";
        return this.http.post<boolean>(uri, JSON.stringify(customer), this.httpOptions);
    }

    delete(customer : Customer) {
        const uri = this.apiEndPoint + "/delete/" + customer.Id;
        return this.http.delete<boolean>(uri, this.httpOptions);
    }
}