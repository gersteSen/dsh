import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstrumentCard } from './instrument-card';

describe('InstrumentCard', () => {
  let component: InstrumentCard;
  let fixture: ComponentFixture<InstrumentCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InstrumentCard],
    }).compileComponents();

    fixture = TestBed.createComponent(InstrumentCard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
