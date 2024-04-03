import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantSubCategoriaRegisterComponent } from './mant-sub-categoria-register.component';

describe('MantSubCategoriaRegisterComponent', () => {
  let component: MantSubCategoriaRegisterComponent;
  let fixture: ComponentFixture<MantSubCategoriaRegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantSubCategoriaRegisterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantSubCategoriaRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
