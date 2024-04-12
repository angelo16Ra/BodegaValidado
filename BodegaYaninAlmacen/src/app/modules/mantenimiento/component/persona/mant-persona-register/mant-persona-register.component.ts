import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SharedModule } from '../../../../shared/shared.module';
import { MantPersonaListComponent } from '../mant-persona-list/mant-persona-list.component';
import { Vpersona } from '../../../models/Vpersona.model';
import { ResponsePersona } from '../../../models/persona-response.model';
import { ResponseTipoDocumento } from '../../../models/tipoDocumento-response.model';
import { RequestPersona } from '../../../models/persona-request.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonaService } from '../../../service/persona.service';
import { alert_error, alert_success, convertToBoolean } from '../../../../../functions/general.functions';
import { AccionMantConst } from '../../../../../constans/general.constants';

@Component({
  selector: 'app-mant-persona-register',
  standalone: true,
  imports: [
    MantPersonaListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-persona-register.component.html',
  styleUrl: './mant-persona-register.component.css'
})
export class MantPersonaRegisterComponent {
  @Input() title:string = "";
  @Input() persona:Vpersona = new Vpersona();
  @Input() accion:number = 0;

  @Input() tipoDocumento: ResponseTipoDocumento[]=[];

  @Output() closeModalEmmit = new EventEmitter<boolean>();

  myForm:FormGroup;
  personaEnvio:RequestPersona = new RequestPersona();

  constructor(
    private fb: FormBuilder,
    private _personaService: PersonaService,
  ) 
  {
    this.myForm = this.fb.group({
      codigoPersona: [{ value: 0, disabled: true }, [Validators.required]],
      codigoDocumento: [null, [Validators.required]],
      numeroDocumento: [null, [Validators.required]],
      nombre: [null, [Validators.required]],
      apPaterno: [null, [Validators.required]],
      apMaterno: [null, [Validators.required]],
      sexo: [null, [Validators.required]],
      fechaNacimiento: [null, [Validators.required]],
      correo: [null, [Validators.required]],
      celular: [null, [Validators.required]],
      estado: [null, [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.myForm.patchValue(this.persona)

  }

  guardar()
  {
    this.personaEnvio= this.myForm.getRawValue();
    
    this.personaEnvio.estado = convertToBoolean(this.personaEnvio.estado.toString());
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
    this._personaService.create(this.personaEnvio).subscribe({
      next:(data:ResponsePersona)=>{
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

    this._personaService.update(this.personaEnvio).subscribe({
      next:(data:ResponsePersona)=>{
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
