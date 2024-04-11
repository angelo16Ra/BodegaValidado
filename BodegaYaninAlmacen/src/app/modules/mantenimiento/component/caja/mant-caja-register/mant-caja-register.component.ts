import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { alert_error, alert_success, convertToBoolean } from '../../../../../functions/general.functions';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestCaja } from '../../../models/caja-request.model';
import { ResponseCaja } from '../../../models/caja-response.model';
import { CajaService } from '../../../service/caja.service';
import { MantCajaListComponent } from '../mant-caja-list/mant-caja-list.component';
import { ResponseUsuario } from '../../../models/usuario.response.model';
import { Vcaja } from '../../../models/VCaja.model';

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
export class MantCajaRegisterComponent implements OnInit{
  @Input() title:string = "";
  @Input() cajas:Vcaja = new Vcaja();
  @Input() accion:number = 0;

  @Input() tipoUsuario:ResponseUsuario[]=[];

  @Output() closeModalEmmit = new EventEmitter<boolean>();

  myForm:FormGroup;
  cajaEnvio:RequestCaja = new RequestCaja();


  constructor(
    private fb: FormBuilder,
    private _cajaService: CajaService,
  ) 
  {

    this.myForm = this.fb.group({
      codigoCaja: [{ value: 0, disabled: true }, [Validators.required]],
      codigoUsuario: [null, [Validators.required]],
      fecha: [null, [Validators.required]],
      estado: [null, [Validators.required]],
      montoApertura: [null, [Validators.required]],
      montoCierre: [null, [Validators.required]],
      montoAdicional: [null, [Validators.required]],
    });
  }


  ngOnInit(): void {
    this.myForm.patchValue(this.cajas)

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
    debugger;
    //lamar a nuestro servicio rest ==> crear un nuevo registro en base de datos
    this._cajaService.create(this.cajaEnvio).subscribe({
      next:(data:ResponseCaja)=>{
        console.log(data);
        alert_success("EXCELENTE","Se actualizo de manera correcta")
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

    this._cajaService.update(this.cajaEnvio).subscribe({
      next:(data:ResponseCaja)=>{
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