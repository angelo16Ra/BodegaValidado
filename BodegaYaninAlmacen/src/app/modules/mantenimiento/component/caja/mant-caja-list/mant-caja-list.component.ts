import { CommonModule } from '@angular/common';
import { Component, TemplateRef } from '@angular/core';
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
export class MantCajaListComponent {
  cajas: ResponseCaja[] = [];
  modalRef?: BsModalRef;
  cajaSelect: ResponseCaja = new  ResponseCaja();
  titleModal: string = "";
  accionModal: number = 0; //1 crea, 2 edita, 3 eliminar
  myFormFilter: FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 3;
  request: RequestFilterGeneric = new RequestFilterGeneric();

  constructor(
    private _route:Router,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private _cajaService: CajaService
  ){
    this.myFormFilter= this.fb.group({
      codigoCaja: ["", []],
      fecha: ["", []],
      usuarioApertura: ["", []],
      usuarioCierre: ["", []],
      estado: ["", []],
      montoApertura: ["", []],
      montoCierre: ["", []],
      montoAdicional: ["", []],
    });
  }

  ngOnInit(): void {
    
    this.filtrar();

  }

  listarcajas() {
    this._cajaService.getAll().subscribe({
      next: (data: ResponseCaja[]) => {
        console.log("Data", data);
        this.cajas = data;
      },
      error: (err) => {
        console.log("error ", err);
      },
      complete: () => {
        //algo
      },
    });
  }

  crearCaja(template: TemplateRef<any>) {
    this.cajaSelect = new ResponseCaja();
    this.titleModal = "Crear un Almacén";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }

  editarCaja(template: TemplateRef<any>, caja: ResponseCaja) {
    this.cajaSelect = caja;
    this.titleModal = "Modificar Almacén";
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
      this.listarcajas();
    }
  }


  eliminarRegistro(codigocajas:number)
  {
    let result = confirm("¿Estas seguro de eliminar el registro?")

    if(result)
    {
      this._cajaService.delete(codigocajas).subscribe({
        next:(data:number) => {
          alert("El registro fue eliminado de manera correcta");
        },
        error:() => {},
        complete:() => {
          this.listarcajas();
        }
      })
    }
  }

  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigocajas", value: valueForm.codigocajas});
    this.request.filtros.push({name:"nombre", value: valueForm.nombre});
    this.request.filtros.push({name:"capacidadLimite", value: valueForm.capacidadLimite});
    this.request.filtros.push({name:"estado", value: valueForm.estado});

    this._cajaService.genericFilter(this.request).subscribe({
      next: (data: ResponseFilterGeneric<ResponseCaja> ) => {
        console.log(data);
        this.cajas = data.lista;
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
