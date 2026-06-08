import { Component, inject, OnInit, Renderer2, signal } from '@angular/core';
import { SelectMenu } from '../select-menu/select-menu';
import { SelectMenuDataInterface } from '../select-menu/SelectMenuData.interface';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

export type Theme = 'light' | 'dark' | 'custom' | 'ringfelter';

@Component({
  selector: 'dsh-theme-switch',
  imports: [SelectMenu, ReactiveFormsModule],
  templateUrl: './theme-switch.html',
  styleUrl: './theme-switch.css',
})
export class ThemeSwitch implements OnInit {
  themeControl = new FormControl<SelectMenuDataInterface<Theme>>({
    label: 'Ringfelter',
    value: 'ringfelter',
  });
  renderer = inject(Renderer2);
  theme = signal<Theme>('light');
  protected readonly themes = signal<SelectMenuDataInterface<Theme>[]>([
    {
      label: 'Hell',
      value: 'light',
    },
    {
      label: 'Dunkel',
      value: 'dark',
    },
    {
      label: 'Custom',
      value: 'custom',
    },
    {
      label: 'Ringfelter',
      value: 'ringfelter',
    },
  ]);

  ngOnInit(): void {
    this.themeControl.valueChanges.subscribe((theme) => {
      if (theme) {
        this.setTheme(theme);
      }
    });
  }

  protected setTheme(themeSelect: SelectMenuDataInterface<unknown>) {
    const selectedTheme = themeSelect as SelectMenuDataInterface<Theme>;
    this.theme.set(selectedTheme.value);
    this.renderer.setAttribute(
      document.documentElement,
      'data-theme',
      this.theme(),
    );
  }
}
