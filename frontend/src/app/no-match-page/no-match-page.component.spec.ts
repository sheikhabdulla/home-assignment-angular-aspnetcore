import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoMatchPageComponent } from './no-match-page.component';

describe('NoMatchPageComponent', () => {
  let component: NoMatchPageComponent;
  let fixture: ComponentFixture<NoMatchPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NoMatchPageComponent]
    });
    fixture = TestBed.createComponent(NoMatchPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
