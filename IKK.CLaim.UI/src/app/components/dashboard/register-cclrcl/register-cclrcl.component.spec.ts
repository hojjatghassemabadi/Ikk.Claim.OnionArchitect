import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterCCLRCLComponent } from './register-cclrcl.component';

describe('RegisterCCLRCLComponent', () => {
  let component: RegisterCCLRCLComponent;
  let fixture: ComponentFixture<RegisterCCLRCLComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterCCLRCLComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterCCLRCLComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
