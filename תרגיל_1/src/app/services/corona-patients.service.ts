import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CoronaPatients } from '../classes/CoronaPatients';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CoronaPatientsService {
  baseUrl: string = "https://localhost:44333/api/CoronaPatients/"
  constructor(public http: HttpClient) { }

  GetById(id:number):Observable<CoronaPatients>{
    return this.http.get<CoronaPatients>(`${this.baseUrl}GetById/${id}`)
  }

  Add(member:CoronaPatients):Observable<number>{
    return this.http.post<number>(`${this.baseUrl}Add/`, member)
  }
  
  LastMonthCoronaPatients():Observable<Array<any>>{
    return this.http.get<Array<any>>(`${this.baseUrl}LastMonthCoronaPatients/`)
  }
}
