import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AbilityCreateComponent } from './ability-create.component';

describe('AbilityCreateComponent', () => {
  let component: AbilityCreateComponent;
  let fixture: ComponentFixture<AbilityCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AbilityCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AbilityCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
