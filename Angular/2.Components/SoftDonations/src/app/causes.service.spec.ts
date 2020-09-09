import { TestBed } from '@angular/core/testing';

import { CausesService } from './causes.service';

describe('CausesService', () => {
  let service: CausesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CausesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
