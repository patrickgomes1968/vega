import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class VehicleService {
  makes: any[];
  obj: any = {};

  constructor(private http: Http) { }
  
  getMakes() {
    this.obj = this.http.get('/api/makes').map(res => res.json());
    console.log(this.obj);
    return this.http.get('/api/makes').map(res => res.json());
  }
  
  getFeatures() {
    return this.http.get('/api/features').map(res => res.json());
  }

}
