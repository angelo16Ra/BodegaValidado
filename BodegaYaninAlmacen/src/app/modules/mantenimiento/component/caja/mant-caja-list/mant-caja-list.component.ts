
import { CommonModule } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { SharedModule } from '../../../../shared/shared.module';
import { ResponseCaja } from '../../../models/caja-response.model';
import { CajaService } from '../../../service/caja.service';
import { MantCajaRegisterComponent } from '../mant-caja-register/mant-caja-register.component';
import { Vcaja } from '../../../models/VCaja.model';
import { ResponseUsuario } from '../../../models/usuario.response.model';
import { UsuarioService } from '../../../service/usuario.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-mant-caja-list',
  standalone: true,
  imports: [
    MantCajaRegisterComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-caja-list.component.html',
  styleUrl: './mant-caja-list.component.css'
})
export class MantCajaListComponent implements OnInit{
  config  = {
    backdrop: true,
    ignoreBackdropClick: true
  };
  
  requestFilterGeneric: RequestFilterGeneric = new RequestFilterGeneric();
  vCaja:Vcaja[]= [];
  modalRef?: BsModalRef;
  cajaSelect: Vcaja = new  Vcaja();
  titleModal: string = "";
  accionModal: number = 0;
  myFormFilter: FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 3;
  request: RequestFilterGeneric = new RequestFilterGeneric();

  tipoUsuario: ResponseUsuario[]=[];

  constructor(
    private _cajaService: CajaService, 
    private modalService: BsModalService,
    private _usuarioService: UsuarioService,

    private _route:Router,
    private fb: FormBuilder,
    
    
  ){
    this.myFormFilter= this.fb.group({
      codigoCaja: ["", []],
      usuario: ["", []],
      fecha: ["", []],
      estado: ["", []],
      montoApertura: ["", []],
      montoCierre: ["", []],
      montoAdicional: ["", []],
    });
  }

  ngOnInit(): void {
    this.filtrar();
    this.listarCajas();
    this.obtenerListas();

  }

  listarCajas() {
    this._cajaService.genericFilterView(this.requestFilterGeneric).subscribe({
      next: (data:ResponseFilterGeneric<Vcaja>) => {

        this.vCaja = data.lista;

        console.log(data);
      },

      error: (err) => {
        console.log(err);
      },

      complete: ()=>{
      }
    });
  }

  nuevoRegistro(template: TemplateRef<any>) {
    this.cajaSelect = new Vcaja();
    this.titleModal = "Nuevo caja";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }

  editarRegistro(template: TemplateRef<any>, caja: Vcaja) {
    this.cajaSelect = caja;
    this.titleModal = "Editar caja";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
  }

  obtenerListas()
  {
    forkJoin([
      this._usuarioService.getAll(),

    ]).subscribe({
      next:(data:any) => {
        this.tipoUsuario = data[0];
      },
      error:(err) => {
        
      },
      complete:() => {
        
      }
    })
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, Object.assign({},{class: "gray modal-lg"},this.config));
  }

  getCloseModalEmmit(res:boolean){
    this.modalRef?.hide();
    if(res)
    {
      this.listarCajas();
    }
  }

  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoCaja", value: valueForm.codigoCaja});
    this.request.filtros.push({name:"usuario", value: valueForm.usuario});
    this.request.filtros.push({name:"fecha", value: valueForm.fecha});
    this.request.filtros.push({name:"estado", value: valueForm.estado});
    this.request.filtros.push({name:"montoApertura", value: valueForm.montoApertura});
    this.request.filtros.push({name:"montoCierre", value: valueForm.montoCierre});
    this.request.filtros.push({name:"montoAdicional", value: valueForm.montoAdicional});

    this._cajaService.genericFilterView(this.request).subscribe({
      next: (data: ResponseFilterGeneric<Vcaja> ) => {
        console.log(data);
        this.vCaja = data.lista;
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