import { TeacherDto, TeacherInstrumentDto } from '@generated/index';
import { patchState, signalStore, withMethods, withState } from '@ngrx/signals';

interface TeacherState {
  selectedTeacher: TeacherDto | null;
}

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
    toggleInstrument(instrument: TeacherInstrumentDto): void {
      const selectedTeacher = store.selectedTeacher;
      if (!selectedTeacher) {
        return;
      } else {
        const instruments =
          store.selectedTeacher()?.instruments?.map((i) => {
            if (i.id === instrument.id) {
              return {
                ...i,
                active: instrument.active,
              };
            } else {
              return i;
            }
          }) ?? [];
        patchState(store, (_state) => ({
          selectedTeacher: {
            ...selectedTeacher(),
            instruments,
          },
        }));
      }
    },
  })),
);
