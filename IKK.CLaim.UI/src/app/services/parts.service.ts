import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { CommonVariables } from 'src/app/components/common/Statics';
import { RequestDto } from 'src/app/models/RequestDto';
import { threadId } from 'worker_threads';

import { EditPartDto } from 'src/app/models/Parts/EditPartDto';
import { RegisterPartDto } from 'src/app/models/Parts/RegisterPartDto';

@Injectable({
  providedIn: 'root'
})
export class PartsService {

  constructor(private http:HttpClient,private statics:CommonVariables) { }
  GetParts(requestDto:RequestDto){
    return this.http.post<any>(this.statics.baseUrl+'GetParts',requestDto);
  }
  RegisterPart(registerPartDto:RegisterPartDto){
    return this.http.post<any>(this.statics.baseUrl+'CreatePart',registerPartDto);     
  }
  ChangeStatus(id:number){
    return this.http.put<any>(this.statics.baseUrl+'ChangePartstatus?id='+id,{id:id});     
  }
  Delete(id:number){
    return this.http.post<any>(this.statics.baseUrl+'RemovePart?id='+id,{id:id});     
  }
  Edit(registerPartDto:EditPartDto){
    return this.http.post<any>(this.statics.baseUrl+'EditPart',registerPartDto);     
  }
  Get(id:number){
    return this.http.post<any>(this.statics.baseUrl+'GetPart?id='+id,{id:id}); 
  }
}
