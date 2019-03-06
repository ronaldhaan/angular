import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MetahumanAbilityAddComponent } from './metahuman-ability-add.component';

describe('MetahumanAbilityAddComponent', () => {
  let component: MetahumanAbilityAddComponent;
  let fixture: ComponentFixture<MetahumanAbilityAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MetahumanAbilityAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MetahumanAbilityAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
