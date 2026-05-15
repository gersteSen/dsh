import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {ThemeSwitch} from './_shared/theme-switch/theme-switch';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ThemeSwitch],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Frontend');
}
