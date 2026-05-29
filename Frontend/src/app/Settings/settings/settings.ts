import { Component, signal } from '@angular/core';
import { BasicInput } from '../../_shared/_components/basic-input/basic-input';
import { SelectMenu } from '../../_shared/_components/select-menu/select-menu';
import { SelectMenuDataInterface } from '../../_shared/_components/select-menu/SelectMenuData.interface';

@Component({
  selector: 'dsh-settings',
  imports: [BasicInput, SelectMenu],
  templateUrl: './settings.html',
  styleUrl: './settings.css',
})
export class Settings {
  protected readonly themes = signal<SelectMenuDataInterface<string>[]>([
    {
      label: 'Hell',
      value: 'light',
    },
    {
      label: 'Dunkel',
      value: 'dark',
    },
  ]);
}
