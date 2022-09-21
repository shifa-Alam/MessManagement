import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MealLandingComponent } from './meal-landing.component';

describe('MealLandingComponent', () => {
  let component: MealLandingComponent;
  let fixture: ComponentFixture<MealLandingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MealLandingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MealLandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
