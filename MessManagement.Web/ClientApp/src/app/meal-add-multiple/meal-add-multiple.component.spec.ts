import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MealAddMultipleComponent } from './meal-add-multiple.component';

describe('MealAddMultipleComponent', () => {
  let component: MealAddMultipleComponent;
  let fixture: ComponentFixture<MealAddMultipleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MealAddMultipleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MealAddMultipleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
