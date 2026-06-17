import { inject, Injectable } from '@angular/core';
import {
  CreateInstrumentDto,
  InstrumentApi,
  InstrumentDto,
  UpdateInstrumentDto,
} from '@generated/index';
import { Observable } from 'rxjs';
import { InstrumentServiceInterface } from './instrument.service.interface';

@Injectable({
  providedIn: 'root',
})
export class InstrumentService implements InstrumentServiceInterface {
  #api = inject(InstrumentApi);

  getAllInstruments(): Observable<InstrumentDto[]> {
    return this.#api.apiV1InstrumentGetAllInstrumentsGet();
  }
  getInstrumentById(id: string): Observable<InstrumentDto> {
    return this.#api.apiV1InstrumentGetInstrumentByIdInstrumentIdGet(id);
  }
  createInstrument(instrument: CreateInstrumentDto): Observable<string> {
    return this.#api.apiV1InstrumentCreateInstrumentPost(instrument);
  }
  updateInstrument(instrument: UpdateInstrumentDto): Observable<string> {
    return this.#api.apiV1InstrumentUpdateInstrumentPut(instrument);
  }
}
