import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSimpleTestComponent } from './create-simple-test.component';

describe('CreateSimpleTestComponent', () => {
  let component: CreateSimpleTestComponent;
  let fixture: ComponentFixture<CreateSimpleTestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateSimpleTestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateSimpleTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
