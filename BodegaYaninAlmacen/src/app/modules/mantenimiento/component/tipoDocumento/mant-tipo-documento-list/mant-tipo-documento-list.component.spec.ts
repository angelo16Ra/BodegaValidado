import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantTipoDocumentoListComponent } from './mant-tipo-documento-list.component';

describe('MantTipoDocumentoListComponent', () => {
  let component: MantTipoDocumentoListComponent;
  let fixture: ComponentFixture<MantTipoDocumentoListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantTipoDocumentoListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantTipoDocumentoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
