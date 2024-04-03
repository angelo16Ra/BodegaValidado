import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantSubCategoriaListComponent } from './mant-sub-categoria-list.component';

describe('MantSubCategoriaListComponent', () => {
  let component: MantSubCategoriaListComponent;
  let fixture: ComponentFixture<MantSubCategoriaListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantSubCategoriaListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantSubCategoriaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
