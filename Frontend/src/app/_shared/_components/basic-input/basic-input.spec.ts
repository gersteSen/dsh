import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BasicInput } from './basic-input';

describe('BasicInput', () => {
  let component: BasicInput;
  let fixture: ComponentFixture<BasicInput>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BasicInput],
    }).compileComponents();

    fixture = TestBed.createComponent(BasicInput);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
