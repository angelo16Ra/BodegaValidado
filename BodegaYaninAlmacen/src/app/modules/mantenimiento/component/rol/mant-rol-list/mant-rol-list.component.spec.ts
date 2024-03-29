import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MantRolListComponent } from './mant-rol-list.component';

describe('MantRolListComponent', () => {
  let component: MantRolListComponent;
  let fixture: ComponentFixture<MantRolListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MantRolListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MantRolListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
