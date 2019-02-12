import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MetahumanCreateComponent } from './metahuman-create.component';

describe('MetahumanCreateComponent', () => {
  let component: MetahumanCreateComponent;
  let fixture: ComponentFixture<MetahumanCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MetahumanCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MetahumanCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
