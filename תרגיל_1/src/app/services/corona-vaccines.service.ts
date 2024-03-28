import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CoronaVaccines } from '../classes/CoronaVaccines';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CoronaVaccinesService {
  baseUrl: string = "https://localhost:44333/api/CoronaVaccines/"
  allMembers:Array<CoronaVaccines>=new Array<CoronaVaccines>()
  
  constructor(public http: HttpClient) { }
  
  getAll():Observable<Array<CoronaVaccines>>{
    return this.http.get<Array<CoronaVaccines>>(`${this.baseUrl}GetAll/`)
  }
}
