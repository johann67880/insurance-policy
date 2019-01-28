import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { AppSettings } from '../../models/appsettings.model';
import { CoverageType } from '../../models/coverageType.model';

@Injectable()
export class CoverageTypeService {

    readonly apiEndPoint : string = AppSettings.API_URL + "/coverage/";
    
    readonly httpOptions = {
        headers: new HttpHeaders({
        'Content-Type':  'application/json'
        })
    };

    coverages: CoverageType[] = [];

    constructor(private http: HttpClient) {
        
    }

    getAll() {
        const uri = this.apiEndPoint + "/getall/";
        return this.http.get<CoverageType[]>(uri, this.httpOptions);
    }

    update(coverage : CoverageType) {
        const uri = this.apiEndPoint + "/update/";
        return this.http.put<boolean>(uri, JSON.stringify(coverage), this.httpOptions);
    }

    save(coverage : CoverageType) {
        const uri = this.apiEndPoint + "/save/";
        return this.http.post<boolean>(uri, JSON.stringify(coverage), this.httpOptions);
    }

    delete(coverage : CoverageType) {
        const uri = this.apiEndPoint + "/delete/" + coverage.Id;
        return this.http.delete<boolean>(uri, this.httpOptions);
    }
}