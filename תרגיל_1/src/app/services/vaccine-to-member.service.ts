import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { VaccineToMember } from '../classes/VaccineToMember';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VaccineToMemberService {
  baseUrl: string = "https://localhost:44333/api/VaccineToMember/"
  constructor(public http: HttpClient) { }

  GetById(id:number):Observable<VaccineToMember>{
    return this.http.get<VaccineToMember>(`${this.baseUrl}GetById/${id}`)
  }

  Add(member:VaccineToMember):Observable<number>{
    return this.http.post<number>(`${this.baseUrl}Add/`, member)
  }

  CountMemberVaccine():Observable<number>{
    return this.http.get<number>(`${this.baseUrl}CountMemberVaccine/`)
  }
}
