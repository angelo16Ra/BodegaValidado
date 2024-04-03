import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantDetallePedidoRegisterComponent } from './mant-detalle-pedido-register.component';

describe('MantDetallePedidoRegisterComponent', () => {
  let component: MantDetallePedidoRegisterComponent;
  let fixture: ComponentFixture<MantDetallePedidoRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantDetallePedidoRegisterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantDetallePedidoRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
