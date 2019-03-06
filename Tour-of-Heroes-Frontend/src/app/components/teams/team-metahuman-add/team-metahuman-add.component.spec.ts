import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamMetahumanAddComponent } from './team-metahuman-add.component';

describe('TeamMetahumanAddComponent', () => {
  let component: TeamMetahumanAddComponent;
  let fixture: ComponentFixture<TeamMetahumanAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeamMetahumanAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamMetahumanAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
