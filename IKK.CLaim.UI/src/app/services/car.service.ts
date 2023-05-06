import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { CommonVariables } from 'src/app/components/common/Statics';
import { RequestDto } from 'src/app/models/RequestDto';
import { threadId } from 'worker_threads';

import { RegisterCarDto } from 'src/app/models/Cars/RegisterCarDto';
import { EditCarDto } from 'src/app/models/Cars/EditCarDto';

@Injectable({
  providedIn: 'root'
})
export class CarService {

    constructor(private http:HttpClient,private statics:CommonVariables) { }
  GetCars(requestDto:RequestDto){
    return this.http.post<any>(this.statics.baseUrl+'GetTypeCars',requestDto);
  }
  RegisterCar(registerCarDto:RegisterCarDto){
    return this.http.post<any>(this.statics.baseUrl+'CreateTypeCar',registerCarDto);     
  }
  ChangeStatus(id:number){
    return this.http.put<any>(this.statics.baseUrl+'ChangeTypeCarstatus?id='+id,{id:id});     
  }
  Delete(id:number){
    return this.http.post<any>(this.statics.baseUrl+'RemoveTypeCar?id='+id,{id:id});     
  }
  Edit(editCarDto:EditCarDto){
    return this.http.post<any>(this.statics.baseUrl+'EditTypeCar',editCarDto);     
  }
  Get(id:number){
    return this.http.post<any>(this.statics.baseUrl+'GetTypeCar?id='+id,{id:id}); 
  }
}
