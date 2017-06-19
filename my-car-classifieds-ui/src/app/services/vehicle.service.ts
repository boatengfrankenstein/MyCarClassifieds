import { Injectable } from '@angular/core';
import {Http} from "@angular/http";
import "rxjs/add/operator/map";

@Injectable()
export class VehicleService {
  private apiUrl = 'http://localhost:52979/api/';

  constructor(private http: Http) { }

  getFeatures(){
    return this.http.get(this.apiUrl + 'features')
      .map(res=>res.json());
  }

  getMakes(){
    return this.http.get(this.apiUrl + 'makes')
      .map(res=>res.json());
  }

}
