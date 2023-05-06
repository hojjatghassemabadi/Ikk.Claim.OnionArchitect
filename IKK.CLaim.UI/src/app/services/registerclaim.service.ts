import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CommonVariables } from 'src/app/components/common/Statics';
import { RequestDto } from 'src/app/models/RequestDto';
import { RegisterClaimDto } from 'src/app/models/Claim/RegisterClaimDto';

@Injectable({
  providedIn: 'root'
})
export class RegisterclaimService {

  constructor(private http:HttpClient,private statics:CommonVariables) { }

  initSources(){
    
  }
    
  GetClaims(requestDto:RequestDto){
    
     return this.http.post<any>(this.statics.baseUrl+'GetClaims',requestDto);
  }
  GetClaimPics(id:number){
    
    return this.http.post<any>(this.statics.baseUrl+'GetClaimPics?id='+id,{id:id});
 }
  RegisterClaim(registerClaimDto:FormData){
    return this.http.post<any>(this.statics.baseUrl+'CreateClaim',registerClaimDto);     
  }
  ChangeStatus(id:number){
    return this.http.put<any>(this.statics.baseUrl+'ChangeClaimstatus?id='+id,{id:id});     
  }
  Delete(id:number){
    return this.http.post<any>(this.statics.baseUrl+'RemoveClaim?id='+id,{id:id});     
  }
  DeleteImage(image:string){
    return this.http.post<any>(this.statics.baseUrl+'RemoveImage?image='+image,{image:image});     

  }
  Edit(registerClaimDto:FormData){
    return this.http.post<any>(this.statics.baseUrl+'EditClaim',registerClaimDto);     
  }
  Get(id:number){
    return this.http.post<any>(this.statics.baseUrl+'GetClaim?id='+id,{id:id}); 
  }
  GetCountClaims(){
    return this.http.get<any>(this.statics.baseUrl+'GetCountClaims');
  }
}
