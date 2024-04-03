import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantUnidadMedidaRegisterComponent } from './mant-unidad-medida-register.component';

describe('MantUnidadMedidaRegisterComponent', () => {
  let component: MantUnidadMedidaRegisterComponent;
  let fixture: ComponentFixture<MantUnidadMedidaRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantUnidadMedidaRegisterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantUnidadMedidaRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
