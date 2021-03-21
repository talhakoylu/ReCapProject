import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Rental } from '../models/rental';
import { RentalPost } from '../models/rentalPost';
import { ResponseModel } from '../models/responseModel';
import { SingleResponseModel } from '../models/singleResponseModel';

@Injectable({
  providedIn: 'root'
})
export class RentalService {
  apiUrl = "https://localhost:44327/api/";

  constructor(private httpClient: HttpClient) { }

  getRentals(): Observable<ListResponseModel<Rental>> {
    let newPath = this.apiUrl + "rentals/getalldetail";
    return this.httpClient.get<ListResponseModel<Rental>>(newPath);
  }

  getRentalByCarId(carId:number) : Observable<SingleResponseModel<Rental>>{
    let newPath = this.apiUrl + "rentals/getbycarid?id="+carId;
    return this.httpClient.get<SingleResponseModel<Rental>>(newPath);
  }

  postRentAdd(rentalPost: RentalPost) : Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl + "rentals/add", rentalPost);
  }
}
