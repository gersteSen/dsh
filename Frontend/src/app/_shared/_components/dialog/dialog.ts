import { Component, input, output } from '@angular/core';
import { IconButton } from '../icon-button/icon-button';

export type DialogData = {
  title: string;
};

@Component({
  selector: 'dsh-dialog',
  imports: [IconButton],
  templateUrl: './dialog.html',
  styleUrl: './dialog.css',
})
export class Dialog {
  dialogData = input<DialogData>({
    title: '',
  });
  closeEvent = output<void>();

  onClick(): void {
    this.closeEvent.emit();
  }
}
