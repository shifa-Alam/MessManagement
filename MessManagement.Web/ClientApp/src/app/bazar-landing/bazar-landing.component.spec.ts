import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BazarLandingComponent } from './bazar-landing.component';

describe('BazarLandingComponent', () => {
  let component: BazarLandingComponent;
  let fixture: ComponentFixture<BazarLandingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BazarLandingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BazarLandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
