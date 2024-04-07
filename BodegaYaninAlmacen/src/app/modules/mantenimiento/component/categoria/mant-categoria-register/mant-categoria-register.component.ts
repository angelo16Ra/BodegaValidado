import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { alert_error, alert_success, convertToBoolean } from '../../../../../functions/general.functions';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestCategoria } from '../../../models/categoria-request.model';
import { ResponseCategoria } from '../../../models/categoria-response.model';
import { CategoriaService } from '../../../service/categoria.service';
import { MantCategoriaListComponent } from '../mant-categoria-list/mant-categoria-list.component';

@Component({
  selector: 'app-mant-categoria-register',
  standalone: true,
  imports: [
    MantCategoriaListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-categoria-register.component.html',
  styleUrl: './mant-categoria-register.component.css'
})
export class MantCategoriaRegisterComponent {
  @Input() title:string = "";
  @Input() categoria:RequestCategoria = new RequestCategoria();
  @Input() accion:number = 0;

  @Output() closeModalEmmit = new EventEmitter<boolean>();

  myForm:FormGroup;
  categoriaEnvio:RequestCategoria = new RequestCategoria();


  constructor(
    private fb: FormBuilder,
    private _categoriaService: CategoriaService,
  ) 
  {
    // Formulario para la solicitud de almacén
    this.myForm = this.fb.group({
      codigoCategoria: [{ value: 0, disabled: true }, [Validators.required]],
      nombre: [null, [Validators.required]],
      descripcion: [null, [Validators.required]],
      estado: [null, [Validators.required]],
      fechaRegistro: [null, [Validators.required]],
      fechaActualizacion: [null, [Validators.required]],
    });
  }


  ngOnInit(): void {

    console.log("title ==>", this.title);
    console.log("categoria ==>", this.categoria);

    this.myForm.patchValue(this.categoria)
  }

  guardar()
  {

    this.categoriaEnvio= this.myForm.getRawValue();

    this.categoriaEnvio.estado = convertToBoolean(this.categoriaEnvio.estado.toString());

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
    this._categoriaService.create(this.categoriaEnvio).subscribe({
      next:(data:ResponseCategoria)=>{
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

    this._categoriaService.update(this.categoriaEnvio).subscribe({
      next:(data:ResponseCategoria)=>{
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
