import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSubThemesComponent } from './view-sub-themes.component';

describe('ViewSubThemesComponent', () => {
  let component: ViewSubThemesComponent;
  let fixture: ComponentFixture<ViewSubThemesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewSubThemesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewSubThemesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
