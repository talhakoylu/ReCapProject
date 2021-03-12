import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarResponseModel } from '../models/carResponseModel';
@Injectable({
  providedIn: 'root'
})
export class CarService {
  apiUrl = "https://localhost:44327/api/cars/getalldetail";
  constructor(private httpClient:HttpClient) { }

  getCars() : Observable<CarResponseModel>{
    return this.httpClient.get<CarResponseModel>(this.apiUrl);
  }
}
