import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarDeclarationComponent } from './car-declaration.component';

describe('CarDeclarationComponent', () => {
  let component: CarDeclarationComponent;
  let fixture: ComponentFixture<CarDeclarationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarDeclarationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarDeclarationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
