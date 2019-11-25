import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSubThemeComponent } from './add-sub-theme.component';

describe('AddSubThemeComponent', () => {
  let component: AddSubThemeComponent;
  let fixture: ComponentFixture<AddSubThemeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddSubThemeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSubThemeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
