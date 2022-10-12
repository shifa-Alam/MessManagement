import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MealAddRangeComponent } from './meal-add-range.component';

describe('MealAddRangeComponent', () => {
  let component: MealAddRangeComponent;
  let fixture: ComponentFixture<MealAddRangeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MealAddRangeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MealAddRangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
