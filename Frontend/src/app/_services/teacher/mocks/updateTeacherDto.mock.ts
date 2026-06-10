import { Sex, UpdateTeacherDto } from '@generated/model/models';

export const updateTeacherDtoMock = (
  id: string = crypto.randomUUID(),
  sex: Sex = Sex.NUMBER_0,
  firstName = 'John',
  lastName = 'Doe',
  birthday = '2000-01-01',
  activeSince = '2020-01-01',
  instrumentIds: string[] = [crypto.randomUUID(), crypto.randomUUID()],
  roomIds: string[] = [crypto.randomUUID(), crypto.randomUUID()],
  lessonIds: string[] = [crypto.randomUUID(), crypto.randomUUID()],
  materialIds: string[] = [crypto.randomUUID(), crypto.randomUUID()],
  studentIds: string[] = [crypto.randomUUID(), crypto.randomUUID()],
): UpdateTeacherDto =>
  ({
    id,
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
  }) as UpdateTeacherDto;
