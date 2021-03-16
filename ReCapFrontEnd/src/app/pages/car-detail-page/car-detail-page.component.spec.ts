import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarDetailPageComponent } from './car-detail-page.component';

describe('CarDetailPageComponent', () => {
  let component: CarDetailPageComponent;
  let fixture: ComponentFixture<CarDetailPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarDetailPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarDetailPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
