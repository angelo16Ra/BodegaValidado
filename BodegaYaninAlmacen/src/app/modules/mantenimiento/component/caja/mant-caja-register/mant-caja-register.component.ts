import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { convertToBoolean } from '../../../../../functions/general.functions';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestCaja } from '../../../models/caja-request.model';
import { ResponseCaja } from '../../../models/caja-response.model';
import { CajaService } from '../../../service/caja.service';
import { MantCajaListComponent } from '../mant-caja-list/mant-caja-list.component';

@Component({
  selector: 'app-mant-caja-register',
  standalone: true,
  imports: [
    MantCajaListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-caja-register.component.html',
  styleUrl: './mant-caja-register.component.css'
})
export class MantCajaRegisterComponent {
  @Input() title:string = "";
  @Input() caja:RequestCaja = new RequestCaja();
  @Input() accion:number = 0;

  @Output() closeModalEmmit = new EventEmitter<boolean>();

  myForm:FormGroup;
  cajaEnvio:RequestCaja = new RequestCaja();


  constructor(
    private fb: FormBuilder,
    private _cajaService: CajaService,
  ) 
  {
    // Formulario para la solicitud de almacén
    this.myForm = this.fb.group({
      codigoCaja: [{ value: 0, disabled: true }, [Validators.required]],
      fecha: [null, [Validators.required]],
      usuarioApertura: [null, [Validators.required]],
      usuarioCierre: [null, [Validators.required]],
      estado: [null, [Validators.required]],
      montoApertura: [null, [Validators.required]],
      montoCierre: [null, [Validators.required]],
      montoAdicional: [null, [Validators.required]],
    });
  }


  ngOnInit(): void {

    console.log("title ==>", this.title);
    console.log("rol ==>", this.caja);

    this.myForm.patchValue(this.caja)
  }

  guardar()
  {

    this.cajaEnvio= this.myForm.getRawValue();

    this.cajaEnvio.estado = convertToBoolean(this.cajaEnvio.estado.toString());

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
    this._cajaService.create(this.cajaEnvio).subscribe({
      next:(data:ResponseCaja)=>{
        alert("creado de forma correcta")
      },
      error:()=>{
        alert("ocurrio un error la momento de crear")
      },
      complete:()=>{
        this.cerrarModal(true);
      },
    });
  }

  editarRegistro()
  {

    this._cajaService.update(this.cajaEnvio).subscribe({
      next:(data:ResponseCaja)=>{
        alert("actualizado de forma correcta")
      },
      error:()=>{
        alert("ocurrio un error la momento de actualizar")
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
