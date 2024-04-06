import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder,FormGroup,ReactiveFormsModule,Validators } from '@angular/forms';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestRol } from '../../../models/rol-request.model';
import { ResponseRol } from '../../../models/rol-response.model';
import { RolService } from '../../../service/rol.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-mant-rol-multiple',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    SharedModule,
    CommonModule
  ],
  templateUrl: './mant-rol-multiple.component.html',
  styleUrl: './mant-rol-multiple.component.css'
})
export class MantRolMultipleComponent implements OnInit{

  form: FormGroup;
  rolesBack: ResponseRol[] = []

  constructor(
    private _rolService:RolService,
    private fb:FormBuilder
  )
  {
    this.form = this.fb.group({
      roles: this.fb.array([])
    });

  }

  ngOnInit(): void {

    this._rolService.getAll().subscribe({
      next:(data:ResponseRol[]) => {
        this.rolesBack= data;
        this.rolesBack.forEach(x => {
          let rol = this.nuevoRol(x);
          this.rolesArrayForm.push(rol);
        })

      },
      error:() => {

      },
      complete:() => {

      },
    })

  }

  get rolesArrayForm():FormArray{return this.form.get('roles') as FormArray};



  addRol()
  {

    let rol = this.nuevoRol(new RequestRol())
    this.rolesArrayForm.push(rol);


  }

  nuevoRol(rol:RequestRol){
    return this.fb.group({
      codigoRol: [{value: rol.codigoRol, disabled: true},[Validators.required]],
      nombre:  [rol.nombre,[Validators.required]],
      descripcion:  [rol.descripcion,[Validators.required]],
      estado: [rol.estado? "1":"0",[Validators.required]],
    })
  }

  removeRol(i:number)
  {
   this.rolesArrayForm.removeAt(i) 
  }

  save()
  {
    console.log(this.form.getRawValue());
    
  }

}
