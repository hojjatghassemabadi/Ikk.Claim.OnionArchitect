import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartDeclarationComponent } from './part-declaration.component';

describe('PartDeclarationComponent', () => {
  let component: PartDeclarationComponent;
  let fixture: ComponentFixture<PartDeclarationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PartDeclarationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PartDeclarationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
