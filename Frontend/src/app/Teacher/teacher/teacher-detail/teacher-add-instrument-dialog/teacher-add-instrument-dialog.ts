import { Component, output, signal } from '@angular/core';
import { Dialog, DialogData } from '@app/_shared/_components/dialog/dialog';

@Component({
  selector: 'dsh-teacher-add-instrument-dialog',
  imports: [Dialog],
  templateUrl: './teacher-add-instrument-dialog.html',
  styleUrl: './teacher-add-instrument-dialog.css',
})
export class TeacherAddInstrumentDialog {
  showDialog = signal<boolean>(false);
  dialogData: DialogData = {
    title: 'Instrument hinzufügen',
  };
  closeEvent = output<void>();

  onClick(): void {
    this.closeEvent.emit();
  }
}
