import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FundLandingComponent } from './fund-landing.component';

describe('FundLandingComponent', () => {
  let component: FundLandingComponent;
  let fixture: ComponentFixture<FundLandingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FundLandingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FundLandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
