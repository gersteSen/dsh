import { Injectable } from '@angular/core';
import {
  CreateTeacherDto,
  Sex,
  StudentDto,
  TeacherDto,
  UpdateTeacherDto,
} from '@generated/index';
import { Observable, of } from 'rxjs';
import { teacherDtoMock } from './mocks/teacherDto.mock';
import { TeacherServiceInterface } from './teacher.service.interface';
import { instrumentDtoMock } from '@services/instrument/mock/instrumentDto.mock';

@Injectable({
  providedIn: 'root',
})
export class TeacherMockService implements TeacherServiceInterface {
  createTeacher(_createTeacherDto: CreateTeacherDto): Observable<string> {
    return of(crypto.randomUUID());
  }

  updateTeacher(_updateTeacherDto: UpdateTeacherDto): Observable<string> {
    return of(crypto.randomUUID());
  }

  getAllTeachers(): Observable<TeacherDto[]> {
    return of([
      teacherDtoMock({
        sex: Sex.NUMBER_0,
        avatar: 'images/teacher_1.jpg',
        firstName: 'Peter',
        lastName: 'North',
        instruments: [
          instrumentDtoMock({
            name: 'Drums',
            image: 'images/instrument_2.jpg',
          }),
        ],
      }),
      teacherDtoMock({
        sex: Sex.NUMBER_1,
        avatar: 'images/teacher_2.jpg',
        firstName: 'Jenna',
        lastName: 'Jameson',
        instruments: [
          instrumentDtoMock({
            name: 'Drums',
            image: 'images/instrument_2.jpg',
          }),
        ],
      }),
      teacherDtoMock({
        sex: Sex.NUMBER_0,
        avatar: 'images/teacher_3.jpg',
        firstName: 'John',
        lastName: 'Kirsh',
        instruments: [
          instrumentDtoMock({
            name: 'Drums',
            image: 'images/instrument_2.jpg',
          }),
        ],
      }),
      teacherDtoMock({
        sex: Sex.NUMBER_0,
        avatar: 'images/teacher_4.jpg',
        firstName: 'Jörg',
        lastName: 'Vollgas',
        instruments: [
          instrumentDtoMock({
            name: 'Gesang',
            image: 'images/instrument_4.jpg',
          }),
        ],
      }),
      teacherDtoMock({
        sex: Sex.NUMBER_0,
        avatar: 'images/teacher_5.jpg',
        firstName: 'Björn',
        lastName: 'Black',
        instruments: [
          instrumentDtoMock({
            name: 'Drums',
            image: 'images/instrument_2.jpg',
          }),
        ],
      }),
      teacherDtoMock({
        sex: Sex.NUMBER_1,
        avatar: 'images/teacher_6.jpg',
        firstName: 'Lady',
        lastName: 'Cry',
        instruments: [
          instrumentDtoMock({
            name: 'Gesang',
            image: 'images/instrument_4.jpg',
          }),
        ],
      }),
      teacherDtoMock({
        sex: Sex.NUMBER_0,
        avatar: 'images/teacher_7.jpg',
        firstName: 'Dude',
        lastName: 'Dudel',
        instruments: [
          instrumentDtoMock({
            name: 'Gitarre',
            image: 'images/instrument_1.jpg',
          }),
          instrumentDtoMock({
            name: 'Bass',
            image: 'images/instrument_3.jpg',
          }),
        ],
      }),
    ]);
  }

  getTeacherById(_id: string): Observable<TeacherDto> {
    return of(teacherDtoMock({}));
  }

  getStudentsByTeacherId(_id: string): Observable<StudentDto[]> {
    return of([]);
  }
}
