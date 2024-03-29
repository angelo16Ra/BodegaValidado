import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantRolRegisterComponent } from './mant-rol-register.component';

describe('MantRolRegisterComponent', () => {
  let component: MantRolRegisterComponent;
  let fixture: ComponentFixture<MantRolRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantRolRegisterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantRolRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
