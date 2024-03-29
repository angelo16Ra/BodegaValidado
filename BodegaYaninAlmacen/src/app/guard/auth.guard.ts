import { Injectable } from '@angular/core';
import { CanActivateFn } from '@angular/router';

// Injectable({
//   providedIn: 'root'
// })


export const authGuard: CanActivateFn = (route, state) => {

  let token = sessionStorage.getItem('token');

  if (!token)
  {
    alert("guard => no iniciaste sesion")
    return false;

  }

  return true;
};
