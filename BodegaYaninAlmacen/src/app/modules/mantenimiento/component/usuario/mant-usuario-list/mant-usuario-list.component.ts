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
import { ProductoService } from '../../../service/producto.service';
import { RolService } from '../../../service/rol.service';
import { UsuarioService } from '../../../service/usuario.service';
import { MantUsuarioRegisterComponent } from '../mant-usuario-register/mant-usuario-register.component';

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
  tileModal = "Editar Usuario";
  accionModal = AccionMantConst.editar;
  //
  tipoPersona: ResponsePersona[] = [];
  tipoRol: ResponseRol[] = [];


  constructor(
    private _usuarioService: UsuarioService,
    private modalService: BsModalService,
    private _personaService: PersonaService,
    private _rolService: RolService,
    
  )
  {

  }

  ngOnInit(): void {
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
    this.tileModal = "Nuevo Usuario";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
    
  }
  
  editarRegistro(template: TemplateRef<any>, usuario: Vusuario )
  {
    this.usuarioSelect = usuario;
    this.tileModal = "Editar Usuario";
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
      this.listarUsuario();
    }
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



}
