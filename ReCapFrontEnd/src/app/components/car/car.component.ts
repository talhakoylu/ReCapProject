import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Car } from 'src/app/models/car';
import { CarImage } from 'src/app/models/car-image';
import { CarImageService } from 'src/app/services/car-image.service';
import { CarService } from 'src/app/services/car.service';


@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {
  cars: Car[] = [];
  carImages: CarImage[] = [];
  dataLoaded = false;
  currentCar: Car;
  constructor(private carService: CarService, private activatedRoute: ActivatedRoute, private carImageService: CarImageService,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      if (params['brandId'] && params['colorId']) {
        this.getCarsByColorAndBrand(params['brandId'], params['colorId']);
      }
      else if (params['colorId']) {
        this.getCarsByColor(params["colorId"]);
      } else if (params['brandId']) {
        this.getCarsByBrand(params["brandId"]);
      }
      else {
        this.getCars();
      }
    })
  }

  getCars() {
    this.carService.getCars().subscribe(response => {
      this.cars = response.data;
      this.dataLoaded = true;
      this.setCoverImage(this.cars);
    });
  }

  getCarsByBrand(brandId: number) {
    this.carService.getCarsByBrand(brandId).subscribe(response => {
      this.cars = response.data;
      this.dataLoaded = true;
      this.setCoverImage(this.cars);
    });
  }

  getCarsByColor(colorId: number) {
    this.carService.getCarsByColor(colorId).subscribe(response => {
      this.cars = response.data;
      this.dataLoaded = true;
      this.setCoverImage(this.cars);
    })
  }

  setCurrentCar(car: Car) {
    this.currentCar = car;
  }

  getCarImages() {
    this.carImageService.getCarImages().subscribe(response => {
      this.carImages = response.data;
    })
  }

  setCoverImage(carList: Car[]) {
    carList.forEach(item => {
      this.carImageService.getCarImagesById(item.carId).subscribe(response => {
        item.imagePath = "http://localhost:4200/" + response.data[0].imagePath;
      })
    })
  }

  getCarsByColorAndBrand(brandId: number, colorId: number) {
    this.carService.getCarsByColorAndBrand(brandId, colorId).subscribe(response => {
      this.cars = response.data;
      this.setCoverImage(this.cars);
      this.dataLoaded = true;
      if (this.cars.length == 0) {
        this.toastrService.warning("Bu değerlere sahip bir araç bulunmuyor.", "Hata");
      }
    })
  }
}
