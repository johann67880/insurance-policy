import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { AppSettings } from '../../models/appsettings.model';
import { RiskType } from '../../models/riskType.model';

@Injectable()
export class RiskTypeService {

    readonly apiEndPoint : string = AppSettings.API_URL + "/risk/";
    
    readonly httpOptions = {
        headers: new HttpHeaders({
        'Content-Type':  'application/json'
        })
    };

    risks: RiskType[] = [];

    constructor(private http: HttpClient) {
        
    }

    getAll() {
        const uri = this.apiEndPoint + "/getall/";
        return this.http.get<RiskType[]>(uri, this.httpOptions);
    }

    update(risk : RiskType) {
        const uri = this.apiEndPoint + "/update/";
        return this.http.put<boolean>(uri, JSON.stringify(risk), this.httpOptions);
    }

    save(risk : RiskType) {
        const uri = this.apiEndPoint + "/save/";
        return this.http.post<boolean>(uri, JSON.stringify(risk), this.httpOptions);
    }

    delete(risk : RiskType) {
        const uri = this.apiEndPoint + "/delete/" + risk.Id;
        return this.http.delete<boolean>(uri, this.httpOptions);
    }
}