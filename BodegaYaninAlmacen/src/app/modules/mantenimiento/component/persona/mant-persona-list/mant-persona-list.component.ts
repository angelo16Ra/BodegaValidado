import { Component, TemplateRef } from '@angular/core';
import { MantPersonaRegisterComponent } from '../mant-persona-register/mant-persona-register.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { Vpersona } from '../../../models/Vpersona.model';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ResponseTipoDocumento } from '../../../models/tipoDocumento-response.model';
import { PersonaService } from '../../../service/persona.service';
import { Router } from '@angular/router';
import { TipoDocumentoService } from '../../../service/tipo-documento.service';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { forkJoin } from 'rxjs';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-mant-persona-list',
  standalone: true,
  imports: [
    MantPersonaRegisterComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-persona-list.component.html',
  styleUrl: './mant-persona-list.component.css'
})
export class MantPersonaListComponent {
  config  = {
    backdrop: true,
    ignoreBackdropClick: true
  };
  
  requestFilterGeneric: RequestFilterGeneric = new RequestFilterGeneric();
  Vpersona:Vpersona[]= [];
  modalRef?: BsModalRef;
  personaSelect: Vpersona = new  Vpersona();
  titleModal: string = "";
  accionModal: number = 0;
  myFormFilter: FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 3;
  request: RequestFilterGeneric = new RequestFilterGeneric();

  tipoDocumento: ResponseTipoDocumento[]=[];

  constructor(
    private _personaService: PersonaService, 
    private modalService: BsModalService,
    private _tipoDocumentoPersona: TipoDocumentoService,

    private _route:Router,
    private fb: FormBuilder,
    
    
  ){
    this.myFormFilter= this.fb.group({
      codigoPersona: ["", []],
      numeroDocumento: ["", []],
      nombre: ["", []],
      apPaterno: ["", []],
      apMaterno: ["", []],
      sexo: ["", []],
      fechaNacimiento: ["", []],
      correo: ["", []],
      celular: ["", []],
      estado: ["", []],
      nombreDocumento: ["", []],
    });
  }


  ngOnInit(): void {
    this.filtrar();
    this.listarPersona();
    this.obtenerListas();

  }

  listarPersona() {
    this._personaService.genericFilterView(this.requestFilterGeneric).subscribe({
      next: (data:ResponseFilterGeneric<Vpersona>) => {

        this.Vpersona = data.lista;

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
    this.personaSelect = new Vpersona();
    this.titleModal = "Nueva persona";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }

  editarRegistro(template: TemplateRef<any>, persona: Vpersona) {
    this.personaSelect = persona;
    this.titleModal = "Editar persona";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
  }

  obtenerListas()
  {
    forkJoin([
      this._tipoDocumentoPersona.getAll(),
    ]).subscribe({
      next:(data:any) => {
        this.tipoDocumento = data[0];
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
      this.listarPersona();
    }
  }

  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoPersona:", value: valueForm.codigoPersona});
    this.request.filtros.push({name:"numeroDocumento:", value: valueForm.numeroDocumento});
    this.request.filtros.push({name:"nombre:", value: valueForm.nombre});
    this.request.filtros.push({name:"apPaterno:", value: valueForm.apPaterno});
    this.request.filtros.push({name:"apMaterno:", value: valueForm.apMaterno});
    this.request.filtros.push({name:"sexo:", value: valueForm.sexo});
    this.request.filtros.push({name:"fechaNacimiento:", value: valueForm.fechaNacimiento});
    this.request.filtros.push({name:"correo:", value: valueForm.correo});
    this.request.filtros.push({name:"celular:", value: valueForm.celular});
    this.request.filtros.push({name:"estado:", value: valueForm.estado});
    this.request.filtros.push({name:"nombreDocumento:", value: valueForm.nombreDocumento});

    this._personaService.genericFilterView(this.request).subscribe({
      next: (data: ResponseFilterGeneric<Vpersona> ) => {
        console.log(data);
        this.Vpersona = data.lista;
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
