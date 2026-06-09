import { CreateTeacherDto, Sex } from '@generated/model/models';

export const createTeacherDtoMock = (
  sex: Sex = Sex.NUMBER_0,
  firstName: string = 'John',
  lastName: string = 'Doe',
  birthday: string = '2000-01-01',
  activeSince: string = '2020-01-01',
  instrumentIds: string[] = [crypto.randomUUID(), crypto.randomUUID()],
  roomIds: string[] = [crypto.randomUUID(), crypto.randomUUID()],
  lessonIds: string[] = [crypto.randomUUID(), crypto.randomUUID()],
  materialIds: string[] = [crypto.randomUUID(), crypto.randomUUID()],
  studentIds: string[] = [crypto.randomUUID(), crypto.randomUUID()],
): CreateTeacherDto =>
  ({
    sex,
    firstName,
    lastName,
    birthday,
    activeSince,
    instrumentIds,
    roomIds,
    lessonIds,
    materialIds,
    studentIds,
  }) as CreateTeacherDto;
