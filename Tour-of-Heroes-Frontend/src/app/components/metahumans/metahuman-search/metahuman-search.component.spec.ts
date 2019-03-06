import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MetahumanSearchComponent } from './metahuman-search.component';

describe('MetahumanSearchComponent', () => {
  let component: MetahumanSearchComponent;
  let fixture: ComponentFixture<MetahumanSearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MetahumanSearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MetahumanSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
