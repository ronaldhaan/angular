import { TestBed } from '@angular/core/testing';

import { MetahumanService } from './metahuman.service';

describe('MetahumanService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MetahumanService = TestBed.get(MetahumanService);
    expect(service).toBeTruthy();
  });
});
