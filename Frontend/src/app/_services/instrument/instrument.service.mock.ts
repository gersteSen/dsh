import { Injectable } from '@angular/core';
import {
  CreateInstrumentDto,
  InstrumentDto,
  UpdateInstrumentDto,
} from '@generated/index';
import { Observable, of } from 'rxjs';
import { InstrumentServiceInterface } from './instrument.service.interface';
import { instrumentDtoMock } from './mock/instrumentDto.mock';

@Injectable({
  providedIn: 'root',
})
export class InstrumentMockService implements InstrumentServiceInterface {
  getAllInstruments(): Observable<InstrumentDto[]> {
    return of([
      instrumentDtoMock({
        name: 'Drums',
        description: 'Beschreibung der Drums',
        image: 'images/instrument_2.jpg',
      }),
      instrumentDtoMock({
        name: 'Gitarre',
        description: 'Beschreibung der Gitarre',
        image: 'images/instrument_1.jpg',
      }),
      instrumentDtoMock({
        name: 'Bass',
        description: 'Beschreibung des Basses',
        image: 'images/instrument_3.jpg',
      }),
      instrumentDtoMock({
        name: 'Gesang',
        description: 'Beschreibung des Gesangs',
        image: 'images/instrument_4.jpg',
      }),
    ]);
  }
  getInstrumentById(id: string): Observable<InstrumentDto> {
    return of(instrumentDtoMock({ name: 'Klavier' }));
  }
  createInstrument(instrument: CreateInstrumentDto): Observable<string> {
    return of(crypto.randomUUID());
  }
  updateInstrument(instrument: UpdateInstrumentDto): Observable<string> {
    return of(crypto.randomUUID());
  }
}
