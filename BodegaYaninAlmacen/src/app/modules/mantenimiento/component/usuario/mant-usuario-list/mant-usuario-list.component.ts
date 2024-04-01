import { CommonModule } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { SharedModule } from '../../../../shared/shared.module';
import { ResponseUsuario } from '../../../models/usuario.response.model';
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

  usuarios: ResponseUsuario[] = [];
  modalRef?: BsModalRef;
  usuarioSelected: ResponseUsuario = new  ResponseUsuario();
  titleModal: string = "";
  accionModal: number = 0; //1 crea, 2 edita, 3 eliminar

  constructor(
    private _route:Router,
    private modalService: BsModalService,
    private _usuarioServices:UsuarioService
  )
  {

  }
    ngOnInit(): void {
    
      this.listarUsuarios();
  
    }

  listarUsuarios()
  {
    this._usuarioServices.getAll().subscribe({
      next: (data:ResponseUsuario[])=> {
        console.log("Data", data);
        this.usuarios=data;
        
      },
      error: (err)=> {
        console.log("error ",err);
      },
      complete: ()=> {
        //algo
      },
    });
  }



  crearUsuario(template: TemplateRef<any>)
  {
    this.usuarioSelected= new ResponseUsuario();
    this.titleModal="Crear un Usuario";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }
  editarUsuario(template: TemplateRef<any>, usuario:ResponseUsuario)
  {
    this.usuarioSelected = usuario;
    this.titleModal="Modificar Usuario";
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
      this.listarUsuarios();
    }
  }

  eliminarRegistro(codigoUsuario:number)
  {
    let result = confirm("¿Estas seguro de eliminar el registro?")

    if(result)
    {
      this._usuarioServices.delete(codigoUsuario).subscribe({
        next:(data:number) => {
          alert("El registro fue eliminado de manera correcta");
        },
        error:() => {},
        complete:() => {
          this.listarUsuarios();
        }
      })
    }
  }
}