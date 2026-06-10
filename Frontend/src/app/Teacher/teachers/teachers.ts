import { Component, inject, OnInit, signal } from '@angular/core';
import { TEACHER_SERVICE } from '@services/teacher/teacher.service.interface';
import { HttpErrorResponse } from '@angular/common/http';
import { TeacherDto } from '@generated/model/teacherDto';
import { TeacherCard } from '@shared/_components/teacher-card/teacher-card';

@Component({
  selector: 'dsh-teachers',
  imports: [TeacherCard],
  templateUrl: './teachers.html',
  styleUrl: './teachers.css',
})
export class Teachers implements OnInit {
  teacherService = inject(TEACHER_SERVICE);
  teachers = signal<TeacherDto[]>([]);

  ngOnInit(): void {
    this.teacherService.getAllTeachers().subscribe({
      next: (teachers: TeacherDto[]) => {
        this.teachers.set(teachers);
      },
      error: (error: HttpErrorResponse) =>
        console.error('Teachers:', error.message),
    });
  }
}
