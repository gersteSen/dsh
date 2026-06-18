import { TeacherInstrumentDto } from '@generated/index';

export const teacherInstrumentMockDto = (): TeacherInstrumentDto[] => [
  {
    id: crypto.randomUUID(),
    name: 'Gitarre',
    description: 'Eine Gitarre ist ein Saiteninstrument.',
    image: 'images/instrument_1.jpg',
    active: true,
  } as TeacherInstrumentDto,
  {
    id: crypto.randomUUID(),
    name: 'Bass',
    description: 'Ein Bass ist ein Saiteninstrument.',
    image: 'images/instrument_3.jpg',
    active: false,
  } as TeacherInstrumentDto,
  {
    id: crypto.randomUUID(),
    name: 'Drums',
    description: 'Ein Schlagzeug ist ein Schlaginstrument.',
    image: 'images/instrument_2.jpg',
    active: true,
  } as TeacherInstrumentDto,

  {
    id: crypto.randomUUID(),
    name: 'Gesang',
    description:
      'Gesang ist die Kunst, die Stimme als musikalisches Instrument zu verwenden.',
    image: 'images/instrument_4.jpg',
    active: false,
  } as TeacherInstrumentDto,
];
