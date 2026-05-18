import {Page} from './page';

export type PagesConfig =
  {
    label: string;
    icon: string;
    route: `/${Lowercase<Page>}`;
  }
