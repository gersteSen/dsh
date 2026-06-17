import { InstrumentDto, TeacherDto } from '@generated/index';
import { patchState, signalStore, withMethods, withState } from '@ngrx/signals';

type TeacherState = {
  selectedTeacher: TeacherDto | null;
};

const initialState: TeacherState = {
  selectedTeacher: null,
};

export const TeacherStateStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store) => ({
    setSelectedTeacher(teacher: TeacherDto | null): void {
      patchState(store, (_state) => ({
        selectedTeacher: teacher,
      }));
    },
    toggleInstrument(instrument: InstrumentDto): void {
      const selectedTeacher = store.selectedTeacher;
      if (!selectedTeacher) {
        return;
      } else {
        const instruments = selectedTeacher()?.instruments ?? [];
        if (!instruments.some((i) => i.name === instrument.name)) {
          patchState(store, (_state) => ({
            selectedTeacher: {
              ...selectedTeacher(),
              instruments: [...instruments, instrument],
            },
          }));
        }
      }
    },
  })),
);
