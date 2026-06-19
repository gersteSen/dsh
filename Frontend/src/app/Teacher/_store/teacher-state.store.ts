import {
  TeacherDto,
  TeacherInstrumentDto,
  UpdateTeacherDto,
} from '@generated/index';
import { patchState, signalStore, withMethods, withState } from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { distinctUntilChanged, pipe, switchMap, tap } from 'rxjs';
import { inject } from '@angular/core';
import { TEACHER_SERVICE } from '@services/teacher/teacher.service.interface';
import { tapResponse } from '@ngrx/operators';

interface TeacherState {
  teachers: TeacherDto[];
  selectedTeacher: TeacherDto | null;
  isLoading: boolean;
}

const initialState: TeacherState = {
  teachers: [],
  selectedTeacher: null,
  isLoading: false,
};

export const TeacherStateStore = signalStore(
  { providedIn: 'root' },
  withState(initialState),
  withMethods((store) => {
    const teacherService = inject(TEACHER_SERVICE);
    return {
      getAllTeachersRXJS: rxMethod<void>(
        pipe(
          tap(() => patchState(store, { isLoading: true })),
          switchMap(() =>
            teacherService.getAllTeachers().pipe(
              tapResponse({
                next: (teachers: TeacherDto[]) => {
                  patchState(store, {
                    teachers,
                    selectedTeacher: null,
                    isLoading: false,
                  });
                },
                error: (error) => {
                  console.error('Error fetching teachers:', error);
                  patchState(store, {
                    teachers: [],
                    selectedTeacher: null,
                    isLoading: false,
                  });
                },
              }),
            ),
          ),
        ),
      ),
      setSelectedTeacherRXJS: rxMethod<string>(
        pipe(
          distinctUntilChanged(),
          tap(() => patchState(store, { isLoading: true })),
          switchMap((teacherId) =>
            teacherService.getTeacherById(teacherId).pipe(
              tapResponse({
                next: (teacher: TeacherDto) => {
                  patchState(store, {
                    selectedTeacher: teacher,
                    isLoading: false,
                  });
                },
                error: (error) =>
                  console.error('Error fetching teacher:', error),
              }),
            ),
          ),
        ),
      ),
      setSelectedTeacher(id: string): void {
        patchState(store, {
          selectedTeacher: store.teachers().find((t) => t.id === id) ?? null,
        });
      },
      updateTeacherRXJS: rxMethod<UpdateTeacherDto>(
        pipe(
          tap(() => patchState(store, { isLoading: true })),
          switchMap((dto) =>
            teacherService.updateTeacher(dto).pipe(
              tapResponse({
                next: () => {
                  patchState(store, { isLoading: false });
                },
                error: (error) => {
                  patchState(store, { isLoading: false });
                  console.error('Error updating teacher:', error);
                },
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
