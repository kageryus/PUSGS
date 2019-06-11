import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StufComponent } from './stuf.component';

describe('StufComponent', () => {
  let component: StufComponent;
  let fixture: ComponentFixture<StufComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StufComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StufComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
