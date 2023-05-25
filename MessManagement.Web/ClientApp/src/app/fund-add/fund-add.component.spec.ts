import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FundAddComponent } from './fund-add.component';

describe('FundAddComponent', () => {
  let component: FundAddComponent;
  let fixture: ComponentFixture<FundAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FundAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FundAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
