import { Sex, TeacherDto } from '@generated/model/models';

export const teacherDtoMock = (
  sex: Sex = Sex.NUMBER_0,
  firstName: string = 'John',
  lastName: string = 'Doe',
  birthday: string = '2000-01-01',
  activeSince: string = '2020-01-01',
  active: boolean = true,
): TeacherDto =>
  ({
    sex,
    firstName,
    lastName,
    birthday,
    activeSince,
    active,
  }) as TeacherDto;
