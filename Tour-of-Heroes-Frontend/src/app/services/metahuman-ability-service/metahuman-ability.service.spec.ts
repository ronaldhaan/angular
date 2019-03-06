import { TestBed } from '@angular/core/testing';

import { MetahumanAbilityService } from './metahuman-ability.service';

describe('MetahumanAbilityService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MetahumanAbilityService = TestBed.get(MetahumanAbilityService);
    expect(service).toBeTruthy();
  });
});
