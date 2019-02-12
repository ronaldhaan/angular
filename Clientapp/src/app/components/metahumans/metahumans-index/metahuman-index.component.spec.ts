import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MetaHumanIndexComponent } from './metahuman-index.component';

describe('MetaHumanIndexComponent', () => {
  let component: MetaHumanIndexComponent;
  let fixture: ComponentFixture<MetaHumanIndexComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MetaHumanIndexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MetaHumanIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
