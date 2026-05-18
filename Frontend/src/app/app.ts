import { Component, signal } from '@angular/core';
import {Sidebar} from './_shared/_components/layout/sidebar/sidebar';

@Component({
  selector: 'dsh-root',
  imports: [Sidebar],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Frontend');
}
