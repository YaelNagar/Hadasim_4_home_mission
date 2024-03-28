import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HMOMembers } from '../classes/HMOMembers';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HMOMembersService {
  baseUrl: string = "https://localhost:44333/api/HMOMembers/"
  allMembers:Array<HMOMembers>=new Array<HMOMembers>()
  
  constructor(public http: HttpClient) { }

  
  getAll():Observable<Array<HMOMembers>>{
    return this.http.get<Array<HMOMembers>>(`${this.baseUrl}GetAll/`)
  }

  GetById(id:Number):Observable<HMOMembers>{
    return this.http.get<HMOMembers>(`${this.baseUrl}GetById/${id}`)
  }

  Add(member:HMOMembers):Observable<number>{
    return this.http.post<number>(`${this.baseUrl}Add/`, member)
  }

  Update(member:HMOMembers):Observable<boolean>{
    debugger
    return this.http.put<boolean>(`${this.baseUrl}Update/`,member)
  }

  Delete(id?:Number):Observable<boolean>{
    return this.http.delete<boolean>(`${this.baseUrl}Delete/${id}`);
  }
}
