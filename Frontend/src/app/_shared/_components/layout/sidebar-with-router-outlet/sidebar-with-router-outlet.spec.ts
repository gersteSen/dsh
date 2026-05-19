import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarWithRouterOutlet } from './sidebar-with-router-outlet';

describe('SidebarWithRouterOutlet', () => {
  let component: SidebarWithRouterOutlet;
  let fixture: ComponentFixture<SidebarWithRouterOutlet>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SidebarWithRouterOutlet],
    }).compileComponents();

    fixture = TestBed.createComponent(SidebarWithRouterOutlet);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
