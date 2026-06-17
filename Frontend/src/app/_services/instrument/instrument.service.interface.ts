import { InjectionToken } from '@angular/core';
import {
  CreateInstrumentDto,
  InstrumentDto,
  UpdateInstrumentDto,
} from '@generated/index';
import { Observable } from 'rxjs';

export const INSTRUMENT_SERVICE =
  new InjectionToken<InstrumentServiceInterface>('INSTRUMENT_SERVICE');

export interface InstrumentServiceInterface {
  getAllInstruments(): Observable<InstrumentDto[]>;
  getInstrumentById(id: string): Observable<InstrumentDto>;
  createInstrument(instrument: CreateInstrumentDto): Observable<string>;
  updateInstrument(instrument: UpdateInstrumentDto): Observable<string>;
}
