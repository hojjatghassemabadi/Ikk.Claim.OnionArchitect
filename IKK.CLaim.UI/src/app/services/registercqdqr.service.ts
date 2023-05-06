import { Injectable } from '@angular/core';
import { RequestDto } from 'src/app/models/RequestDto';
import { HttpClient } from '@angular/common/http';
import { CommonVariables } from 'src/app/components/common/Statics';
import { RegisterCKDQRDto } from 'src/app/models/CKDQR/RegisterCKDQRDto';

@Injectable({
  providedIn: 'root'
})
export class RegistercqdqrService {

  constructor(private http:HttpClient,private statics:CommonVariables) { }
  GetClaims(requestDto:RequestDto){

    return this.http.post<any>(this.statics.baseUrl+'GetClaims',requestDto);
 }
 RegisterClaim(registerCKDQRDto:RegisterCKDQRDto){
   return this.http.post<any>(this.statics.baseUrl+'CreateClaim',registerCKDQRDto);     
 }
 ChangeStatus(id:number){
   return this.http.put<any>(this.statics.baseUrl+'ChangeClaimstatus?id='+id,{id:id});     
 }
 Delete(id:number){
   return this.http.post<any>(this.statics.baseUrl+'RemoveClaim?id='+id,{id:id});     
 }
 Edit(registerCKDQRDto:RegisterCKDQRDto){
   return this.http.post<any>(this.statics.baseUrl+'EditClaim',registerCKDQRDto);     
 }
 Get(id:number){
   return this.http.post<any>(this.statics.baseUrl+'GetClaim?id='+id,{id:id}); 
 }
}
