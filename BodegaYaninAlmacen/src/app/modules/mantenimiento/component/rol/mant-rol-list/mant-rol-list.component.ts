import { CommonModule } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { SharedModule } from '../../../../shared/shared.module';
import { ResponseRol } from '../../../models/rol-response.model';
import { RolService } from '../../../service/rol.service';
import { MantRolRegisterComponent } from '../mant-rol-register/mant-rol-register.component';

@Component({
  selector: 'app-mant-rol-list',
  standalone: true,
  imports: [
    MantRolRegisterComponent,
    CommonModule,
    SharedModule
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
  myFormFilter:FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 3;
  request: RequestFilterGeneric = new RequestFilterGeneric();


  constructor(
    private _route:Router,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private _rolService:RolService

  ){
    this.myFormFilter= this.fb.group({
      codigoRol: ["", []],
      nombre: ["", []],
      descripcion: ["", []],
      estadoDescripcion: ["", []],
    });
  }



  /**
   * FIXME: es el primer evento que ejecuta el componente
   */

  ngOnInit(): void {
    
    this.filtrar();

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

  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoRol", value: valueForm.codigoRol});
    this.request.filtros.push({name:"nombre", value: valueForm.nombre});
    this.request.filtros.push({name:"descripcion", value: valueForm.descripcion});
    this.request.filtros.push({name:"estadoDescripcion", value: valueForm.estado});

    this._rolService.genericFilter(this.request).subscribe({
      next: (data: ResponseFilterGeneric<ResponseRol> ) => {
        console.log(data);
        this.rols = data.lista;
        this.totalItems = data.totalRegistros;
      },
      error: ( ) => {
        console.log("error");
      },
      complete: ( ) => {
        console.log("completo");
      },
    });
    
  }

  changePage(event: PageChangedEvent){
    this.request.numeroPagina = event.page;
    // let numeroPagina = event.page;
    // console.log(numeroPagina);
    this.filtrar();
  }

  changeItemsPerPage()
  {
    this.request.cantidad = this.itemsPerPage;
    this.filtrar();
  }


}
