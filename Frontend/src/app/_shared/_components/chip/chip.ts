import { Component, input } from '@angular/core';

@Component({
  selector: 'dsh-chip',
  imports: [],
  templateUrl: './chip.html',
  styleUrl: './chip.css',
})
export class Chip {
  label = input.required<string>();
}
