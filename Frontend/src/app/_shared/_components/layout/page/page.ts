import { Component, input, output } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { IconButton } from '../../icon-button/icon-button';

@Component({
  selector: 'dsh-page',
  imports: [RouterOutlet, IconButton],
  templateUrl: './page.html',
  styleUrl: './page.css',
})
export class PageContainer {
  titel = input<string>('Gib mir einen Titel');
  showSubmenu = input.required<boolean>();
  showSubmenuChange = output<boolean>();
}
