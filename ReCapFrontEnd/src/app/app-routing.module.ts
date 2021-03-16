import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { CarComponent } from './components/car/car.component';
import { AppLayoutComponent } from './components/_layout/app-layout/app-layout.component';
import { CarDetailPageComponent } from './pages/car-detail-page/car-detail-page.component';
import { CustomersComponent } from './pages/customers/customers.component';
import { Error404Component } from './pages/error404/error404.component';
import { HomeComponent } from './pages/home/home.component';
import { RentalsComponent } from './pages/rentals/rentals.component';

const routes: Routes = [
  {
    path: '',
    component: AppLayoutComponent,
    children: [
      {
        path: '', component: HomeComponent, children: [
          { path: '', component: CarComponent },
          { path: 'cars', component: CarComponent },
          { path: 'cars/brand/:brandId', component: CarComponent },
          { path: 'cars/color/:colorId', component: CarComponent },
        ]
      },
      {path : 'car-detail/:carId', component:CarDetailPageComponent},
      { path: 'rentals', component: RentalsComponent },
      { path: 'customers', component: CustomersComponent },
      { path: '404', component: Error404Component },
      { path: '**', redirectTo: '/404' },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
