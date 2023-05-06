import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import ValidateForm from '../../helper/validateform';
import { FormBuilder, FormGroup,Validator,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsersService } from '../../services/users.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!:FormGroup;
  constructor(private userservice:UsersService,private router: Router,private fb:FormBuilder,private auth:AuthService) { }

  ngOnInit(): void {
    this.loginForm=this.fb.group({
      UserName:['',Validators.required],
      Password:['',Validators.required]
    })
  }

  onSubmit(){
    
    if(this.loginForm.valid){
       this.auth.signIn(this.loginForm.value)
       .subscribe({
         next:(res)=>{
          this.loginForm.reset();
         
         // this.toast.showSuccess("Login is successfully !!", "");
        // this.toastService.show('I am a standard toast');
          this.auth.storeToken(res.token);
          //let snackBarRef = snackBar.open('Message archived');
         // this.toast.success({detail:"SUCCESS",summery:res.message,duration:5000});
          this.router.navigate(['dashboard'])
         },
         error:(err)=>{
           alert("login was error!");
         // this.toastService.show("oxh sdfs dfsdf ", { classname: 'bg-danger text-light', delay: 15000 });
         //  this.toast.showError("Login was not Success", "");
          // let snackBarRef = snackBar.open('Message archived');
          // this.toast.success({detail:"ERROR",summery:"Something when wrong!",duration:5000});
          
        }
       })
    }else{
      ValidateForm.validateAllFormFiles(this.loginForm);
      alert("not valid");
    }
}

}
