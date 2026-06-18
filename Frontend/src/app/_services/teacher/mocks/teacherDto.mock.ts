import { Sex, TeacherDto } from '@generated/model/models';
import { teacherInstrumentMockDto } from './teacherInstrumentMockDto.mock';

export const teacherDtoMock = ({
  sex = Sex.NUMBER_0,
  avatar = null,
  firstName = 'John',
  lastName = 'Doe',
  birthday = '2000-01-01',
  activeSince = '2020-01-01',
  active = true,
  instruments = teacherInstrumentMockDto(),
}: Omit<TeacherDto, 'id'>): TeacherDto =>
  ({
    id: crypto.randomUUID(),
    sex,
    avatar,
    firstName,
    lastName,
    fullName: `${firstName} ${lastName}`,
    birthday,
    activeSince,
    active,
    instruments,
  }) as TeacherDto;
