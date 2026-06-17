import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstrumentList } from './instrument-list';

describe('InstrumentList', () => {
  let component: InstrumentList;
  let fixture: ComponentFixture<InstrumentList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstrumentList],
    }).compileComponents();

    fixture = TestBed.createComponent(InstrumentList);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
