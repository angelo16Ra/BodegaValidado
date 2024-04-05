import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HttpClientModule } from '@angular/common/http';
import { PaginationModule } from 'ngx-bootstrap/pagination';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FormsModule,
    ModalModule.forRoot(),
    HttpClientModule,
    PaginationModule.forRoot()
  ],
  exports:[
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FormsModule,
    ModalModule,
    PaginationModule
  ]
})
export class SharedModule { }
