import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MantSubCategoriaListComponent } from '../mant-sub-categoria-list/mant-sub-categoria-list.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';
import { VsubCategoria } from '../../../models/VSubCategoria.model';
import { ResponseCategoria } from '../../../models/categoria-response.model';
import { RequestSubCategoria } from '../../../models/subCategoria-request.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SubCategoriaService } from '../../../service/sub-categoria.service';
import { alert_error, alert_success, convertToBoolean } from '../../../../../functions/general.functions';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseSubCategoria } from '../../../models/subCategoria-response.model';

@Component({
  selector: 'app-mant-sub-categoria-register',
  standalone: true,
  imports: [
    MantSubCategoriaListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-sub-categoria-register.component.html',
  styleUrl: './mant-sub-categoria-register.component.css'
})
export class MantSubCategoriaRegisterComponent implements OnInit{

  @Input() title:string = "";
  @Input() subCategorias:VsubCategoria = new VsubCategoria();
  @Input() accion:number = 0;

  @Input() tipoCategoria:ResponseCategoria[]=[];

  @Output() closeModalEmmit = new EventEmitter<boolean>();

  myForm:FormGroup;
  subCategoriaEnvio:RequestSubCategoria = new RequestSubCategoria();


  constructor(
    private fb: FormBuilder,
    private _subCategoriaService: SubCategoriaService,
  ) 
  {

    this.myForm = this.fb.group({
      codigoSubCategoria: [{ value: 0, disabled: true }, [Validators.required]],
      codigoCategoria: [null, [Validators.required]],
      nombre: [null, [Validators.required]],
      descripcion: [null, [Validators.required]],
      estado: [null, [Validators.required]],
      fechaRegistro: [null, [Validators.required]],
      fechaActualizacion: [null, [Validators.required]],
    });
  }


  ngOnInit(): void {
    this.myForm.patchValue(this.subCategorias)

  }

  guardar()
  {
    this.subCategoriaEnvio= this.myForm.getRawValue();

    this.subCategoriaEnvio.estado = convertToBoolean(this.subCategoriaEnvio.estado.toString());
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
    this._subCategoriaService.create(this.subCategoriaEnvio).subscribe({
      next:(data:ResponseSubCategoria)=>{
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

    this._subCategoriaService.update(this.subCategoriaEnvio).subscribe({
      next:(data:ResponseSubCategoria)=>{
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
