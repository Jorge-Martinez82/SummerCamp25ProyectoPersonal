import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Monitor } from './monitor';

describe('Monitor', () => {
  let component: Monitor;
  let fixture: ComponentFixture<Monitor>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Monitor]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Monitor);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
