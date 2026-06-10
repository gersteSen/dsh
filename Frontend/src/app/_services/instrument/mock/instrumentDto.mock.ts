import { InstrumentDto } from '@generated/model/instrumentDto';

export const instrumentDtoMock = ({
  name = 'Gitarre',
  description = 'Gitarre',
  image = 'images/instrument_1.jpg',
}: Omit<InstrumentDto, 'id'>) =>
  ({
    id: crypto.randomUUID(),
    description,
    name,
    image,
  }) as InstrumentDto;
