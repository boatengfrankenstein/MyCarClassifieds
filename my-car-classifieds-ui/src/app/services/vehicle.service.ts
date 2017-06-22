import { Injectable } from '@angular/core';
import {Http} from "@angular/http";
import "rxjs/add/operator/map";

@Injectable()
export class VehicleService {
  private apiUrl = 'http://localhost:50640/api/';

  constructor(private http: Http) { }

  getFeatures(){
    return this.http.get(this.apiUrl + 'features')
      .map(res=>res.json());
  }

  getMakes(){
    return this.http.get(this.apiUrl + 'makes')
      .map(res=>res.json());
  }

  postNewVehicle(vehicle){
    return this.http.post(this.apiUrl + 'vehicles',vehicle)
      .map(res => res.json());
  }

}
