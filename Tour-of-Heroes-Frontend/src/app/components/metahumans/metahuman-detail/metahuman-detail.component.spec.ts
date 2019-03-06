import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MetahumanDetailComponent } from './metahuman-detail.component';

describe('MetahumanDetailComponent', () => {
  let component: MetahumanDetailComponent;
  let fixture: ComponentFixture<MetahumanDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MetahumanDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MetahumanDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
