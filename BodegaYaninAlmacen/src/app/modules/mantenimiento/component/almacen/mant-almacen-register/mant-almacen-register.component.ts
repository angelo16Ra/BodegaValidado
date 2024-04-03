import { CommonModule } from '@angular/common';
import { Component, input, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EventEmitter } from '@angular/core';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { convertToBoolean } from '../../../../../functions/general.functions';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestAlmacene } from '../../../models/almacen-request.model';
import { ResponseAlmacene } from '../../../models/almacen-response.model';
import { AlmacenService } from '../../../service/almacen.service';
import { MantAlmacenListComponent } from '../mant-almacen-list/mant-almacen-list.component';

@Component({
  selector: 'app-mant-almacen-register',
  standalone: true,
  imports: [
    MantAlmacenListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-almacen-register.component.html',
  styleUrl: './mant-almacen-register.component.css'
})
export class MantAlmacenRegisterComponent {

  @Input() title:string = "";
  @Input() almacene:RequestAlmacene = new RequestAlmacene();
  @Input() accion:number = 0;

  @Output() closeModalEmmit = new EventEmitter<boolean>();

  myForm:FormGroup;
  almacenEnvio:RequestAlmacene = new RequestAlmacene();


  constructor(
    private fb: FormBuilder,
    private _almacenService: AlmacenService,
  ) 
  {

    this.myForm = this.fb.group({
      codigoAlmacenes: [{ value: 0, disabled: true }, [Validators.required]],
      nombre: [null, [Validators.required]],
      capacidadLimite: [null, [Validators.required]],
      estado: [null, [Validators.required]],
    });
  }


  ngOnInit(): void {

    console.log("title ==>", this.title);
    console.log("almacene ==>", this.almacene);

    this.myForm.patchValue(this.almacene)
  }

  guardar()
  {

    this.almacenEnvio= this.myForm.getRawValue();

    this.almacenEnvio.estado = convertToBoolean(this.almacenEnvio.estado.toString());

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
    this._almacenService.create(this.almacenEnvio).subscribe({
      next:(data:ResponseAlmacene)=>{
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

    this._almacenService.update(this.almacenEnvio).subscribe({
      next:(data:ResponseAlmacene)=>{
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
