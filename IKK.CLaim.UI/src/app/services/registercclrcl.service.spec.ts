import { TestBed } from '@angular/core/testing';

import { RegistercclrclService } from './registercclrcl.service';

describe('RegistercclrclService', () => {
  let service: RegistercclrclService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RegistercclrclService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
