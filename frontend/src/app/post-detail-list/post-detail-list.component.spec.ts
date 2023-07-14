import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostDetailListComponent } from './post-detail-list.component';

describe('PostDetailListComponent', () => {
  let component: PostDetailListComponent;
  let fixture: ComponentFixture<PostDetailListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PostDetailListComponent]
    });
    fixture = TestBed.createComponent(PostDetailListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
