import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BazarAddComponent } from './bazar-add.component';

describe('BazarAddComponent', () => {
  let component: BazarAddComponent;
  let fixture: ComponentFixture<BazarAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BazarAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BazarAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
