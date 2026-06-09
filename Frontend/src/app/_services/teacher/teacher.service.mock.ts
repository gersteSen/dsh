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
      teacherDtoMock(Sex.NUMBER_1, 'Jenna', 'Jameson'),
      teacherDtoMock(Sex.NUMBER_0, 'Peter', 'North'),
    ]);
  }
  getTeacherById(_id: string): Observable<TeacherDto> {
    return of(teacherDtoMock());
  }
  getStudentsByTeacherId(_id: string): Observable<StudentDto[]> {
    return of([]);
  }
}
