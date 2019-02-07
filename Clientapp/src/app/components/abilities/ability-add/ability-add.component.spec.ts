import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AbilityAddComponent } from './ability-add.component';

describe('AbilityAddComponent', () => {
  let component: AbilityAddComponent;
  let fixture: ComponentFixture<AbilityAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AbilityAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AbilityAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
