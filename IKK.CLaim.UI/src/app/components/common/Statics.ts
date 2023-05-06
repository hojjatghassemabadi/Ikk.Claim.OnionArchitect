import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export abstract class CommonVariables{
    public baseUrl:string="https://localhost:7073/Claem/";

    public REGISTER:string="Register was Successfull";
    public CHANGE_STATUS_OK:string="Change Status was Successfull";
    public CHANGE_STATUS_FAILD:string="Change Status was Failed";
}