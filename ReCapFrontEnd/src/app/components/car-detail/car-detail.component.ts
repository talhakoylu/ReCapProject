import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Car } from 'src/app/models/car';
import { CarImage } from 'src/app/models/car-image';
import { Rental } from 'src/app/models/rental';
import { CarImageService } from 'src/app/services/car-image.service';
import { CarService } from 'src/app/services/car.service';
import { RentalService } from 'src/app/services/rental.service';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {
  cars: Car[] = [];
  images: CarImage[] = [];
  rentalCar: Rental;
  isRentBefore: Boolean = false;
  constructor(private carService: CarService, private activatedRoute: ActivatedRoute, private carImageService: CarImageService,
    private rentalService: RentalService, private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      if (params["carId"]) {
        this.getCarByIdDetail(params["carId"]);
        this.getImagesByCarId(params["carId"]);
        this.getRentalByCarId(params["carId"]);
      }
    })
  }

  getCarByIdDetail(id: number) {
    this.carService.getCarByIdDetail(id).subscribe(response => {
      this.cars = response.data;
    })
  }

  getImagesByCarId(id: number) {
    this.carImageService.getCarImagesById(id).subscribe(response => {
      this.images = response.data;

    })
  }

  getRentalByCarId(id: number) {
    this.rentalService.getRentalByCarId(id).subscribe(response => {
      if (response.data == null) {
        this.isRentBefore = false;
      } else {
        this.rentalCar = response.data;
        this.isRentBefore = true;
      }
    })
  }

  checkAvailability() {

    if (!this.isRentBefore) {
      this.toastrService.success("araç kiralanabilir", "Araç Boşta");
      return true;
    } else {
      return this.rentedBeforeCarCheck();
    }
  }

  rentedBeforeCarCheck() {
    var now = new Date();
    now.setHours(0, 0, 0, 0);
    let today = formatDate(now, 'yyyy/MM/dd', 'en');
    let oldDate = formatDate(this.rentalCar.returnDate, 'yyyy/MM/dd', 'en');

    if (this.rentalCar.returnDate == null) {
      this.toastrService.warning("Araç kullanımdadır ve dönüş tarihi henüz belli değildir.", "Hata");
      return false;
    } else if (oldDate > today) {
      this.toastrService.warning("Bu araç kullanımdadır. Tahmini dönüş zamanı " + oldDate, "Hata");
      return false;
    }
    else {
      this.toastrService.success("araç kiralanabilir", "Araç Boşta");
      return true;
    }
  }
}
