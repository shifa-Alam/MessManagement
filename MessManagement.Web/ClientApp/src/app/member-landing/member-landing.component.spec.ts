import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberLandingComponent } from './member-landing.component';

describe('MemberLandingComponent', () => {
  let component: MemberLandingComponent;
  let fixture: ComponentFixture<MemberLandingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MemberLandingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MemberLandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
