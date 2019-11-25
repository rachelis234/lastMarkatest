import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AmericanQuestionComponent } from './american-question.component';

describe('AmericanQuestionComponent', () => {
  let component: AmericanQuestionComponent;
  let fixture: ComponentFixture<AmericanQuestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AmericanQuestionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AmericanQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
