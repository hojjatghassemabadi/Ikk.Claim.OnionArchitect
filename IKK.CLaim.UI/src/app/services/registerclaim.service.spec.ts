import { TestBed } from '@angular/core/testing';

import { RegisterclaimService } from './registerclaim.service';

describe('RegisterclaimService', () => {
  let service: RegisterclaimService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RegisterclaimService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
