import { Observable } from "rxjs";

/**TODO: implementa todos los metodos relacionados al CRUD
 * T ==> REQUEST
 * Y ==> RESPONSE
 */

export interface CrudInterface<T,Y> {
    
    getAll(): Observable<Y[]>;
    create(request:T):Observable<Y>;
    update(request:T):Observable<Y>;
    delete(codigo: number):Observable <number> 
  
    // 






}
