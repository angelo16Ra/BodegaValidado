import { CommonModule } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { error } from 'console';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseRol } from '../../../models/rol-response.model';
import { RolService } from '../../../service/rol.service';
import { MantRolRegisterComponent } from '../mant-rol-register/mant-rol-register.component';

@Component({
  selector: 'app-mant-rol-list',
  standalone: true,
  imports: [
    MantRolRegisterComponent,
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],
  templateUrl: './mant-rol-list.component.html',
  styleUrl: './mant-rol-list.component.css'
})
export class MantRolListComponent implements OnInit{

  rols: ResponseRol[] = [];
  modalRef?: BsModalRef;
  rolSelected: ResponseRol = new  ResponseRol();
  titleModal: string = "";
  accionModal: number = 0; //1 crea, 2 edita, 3 eliminar


  constructor(
    private _route:Router,
    private modalService: BsModalService,
    private _rolService:RolService
  ){

  }



  /**
   * FIXME: es el primer evento que ejecuta el componente
   */

  ngOnInit(): void {
    
    this.listarRols();

  }

  listarRols()
  {
    this._rolService.getAll().subscribe({
      next: (data:ResponseRol[])=> {
        console.log("Data", data);
        this.rols=data;
        
      },
      error: (err)=> {
        console.log("error ",err);
      },
      complete: ()=> {
        //algo
      },
    });
  }



  crearRol(template: TemplateRef<any>)
  {
    this.rolSelected= new ResponseRol();
    this.titleModal="Crear un Rol";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }
  editarRol(template: TemplateRef<any>, rol:ResponseRol)
  {
    this.rolSelected = rol;
    this.titleModal="Modificar Rol";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
  }



  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  getCloseModalEmmit(res:boolean){
    this.modalRef?.hide();
    if(res)
    {
      this.listarRols();
    }
  }

  eliminarRegistro(codigoRol:number)
  {
    let result = confirm("¿Estas seguro de eliminar el registro?")

    if(result)
    {
      this._rolService.delete(codigoRol).subscribe({
        next:(data:number) => {
          alert("El registro fue eliminado de manera correcta");
        },
        error:() => {},
        complete:() => {
          this.listarRols();
        }
      })
    }


  }




}
