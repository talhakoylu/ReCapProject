import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/car';
import { CarImage } from 'src/app/models/car-image';
import { CarImageService } from 'src/app/services/car-image.service';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {
  cars:Car[] = [];
  images:CarImage[] = [];
  constructor(private carService : CarService, private activatedRoute : ActivatedRoute, private carImageService : CarImageService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["carId"]){
        this.getCarByIdDetail(params["carId"]);
        this.getImagesByCarId(params["carId"]);
      }
    })
  }

  getCarByIdDetail(id:number){
    this.carService.getCarByIdDetail(id).subscribe(response => {
      this.cars = response.data;
    })
  }

  getImagesByCarId(id:number){
    this.carImageService.getCarImagesById(id).subscribe(response=>{
      this.images = response.data;
      console.log(response);
      
    })
  }
  
}
