import { Component, output } from '@angular/core';
import { Dialog, DialogData } from '@shared/_components/dialog/dialog';
import { BasicInput } from '@shared/_components/basic-input/basic-input';
import { IconButton } from '@shared/_components/icon-button/icon-button';

@Component({
  selector: 'dsh-create-new-teacher-dialog',
  imports: [Dialog, BasicInput, IconButton],
  templateUrl: './create-new-teacher-dialog.html',
  styleUrl: './create-new-teacher-dialog.css',
})
export class CreateNewTeacherDialog {
  protected dialogData: DialogData = {
    title: 'Lehrer erstellen',
  };

  closeEvent = output<void>();

  protected onClick() {
    this.closeEvent.emit();
  }
}
