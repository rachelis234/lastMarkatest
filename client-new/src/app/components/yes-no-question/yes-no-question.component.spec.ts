import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YesNoQuestionComponent } from './yes-no-question.component';

describe('YesNoQuestionComponent', () => {
  let component: YesNoQuestionComponent;
  let fixture: ComponentFixture<YesNoQuestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YesNoQuestionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YesNoQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
