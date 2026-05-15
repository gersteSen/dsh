import {Component, inject, Renderer2, signal} from '@angular/core';


export type Theme = 'light' | 'dark' | 'custom';

@Component({
  selector: 'dsh-theme-switch',
  imports: [],
  templateUrl: './theme-switch.html',
  styleUrl: './theme-switch.css',
})
export class ThemeSwitch {
  renderer = inject(Renderer2);
  theme = signal<Theme>('light');

  protected setTheme(theme: Theme) {
    this.theme.set(theme);
    this.renderer.setAttribute(
      document.documentElement,
      'data-theme',
      this.theme()
    );
  }
}
