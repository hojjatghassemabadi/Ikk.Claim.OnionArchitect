import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { CommonVariables } from 'src/app/components/common/Statics';
import { RequestDto } from 'src/app/models/RequestDto';
import { EditBatchDto } from 'src/app/models/Batch/EditBatchDto';
import { RegisterBatchDto } from 'src/app/models/Batch/RegisterBatchDto';


@Injectable({
  providedIn: 'root'
})
export class BachService {

  constructor(private http:HttpClient,private statics:CommonVariables) { }

  initSources(){
    
  }
    
  GetBatchs(requestDto:RequestDto){
    
     return this.http.post<any>(this.statics.baseUrl+'GetBatchs',requestDto);
  }
  RegisterBatch(registerbatchDto:RegisterBatchDto){
    return this.http.post<any>(this.statics.baseUrl+'CreateBatch',registerbatchDto);     
  }
  GetTypeCars(requestDto:RequestDto){
    return this.http.post<any>(this.statics.baseUrl+'GetTypeCars',requestDto);
  }
  ChangeStatus(id:number){
    return this.http.put<any>(this.statics.baseUrl+'ChangeBatchstatus?id='+id,{id:id});     
  }
  Delete(id:number){
    return this.http.post<any>(this.statics.baseUrl+'RemoveBatch?id='+id,{id:id});     
  }
  Edit(registerbatchDto:RegisterBatchDto){
    return this.http.post<any>(this.statics.baseUrl+'EditBatch',registerbatchDto);     
  }
  Get(id:number){
    return this.http.post<any>(this.statics.baseUrl+'GetCarInBatch?id='+id,{id:id}); 
  }
}
