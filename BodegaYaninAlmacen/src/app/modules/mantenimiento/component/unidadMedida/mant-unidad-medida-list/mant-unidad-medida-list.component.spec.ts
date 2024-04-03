import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantUnidadMedidaListComponent } from './mant-unidad-medida-list.component';

describe('MantUnidadMedidaListComponent', () => {
  let component: MantUnidadMedidaListComponent;
  let fixture: ComponentFixture<MantUnidadMedidaListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantUnidadMedidaListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantUnidadMedidaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
