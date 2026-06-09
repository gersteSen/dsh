import { InjectionToken } from '@angular/core';
import {
  CreateTeacherDto,
  StudentDto,
  TeacherDto,
  UpdateTeacherDto,
} from '@generated/model/models';
import { Observable } from 'rxjs';

export const TEACHER_SERVICE = new InjectionToken<TeacherServiceInterface>(
  'TEACHER_SERVICE',
);

export interface TeacherServiceInterface {
  createTeacher(createTeacherDto: CreateTeacherDto): Observable<string>;
  updateTeacher(updateTeacherDto: UpdateTeacherDto): Observable<string>;
  getAllTeachers(): Observable<TeacherDto[]>;
  getTeacherById(id: string): Observable<TeacherDto>;
  getStudentsByTeacherId(id: string): Observable<StudentDto[]>;
}
