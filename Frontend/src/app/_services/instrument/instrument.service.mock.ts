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
      instrumentDtoMock({ name: 'Gitarre' }),
      instrumentDtoMock({ name: 'Drums' }),
      instrumentDtoMock({ name: 'Gesang' }),
      instrumentDtoMock({ name: 'Klavier' }),
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
