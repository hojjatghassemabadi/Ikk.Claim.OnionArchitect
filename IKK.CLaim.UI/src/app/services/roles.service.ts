import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { CommonVariables } from 'src/app/components/common/Statics';
import { RequestDto } from 'src/app/models/RequestDto';
import { threadId } from 'worker_threads';
import { RegisterRoleDto } from 'src/app/models/RegisterRoleDto';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  constructor(private http:HttpClient,private statics:CommonVariables) { }
  GetRoles(requestDto:RequestDto){
    return this.http.post<any>(this.statics.baseUrl+'GetRoles',requestDto);
  }
  RegisterRole(registerRoleDto:RegisterRoleDto){
    return this.http.post<any>(this.statics.baseUrl+'CreateRole',registerRoleDto);     
  }
  ChangeStatus(id:number){
    return this.http.put<any>(this.statics.baseUrl+'ChangeRoleStatus?id='+id,{id:id});     
  }
  Delete(id:number){
    return this.http.post<any>(this.statics.baseUrl+'RemoveRole?id='+id,{id:id});     
  }
  Edit(registerRoleDto:RegisterRoleDto){
    return this.http.post<any>(this.statics.baseUrl+'EditRole',registerRoleDto);     
  }
  Get(id:number){
    return this.http.post<any>(this.statics.baseUrl+'GetRole?id='+id,{id:id}); 
  }
}
