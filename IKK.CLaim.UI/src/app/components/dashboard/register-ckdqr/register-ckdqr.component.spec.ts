import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterCKDQRComponent } from './register-ckdqr.component';

describe('RegisterCKDQRComponent', () => {
  let component: RegisterCKDQRComponent;
  let fixture: ComponentFixture<RegisterCKDQRComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterCKDQRComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterCKDQRComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
