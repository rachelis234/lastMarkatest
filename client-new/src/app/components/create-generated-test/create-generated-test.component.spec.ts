import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGeneratedTestComponent } from './create-generated-test.component';

describe('CreateGeneratedTestComponent', () => {
  let component: CreateGeneratedTestComponent;
  let fixture: ComponentFixture<CreateGeneratedTestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateGeneratedTestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateGeneratedTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
