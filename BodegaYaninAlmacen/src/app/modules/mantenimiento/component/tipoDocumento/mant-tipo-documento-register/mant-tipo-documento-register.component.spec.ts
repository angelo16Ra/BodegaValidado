import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantTipoDocumentoRegisterComponent } from './mant-tipo-documento-register.component';

describe('MantTipoDocumentoRegisterComponent', () => {
  let component: MantTipoDocumentoRegisterComponent;
  let fixture: ComponentFixture<MantTipoDocumentoRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantTipoDocumentoRegisterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantTipoDocumentoRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
