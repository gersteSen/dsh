import { TeacherDto } from '@generated/index';
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
  })),
);
