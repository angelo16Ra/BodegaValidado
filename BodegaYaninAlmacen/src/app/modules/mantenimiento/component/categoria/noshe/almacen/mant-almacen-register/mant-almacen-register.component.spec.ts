import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantAlmacenRegisterComponent } from './mant-almacen-register.component';

describe('MantAlmacenRegisterComponent', () => {
  let component: MantAlmacenRegisterComponent;
  let fixture: ComponentFixture<MantAlmacenRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantAlmacenRegisterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantAlmacenRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
