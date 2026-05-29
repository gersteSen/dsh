import { Component, input, model } from '@angular/core';
import {
  FormValueControl,
  ValidationError,
  WithOptionalFieldTree,
} from '@angular/forms/signals';

@Component({
  selector: 'dsh-basic-input',
  imports: [],
  templateUrl: './basic-input.html',
  styleUrl: './basic-input.css',
})
export class BasicInput implements FormValueControl<string> {
  value = model('');
  label = input<string>('');
  placeholder = input<string>('');

  // Writable interaction state - control updates these
  touched = model<boolean>(false);

  // Read-only state - form system manages these
  disabled = input<boolean>(false);
  // disabledReasons = input<readonly DisabledReason[]>([]);
  readonly = input<boolean>(false);
  hidden = input<boolean>(false);
  invalid = input<boolean>(false);
  errors = input<readonly WithOptionalFieldTree<ValidationError>[]>([]);
  protected readonly Touch = Touch;
}
