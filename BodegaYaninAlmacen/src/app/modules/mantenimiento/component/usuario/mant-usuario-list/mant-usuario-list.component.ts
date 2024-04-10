import { CommonModule } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { forkJoin } from 'rxjs';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { SharedModule } from '../../../../shared/shared.module';
import { ResponsePersona } from '../../../models/persona-response.model';
import { ResponseRol } from '../../../models/rol-response.model';
import { Vusuario } from '../../../models/VUsuario.model';
import { PersonaService } from '../../../service/persona.service';
import { RolService } from '../../../service/rol.service';
import { UsuarioService } from '../../../service/usuario.service';
import { MantUsuarioRegisterComponent } from '../mant-usuario-register/mant-usuario-register.component';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-mant-usuario-list',
  standalone: true,
  imports: [
    MantUsuarioRegisterComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-usuario-list.component.html',
  styleUrl: './mant-usuario-list.component.css'
})
export class MantUsuarioListComponent implements OnInit {
  config  = {
    backdrop: true,
    ignoreBackdropClick: true
  };
  
  requestFilterGeneric:RequestFilterGeneric = new RequestFilterGeneric();
  Vusuario:Vusuario[] = [];
  modalRef?: BsModalRef;
  usuarioSelect: Vusuario = new Vusuario();
  titleModal: string = "";
  accionModal: number = 0;
  myFormFilter:FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 3;
  request:RequestFilterGeneric = new RequestFilterGeneric();
  //
  tipoPersona: ResponsePersona[] = [];
  tipoRol: ResponseRol[] = [];


  constructor(
    private _usuarioService: UsuarioService,
    private modalService: BsModalService,
    private _personaService: PersonaService,
    private _rolService: RolService,
    
    private _route:Router,
    private fb: FormBuilder,
  )
  {
    this.myFormFilter= this.fb.group({
      codigoUsuario: ["", []],
      username: ["", []],
      password: ["", []],
      estado: ["", []],
      fechaActualizar: ["", []],
      fechaRegistro: ["", []],
      numeroDocumento: ["", []],
      nombrePersona: ["", []],
      genero: ["", []],
      fechaNacimiento: ["", []],
      correo: ["", []],
      celular: ["", []],
      nombre: ["", []],
    });
  }

  ngOnInit(): void {
    this.filtrar();
    this.listarUsuario();
    this.obtenerListas();
  }


  listarUsuario()
  {
    this._usuarioService.genericFilterView(this.requestFilterGeneric).subscribe({
      next: (data:ResponseFilterGeneric<Vusuario>) => {

        this.Vusuario = data.lista;

        console.log(data);
      },

      error: (err) => {
        console.log(err);
      },

      complete: ()=>{
      }
    });
  }

  nuevoRegistro(template: TemplateRef<any>)
  {
    this.usuarioSelect = new Vusuario();
    this.titleModal = "Nuevo Usuario";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
    
  }
  
  editarRegistro(template: TemplateRef<any>, usuario: Vusuario )
  {
    this.usuarioSelect = usuario;
    this.titleModal = "Editar Usuario";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
    
  }


  obtenerListas(){
    forkJoin([
      this._personaService.getAll(),
      this._rolService.getAll(),
    ]).subscribe({
      next:(data:any) => {
        this.tipoPersona = data[0];
        this.tipoRol = data[1];
      },
      error:(err) => {
        
      },
      complete:() => {
        
      }
    })
  };

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, Object.assign({},{class: "gray modal-lg"},this.config));
  }

  getCloseModalEmmit(res:boolean){
    this.modalRef?.hide();
    if(res)
    {
      this.listarUsuario();
    }
  }

  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoUsuario:", value: valueForm.codigoUsuario});
    this.request.filtros.push({name:"userName:", value: valueForm.userName});
    this.request.filtros.push({name:"password:", value: valueForm.password});
    this.request.filtros.push({name:"estado:", value: valueForm.estado});
    this.request.filtros.push({name:"fechaActualizar:", value: valueForm.fechaActualizar});
    this.request.filtros.push({name:"fechaRegistro:", value: valueForm.fechaRegistro});
    this.request.filtros.push({name:"numeroDocumento:", value: valueForm.numeroDocumento});
    this.request.filtros.push({name:"nombrePersona:", value: valueForm.nombrePersona});
    this.request.filtros.push({name:"apellidoPaterno:", value: valueForm.apellidoPaterno});
    this.request.filtros.push({name:"apellidoMaterno:", value: valueForm.apellidoMaterno});
    this.request.filtros.push({name:"genero:", value: valueForm.genero});
    this.request.filtros.push({name:"fechaNacimiento:", value: valueForm.fechaNacimiento});
    this.request.filtros.push({name:"correo:", value: valueForm.correo});
    this.request.filtros.push({name:"celular:", value: valueForm.celular});
    this.request.filtros.push({name:"nombreRol:", value: valueForm.nombreRol});

    this._usuarioService.genericFilterView(this.request).subscribe({
      next: (data: ResponseFilterGeneric<Vusuario> ) => {
        console.log(data);
        this.Vusuario = data.lista;
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
