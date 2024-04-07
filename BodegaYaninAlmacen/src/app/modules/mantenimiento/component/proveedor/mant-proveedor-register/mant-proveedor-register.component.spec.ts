import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantProveedorRegisterComponent } from './mant-proveedor-register.component';

describe('MantProveedorRegisterComponent', () => {
  let component: MantProveedorRegisterComponent;
  let fixture: ComponentFixture<MantProveedorRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantProveedorRegisterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantProveedorRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
