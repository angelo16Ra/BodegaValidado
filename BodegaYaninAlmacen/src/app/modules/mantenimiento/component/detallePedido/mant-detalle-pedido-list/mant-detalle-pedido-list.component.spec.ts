import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantDetallePedidoListComponent } from './mant-detalle-pedido-list.component';

describe('MantDetallePedidoListComponent', () => {
  let component: MantDetallePedidoListComponent;
  let fixture: ComponentFixture<MantDetallePedidoListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantDetallePedidoListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantDetallePedidoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
