import { Component, input, output } from '@angular/core';
import { Icon } from '../icon/icon';

/**
 * Ein Icon-Button, der ein Icon anzeigt und auf Klicks reagiert. Er kann für verschiedene Aktionen verwendet werden, z.B. zum Öffnen eines Dialogs oder zum Ausführen einer Funktion.
 * @param icon Das anzuzeigende Icon (Standard: 'add').
 * @param classes Zusätzliche CSS-Klassen für die Gestaltung des Buttons (Standard: 'rounded-full bg-primary text-white p-2 shadow hover:opacity-75 cursor-pointer mt-8').
 * @param clickEvent Ein Event, das ausgelöst wird, wenn der Button geklickt wird.
 */

@Component({
  selector: 'dsh-icon-button',
  imports: [Icon],
  templateUrl: './icon-button.html',
  styleUrl: './icon-button.css',
})
export class IconButton {
  icon = input<string>('add');
  label = input<string>('');
  iconAndLabelButton = input<boolean>(false);
  classes = input<string>(
    'rounded-full bg-primary text-white p-2 shadow hover:opacity-75 cursor-pointer mt-8',
  );

  clickEvent = output<void>();

  onClick(): void {
    this.clickEvent.emit();
  }
}
