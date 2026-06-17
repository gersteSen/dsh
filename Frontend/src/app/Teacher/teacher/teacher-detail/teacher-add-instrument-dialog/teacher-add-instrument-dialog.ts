import { Component, input, output, signal } from '@angular/core';
import { Dialog, DialogData } from '@app/_shared/_components/dialog/dialog';
import { InstrumentList } from '@app/_shared/_components/instrument-list/instrument-list';
import { InstrumentDto } from '@generated/index';

@Component({
  selector: 'dsh-teacher-add-instrument-dialog',
  imports: [Dialog, InstrumentList],
  templateUrl: './teacher-add-instrument-dialog.html',
  styleUrl: './teacher-add-instrument-dialog.css',
})
export class TeacherAddInstrumentDialog {
  activeInstruments = input<InstrumentDto[]>([]);
  showDialog = signal<boolean>(false);
  dialogData: DialogData = {
    title: 'Aktive Instrumente pflegen',
  };
  closeEvent = output<void>();

  onClick(): void {
    this.closeEvent.emit();
  }
}
