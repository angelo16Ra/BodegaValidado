import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CrudInterface } from '../interfaces/crud-interface';

@Injectable({
  providedIn: 'root'
})

/**TODO: implementa todos los metodos relacionados al CRUD
 * T ==> REQUEST
 * Y ==> RESPONSE
 */
export class CrudService <T,Y> implements CrudInterface<T,Y> {

  constructor(
    protected _http: HttpClient,
    @Inject('url_service') public url_service: string

  ) { }

  /**TODO: OBTIENE LA LISTA DE TODA LA TABLA */

  getAll(): Observable<Y[]> {
    return  this._http.get<Y[]>(this.url_service);
  }


  /**TODO: Inserta un registro */
  create(request: T): Observable<Y> {

    return this._http.post<Y>(this.url_service , request) ;
  }

  /**TODO: Actualiza un registro */
  update(request: T): Observable<Y> {
    return this._http.put<Y>(this.url_service , request) ;
  }
  
  /**TODO: Elimina un registro */
  delete(codigoRol: number): Observable<number> {
    return this._http.delete<number>(`${this.url_service}${codigoRol}`);
  }
}
