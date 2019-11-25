import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPupilsComponent } from './add-pupils.component';

describe('AddPupilsComponent', () => {
  let component: AddPupilsComponent;
  let fixture: ComponentFixture<AddPupilsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPupilsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPupilsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
