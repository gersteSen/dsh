import { inject, Injectable } from '@angular/core';
import {
  CreateTeacherDto,
  StudentDto,
  TeacherApi,
  TeacherDto,
  UpdateTeacherDto,
} from '@generated/index';
import { Observable } from 'rxjs';
import { TeacherServiceInterface } from './teacher.service.interface';

@Injectable({
  providedIn: 'root',
})
export class TeacherService implements TeacherServiceInterface {
  #api = inject(TeacherApi);

  createTeacher(createTeacherDto: CreateTeacherDto): Observable<string> {
    return this.#api.apiV1TeacherCreateTeacherPost(createTeacherDto);
  }
  updateTeacher(updateTeacherDto: UpdateTeacherDto): Observable<string> {
    return this.#api.apiV1TeacherUpdateTeacherPut(updateTeacherDto);
  }
  getAllTeachers(): Observable<TeacherDto[]> {
    return this.#api.apiV1TeacherGetAllTeachersGet();
  }
  getTeacherById(id: string): Observable<TeacherDto> {
    return this.#api.apiV1TeacherGetTeacherByIdTeacherIdGet(id);
  }
  getStudentsByTeacherId(id: string): Observable<StudentDto[]> {
    return this.#api.apiV1TeacherGetStudentsByTeacherIdTeacherIdGet(id);
  }
}
