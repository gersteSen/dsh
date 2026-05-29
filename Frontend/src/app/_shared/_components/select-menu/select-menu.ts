import {
  Component,
  CUSTOM_ELEMENTS_SCHEMA,
  input,
  model,
  output,
  signal,
} from '@angular/core';
import { FormValueControl } from '@angular/forms/signals';
import { SelectMenuDataInterface } from './SelectMenuData.interface';

@Component({
  selector: 'dsh-select-menu',
  imports: [],
  templateUrl: './select-menu.html',
  styleUrl: './select-menu.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class SelectMenu implements FormValueControl<
  SelectMenuDataInterface<unknown>
> {
  placeholder = input<string>('Auswahlkriterium benennen');

  value = model({} as SelectMenuDataInterface<unknown>);
  items = input.required<SelectMenuDataInterface<unknown>[]>();
  valueChanges = output<SelectMenuDataInterface<unknown> | null>();

  protected readonly showOptions = signal<boolean>(true);
  protected readonly selectedItem =
    signal<SelectMenuDataInterface<unknown> | null>(null);

  protected showItems(): void {
    this.showOptions.update((state) => !state);
  }

  protected selectItem(item: SelectMenuDataInterface<unknown>): void {
    this.selectedItem.set(item);
    this.value.set(item);
    this.valueChanges.emit(item);
    this.showItems();
  }
}
