import { Component, OnInit, TemplateRef } from '@angular/core';
import { ResponseUnidadMedida } from '../../../models/unidadMedida-response.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { Router } from '@angular/router';
import { UnidadMedidaService } from '../../../service/unidad-medida.service';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { MantUnidadMedidaRegisterComponent } from '../mant-unidad-medida-register/mant-unidad-medida-register.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';
import { alert_delete, alert_success } from '../../../../../functions/general.functions';

@Component({
  selector: 'app-mant-unidad-medida-list',
  standalone: true,
  imports: [
    MantUnidadMedidaRegisterComponent,
    CommonModule,
    SharedModule,
    ReactiveFormsModule
  ],
  templateUrl: './mant-unidad-medida-list.component.html',
  styleUrl: './mant-unidad-medida-list.component.css'
})
export class MantUnidadMedidaListComponent implements OnInit{
  config  = {
    backdrop: true,
    ignoreBackdropClick: true
  };

  unidadMedidas: ResponseUnidadMedida[] = [];
  modalRef?: BsModalRef;
  unidadMedidaSelected: ResponseUnidadMedida = new  ResponseUnidadMedida();
  titleModal: string = "";
  accionModal: number = 0; //1 crea, 2 edita, 3 eliminar
  myFormFilter:FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 5;
  request: RequestFilterGeneric = new RequestFilterGeneric();


  constructor(
    private _route:Router,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private _unidadMedidaService:UnidadMedidaService

  ){
    this.myFormFilter= this.fb.group({
      codigoUnidadMedida: ["", []],
      nombre: ["", []],
      descripcion: ["", []],
      estado: ["", []],
    });
  }



  /**
   * FIXME: es el primer evento que ejecuta el componente
   */

  ngOnInit(): void {
    
    this.filtrar();

  }

  listarUnidadMedida()
  {
    this._unidadMedidaService.getAll().subscribe({
      next: (data:ResponseUnidadMedida[])=> {
        console.log("Data", data);
        this.unidadMedidas=data;
        
      },
      error: (err)=> {
        console.log("error ",err);
      },
      complete: ()=> {
        //algo
      },
    });
  }

  crearUnidadMedida(template: TemplateRef<any>)
  {
    this.unidadMedidaSelected= new ResponseUnidadMedida();
    this.titleModal="Crear una Unidad de medida";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }

  editarUnidadMedida(template: TemplateRef<any>, rol:ResponseUnidadMedida)
  {
    this.unidadMedidaSelected = rol;
    this.titleModal="Modificar una Unidad de medida";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
  }


  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, Object.assign({},{class: "gray modal-lg"},this.config));
  }

  getCloseModalEmmit(res:boolean){
    this.modalRef?.hide();
    if(res)
    {
      this.listarUnidadMedida();
    }
  }

  eliminarRegistro(codigoRol:number)
  {
    let result = confirm();

    if(result)
    {
      this._unidadMedidaService.delete(codigoRol).subscribe({
        next:(data:number) => {
          alert_success("EXCELENTE","Se borro el registro de manera correcta")
        },
        error:() => {},
        complete:() => {
          this.listarUnidadMedida();
        }
      })
    }


  }

  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoUnidadMedida", value: valueForm.codigoRol});
    this.request.filtros.push({name:"nombre", value: valueForm.nombre});
    this.request.filtros.push({name:"descripcion", value: valueForm.descripcion});
    this.request.filtros.push({name:"estado", value: valueForm.estado});

    this._unidadMedidaService.genericFilter(this.request).subscribe({
      next: (data: ResponseFilterGeneric<ResponseUnidadMedida> ) => {
        console.log(data);
        this.unidadMedidas = data.lista;
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
  limpiar() {
    this.myFormFilter.reset({
      "codigoUnidadMedida": '',
      "nombre": '',
      "descripcion": '',
      "estado": '',
    });
    this.filtrar();
  }

}
