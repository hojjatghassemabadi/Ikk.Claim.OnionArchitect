import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl:string="https://localhost:7073/Claem/Login"
  constructor(private http:HttpClient,private router:Router) {

   }
   signIn(loginObj: any){
    const formData = new FormData();
    formData.append("UserName", loginObj.UserName);
    formData.append("Password", loginObj.Password);
             return this.http.post<any>(this.baseUrl,formData);
   }
   signOut(){
     localStorage.clear();
     this.router.navigate(['/login']);
   }
   storeToken(tokenValue: string){
     localStorage.setItem('token',tokenValue)
   }
   getToken(){
     return localStorage.getItem('token')
   }

   isLoggedIn():boolean{
     return !!localStorage.getItem('token')
   }
}
