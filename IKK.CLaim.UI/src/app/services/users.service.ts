import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RequestDto } from '../models/RequestDto';
import { RegisterUserDto } from '../models/RegisterUserDto';
import { threadId } from 'worker_threads';
import { CommonVariables } from 'src/app/components/common/Statics';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  
  constructor(private http:HttpClient,private statics:CommonVariables) { }

  initSources(){
    
  }
    
  GetUsers(requestDto:RequestDto){
    
     return this.http.post<any>(this.statics.baseUrl+'GetUsers',requestDto);
  }
  RegisterUser(registeruserDto:RegisterUserDto){
    return this.http.post<any>(this.statics.baseUrl+'CreateUser',registeruserDto);     
  }
  GetRoles(requestDto:RequestDto){
    return this.http.post<any>(this.statics.baseUrl+'GetRoles',requestDto);
  }
  ChangeStatus(id:number){
    return this.http.put<any>(this.statics.baseUrl+'ChangeStatus?id='+id,{id:id});     
  }
  Delete(id:number){
    return this.http.post<any>(this.statics.baseUrl+'RemoveUser?id='+id,{id:id});     
  }
  Edit(registerUserDto:RegisterUserDto){
    return this.http.post<any>(this.statics.baseUrl+'EditUser',registerUserDto);     
  }
  Get(id:number){
    return this.http.post<any>(this.statics.baseUrl+'GetUser?id='+id,{id:id}); 
  }
}