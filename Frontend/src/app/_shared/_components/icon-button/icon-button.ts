import { Component, input } from '@angular/core';
import { Icon } from '../icon/icon';

@Component({
  selector: 'dsh-icon-button',
  imports: [Icon],
  templateUrl: './icon-button.html',
  styleUrl: './icon-button.css',
})
export class IconButton {
  icon = input<string>('add');
  classes = input<string>(
    'rounded-full bg-primary text-white p-2 shadow hover:opacity-75 cursor-pointer mt-8',
  );
}
