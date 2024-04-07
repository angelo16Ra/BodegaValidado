import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TipoDocumentoService } from '../../../service/tipo-documento.service';
import { RequestTipoDocumento } from '../../../models/tipoDocumento-request.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseTipoDocumento } from '../../../models/tipoDocumento-response.model';
import { MantTipoDocumentoListComponent } from '../mant-tipo-documento-list/mant-tipo-documento-list.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';
import { alert_error, alert_success } from '../../../../../functions/general.functions';

@Component({
  selector: 'app-mant-tipo-documento-register',
  standalone: true,
  imports: [
    MantTipoDocumentoListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-tipo-documento-register.component.html',
  styleUrl: './mant-tipo-documento-register.component.css'
})
export class MantTipoDocumentoRegisterComponent implements OnInit {

  @Input() title:string = "";
  @Input() documento:RequestTipoDocumento = new  RequestTipoDocumento();
  @Input() accion:number = 0;


  /** TODO: DECLARANDO  VARIABLES DE SALIDA */
  @Output() closeModalEmmit = new EventEmitter<boolean>();
  

  /** TODO: DECLARANDO  VARIABLES INTERNAS */
  myForm:FormGroup;
  documentoEnvio:RequestTipoDocumento = new RequestTipoDocumento();


  /** TODO: DECLARANDO  EL CONSTRUNCTOR */

  constructor(
    private fb:FormBuilder,
    private _documentoService:TipoDocumentoService,
  ){
    //nuestro formulario rol request
    this.myForm= this.fb.group({

      codigoDocumento: [{value:0,disabled: true},[Validators.required]],
      nombre:  [null,[Validators.required]],
      descripcion:  [null,[Validators.required]],
    });
  }




  ngOnInit(): void {

    console.log("title ==>", this.title);
    console.log("rol ==>", this.documento);

    this.myForm.patchValue(this.documento)


  }

  guardar()
  {

    this.documentoEnvio= this.myForm.getRawValue();
    
    switch(this.accion){
      case AccionMantConst.crear: 
        // crear nuevo registro
        this.crearRegistro();
        break;
      case AccionMantConst.editar: 
        // inactivar 
        this.editarRegistro();
        break;
      case AccionMantConst.eliminar:  
       // eliminar registro  
        // en el formulario el eliminar no se implementa pero se pone el ejemplo para 
        //que la lectura de codigo sea mas sencillo
        break;
    }
  }

  crearRegistro()
  {
    //lamar a nuestro servicio rest ==> crear un nuevo registro en base de datos
    this._documentoService.create(this.documentoEnvio).subscribe({
      next:(data:ResponseTipoDocumento)=>{
        alert_success("EXCELENTE","Se creo de manera correcta")
      },
      error:()=>{
        alert_error("ERROR","ocurrio un error la momento de añadir")
      },
      complete:()=>{
        this.cerrarModal(true);
      },
    });
  }

  editarRegistro()
  {

    this._documentoService.update(this.documentoEnvio).subscribe({
      next:(data:ResponseTipoDocumento)=>{
        alert_success("EXCELENTE","Se actualizo de manera correcta")
      },
      error:()=>{
        alert_error("ERROR","ocurrio un error la momento de actualizar")
      },
      complete:()=>{
        this.cerrarModal(true);
      },
    });
    
  }

  cerrarModal(res:boolean)
  {

    //true ==> hubo modificacion en base de datos  ==> necesito volver a cargar la lista
    //false ==> no hubo modificacion en base de datos  ==> no necesito volver a cargar la lista
    this.closeModalEmmit.emit(res);

    
  }

}
