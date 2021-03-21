import { Component, OnInit } from '@angular/core';
import { Brand } from 'src/app/models/brand';
import { Color } from 'src/app/models/color';
import { BrandService } from 'src/app/services/brand.service';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-car-filter',
  templateUrl: './car-filter.component.html',
  styleUrls: ['./car-filter.component.css']
})
export class CarFilterComponent implements OnInit {

  colors: Color[] = [];
  brands: Brand[] = [];
  filterColor: number;
  filterBrand: number;
  selectedColor:number;
  selectedBrand:number;
  constructor(private colorSerivce: ColorService, private brandService: BrandService) { }

  ngOnInit(): void {
    this.getBrands();
    this.getColors();
  }

  getBrands(){
    this.brandService.getBrands().subscribe(response => {
      this.brands = response.data;
    });
  }

  getColors (){
    this.colorSerivce.getColors().subscribe(response => {
      this.colors = response.data;
    });
  }

  getSelectedColor(colorId: number){
    if (this.filterColor == colorId) {
      return true;
    }
    return false;
  }

  getSelectedBrand(brandId: number){
    if(this.filterBrand == brandId){
      return true;
    }
    return false;
  }

  setSelectedColor(colorId: number){
    this.selectedColor = colorId;
  }

  setSelectedBrand(brandId: number){
    this.selectedBrand = brandId;
  }
}
