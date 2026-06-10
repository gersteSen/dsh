import { Component, input } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'dsh-page',
  imports: [RouterOutlet],
  templateUrl: './page.html',
  styleUrl: './page.css',
})
export class Page {
  titel = input<string>('Gib mir einen Titel');
}
