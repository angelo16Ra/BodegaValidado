import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantRolMultipleComponent } from './mant-rol-multiple.component';

describe('MantRolMultipleComponent', () => {
  let component: MantRolMultipleComponent;
  let fixture: ComponentFixture<MantRolMultipleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantRolMultipleComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantRolMultipleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
