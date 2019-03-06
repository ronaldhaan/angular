import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AbilitiesIndexComponent } from './abilities-index.component';

describe('AbilitiesIndexComponent', () => {
  let component: AbilitiesIndexComponent;
  let fixture: ComponentFixture<AbilitiesIndexComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AbilitiesIndexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AbilitiesIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
