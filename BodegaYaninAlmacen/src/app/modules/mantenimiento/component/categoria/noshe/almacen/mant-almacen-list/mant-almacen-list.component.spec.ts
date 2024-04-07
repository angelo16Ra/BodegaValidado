import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantAlmacenListComponent } from './mant-almacen-list.component';

describe('MantAlmacenListComponent', () => {
  let component: MantAlmacenListComponent;
  let fixture: ComponentFixture<MantAlmacenListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantAlmacenListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantAlmacenListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
