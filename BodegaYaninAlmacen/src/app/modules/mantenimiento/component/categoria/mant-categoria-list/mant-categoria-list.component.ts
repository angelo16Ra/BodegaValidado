import { CommonModule } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from 'express';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { SharedModule } from '../../../../shared/shared.module';
import { ResponseCategoria } from '../../../models/categoria-response.model';
import { CategoriaService } from '../../../service/categoria.service';

@Component({
  selector: 'app-mant-categoria-list',
  standalone: true,
  imports: [
    MantCategoriaListComponent,
    CommonModule,
    SharedModule,
  ],
  templateUrl: './mant-categoria-list.component.html',
  styleUrl: './mant-categoria-list.component.css'
})
export class MantCategoriaListComponent implements OnInit {
  
  categorias: ResponseCategoria[] = [];
  modalRef?: BsModalRef;
  categoriaSelected: ResponseCategoria = new ResponseCategoria();
  titleModal: string = "";
  accionModal: number = 0;
  


  constructor(
    private _route:Router,
    private modalService: BsModalService,
    private _categoriaService: CategoriaService
  )
  {

  }
  
  ngOnInit(): void {
    this.listarCategorias();
  }



  listarCategorias()
  {
    this._categoriaService.getAll().subscribe({
      next:(data:ResponseCategoria[])=>{
        console.log("Data",data);
        this.categorias=data;
      },
      error: (err)=> {
        console.log("error ",err);
      },
      complete: ()=> {
        //algo
      },
    })
  }
  crearCategoria(template: TemplateRef<any>)
  {
    this.categoriaSelected = new ResponseCategoria();
    this.titleModal="Crear Categoria";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }

  editarCategoria(template: TemplateRef<any>, categoria:ResponseCategoria)
  {
    this.categoriaSelected = categoria;
    this.titleModal="Crear Categoria";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template)
  }

  getCloseModalEmmit(res:boolean){
    this.modalRef?.hide();
    if(res)
    {
      this.listarCategorias();
    }
  }

  eliminarRegistro(codigoCategoria:number)
  {
    let result = confirm("¿Estas seguro de eliminar el registro?")
    if(result)
    {
      this._categoriaService.delete(codigoCategoria).subscribe({
        next:(data:number) => {
          alert("El registro fue eliminado de manera correcta");
        },
        error:() => {},
        complete:() => {
          this.listarCategorias();
        }
      })
    }

  }

}
