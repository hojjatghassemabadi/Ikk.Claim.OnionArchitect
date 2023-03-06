import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export abstract class CommonVariables{
    public baseUrl:string="https://localhost:7073/Claim/";
}