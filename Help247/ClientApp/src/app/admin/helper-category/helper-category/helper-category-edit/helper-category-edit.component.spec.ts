import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HelperCategoryEditComponent } from './helper-category-edit.component';

describe('HelperCategoryEditComponent', () => {
  let component: HelperCategoryEditComponent;
  let fixture: ComponentFixture<HelperCategoryEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HelperCategoryEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HelperCategoryEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
