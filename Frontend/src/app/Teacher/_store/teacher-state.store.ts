import { TeacherDto, TeacherInstrumentDto } from '@generated/index';
import { patchState, signalStore, withMethods, withState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { distinctUntilChanged, pipe, switchMap } from 'rxjs';
import { inject } from '@angular/core';
import { TEACHER_SERVICE } from '@services/teacher/teacher.service.interface';
import { tapResponse } from '@ngrx/operators';

interface TeacherState {
  selectedTeacher: TeacherDto | null;
}

const initialState: TeacherState = {
  selectedTeacher: null,
};

export const TeacherStateStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store) => {
    const teacherService = inject(TEACHER_SERVICE);
    return {
    setSelectedTeacher(teacher: TeacherDto | null): void {
      patchState(store, (_state) => ({
        selectedTeacher: teacher,
      }));
    },
    setSelectedTeacherRXJS: rxMethod<string>(
      pipe(
        distinctUntilChanged(),
        switchMap((teacherId) =>
          teacherService
            .getTeacherById(teacherId)
            .pipe(
              tapResponse({
                next: (teacher: TeacherDto) => {
                  patchState(store, { selectedTeacher: teacher });
                },
                error: (error) =>
                  console.error('Error fetching teacher:', error),
              }),
            ),
        ),
      ),
    ),
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
  };
  }),
);
