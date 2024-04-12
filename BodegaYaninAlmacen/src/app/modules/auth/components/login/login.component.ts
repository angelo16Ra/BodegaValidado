import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginResponse } from '../../../../models/login-response.model';
import { RequestLogin } from '../../models/login-request.models';
import { AuthService } from '../../service/auth.service';
import { alert_error, alert_success } from '../../../../functions/general.functions';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;
  requestLogin: RequestLogin = new RequestLogin();

  constructor(
    private fb: FormBuilder,
    private _authService: AuthService,
    private _router: Router
  ) {
    // Inicializa el formulario dentro del constructor
    this.loginForm = this.fb.group({
      username: [null, [Validators.required]],
      password: [null, [Validators.required]]
    });
  }

  login() {
    console.log(this.loginForm.getRawValue());

    this.requestLogin = this.loginForm.getRawValue();

    this._authService.login(this.requestLogin).subscribe({
      next: (data: LoginResponse) => {
        console.log(data);
        alert_success("Correcto","El login Correcto")
        this._router.navigate(['dashboard']);
        if (data.success) {
          sessionStorage.setItem('token', data.token);
          sessionStorage.setItem('idUsuario', data.usuario.codigoUsuario.toString());
          sessionStorage.setItem('username', data.usuario.username);
          sessionStorage.setItem('nombre', data.persona.nombre);
          sessionStorage.setItem('codigoRol', data.rol.codigoRol.toString());
        } else {
          return;
        }
      },
      error: (error) => { 
        alert_error("INCORRECTO","Los datos incorrectos")
      },
      complete: () => { },
    });
  }
}
