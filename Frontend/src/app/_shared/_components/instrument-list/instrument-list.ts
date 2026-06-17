import { Component, inject, input, output, resource } from '@angular/core';
import { INSTRUMENT_SERVICE } from '@app/_services/instrument/instrument.service.interface';
import { InstrumentDto } from '@generated/model/instrumentDto';
import { Icon } from '@shared/_components/icon/icon';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'dsh-instrument-list',
  imports: [Icon],
  templateUrl: './instrument-list.html',
  styleUrl: './instrument-list.css',
})
export class InstrumentList {
  acitveInstruments = input<InstrumentDto[]>([]);

  #instrumentService = inject(INSTRUMENT_SERVICE);

  instrumentResource = resource({
    loader: () => lastValueFrom(this.#instrumentService.getAllInstruments()),
  });

  aktivClicked = output<InstrumentDto>();
  inaktivClicked = output<InstrumentDto>();

  protected onAktiv(instrument: InstrumentDto): void {
    this.aktivClicked.emit(instrument);
  }

  protected onInaktiv(instrument: InstrumentDto): void {
    this.inaktivClicked.emit(instrument);
  }

  protected isActive(instrument: InstrumentDto): boolean {
    if (instrument.aktiv) {
      return true;
    } else {
      return this.acitveInstruments().some((i) => i.name === instrument.name);
    }
  }
}
