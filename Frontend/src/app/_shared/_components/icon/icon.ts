import { Component, input } from '@angular/core';

@Component({
  selector: 'dsh-icon',
  imports: [],
  templateUrl: './icon.html',
  styleUrl: './icon.css',
})
export class Icon {
  icon = input.required<string>();
  classes = input<string>('');
}
