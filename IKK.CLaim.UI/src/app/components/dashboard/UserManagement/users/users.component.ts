import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/services/users.service';
import { RequestDto } from 'src/app/models/RequestDto';
import { FormBuilder,FormGroup,Validator,Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';
import ValidateForm from 'src/app/helper/validateform';
import * as Icons from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit {
  checked = Icons.faCheck;
  notchecked=Icons.faClose;
  crash=Icons.faTrash;
  edit=Icons.faEdit;
  userform!:FormGroup;
  data:any={};
  roles:any=[];
  p:number=1;
  pages:any[]=[];
  itemPerPage:number=3;
  totalUsers:any;
  editUser:boolean=false;
  userid:number=0;
  constructor(private userservice:UsersService,private fb:FormBuilder,private toastr:ToastrService) {
    
   }
  public users:any=[];
  public rolelist:any=[];

  ngOnInit(): void {
    this.userform=this.fb.group({
      name:['',Validators.required],
      famil:['',Validators.required],
      userName:['',Validators.required],
      password:['',Validators.required],
      roles:['',Validators.required],
      status:['',Validators.required]
    })

    var request=new RequestDto();
    request.SearchKey='';
    request.Page=this.p;
    request.PageSize=this.itemPerPage;
    this.GetUsers();

    this.userservice.GetRoles(request)
    .subscribe((res:any)=>{
      this.rolelist=res;

    });

  }
  pageChanged(p:number){
     this.p=p;
    this.GetUsers();
  }
  GetUsers(){
    var request=new RequestDto();
    request.SearchKey='';
    request.Page=this.p;
    request.PageSize=this.itemPerPage;
    this.userservice.GetUsers(request)
    .subscribe((res:any)=>{
      this.users=res.users;
      this.totalUsers=res.rowCount;
    });
  }
  delete(id:number){
    this.userservice.Delete(id)
        .subscribe({
          next:(res:any)=>{
            this.GetUsers(); 
            this.toastr.success('Delete was Successfull','Success');
          },
          error:(res:any)=>{
            this.GetUsers();
            this.toastr.error('Delete was Faild','Error');
          }
        })
  }
  cancel(){
    this.editUser=false;
    this.userform.reset();
  }
  get(id:number){

    this.userservice.Get(id)
        .subscribe({
          next:(res:any)=>{
            this.editUser=true;
            this.userid=id;
            this.userform.setValue({
                  name:res.name,
                  status:res.status,
                  famil:res.famil,
                  userName:res.userName,
                  password:res.password,
                  roles:res.roles
            });
            debugger;
           
          },
          error:(res:any)=>{
          }
        })
  }
  changeStatus(id:number){
    this.userservice.ChangeStatus(id)
    .subscribe({
      next:(res:any)=>{
        this.GetUsers(); 
        this.toastr.success('Change Status was Successfull','Success');
      },
      error:(res:any)=>{
        this.GetUsers();
        this.toastr.error('Change Status was Faild','Error');
      }
    })
  }

  onSubmit(){
    if(this.editUser==false){
        if(this.userform.valid){
          let rol=this.userform.value.roles;
          let r:any=[];
          rol.forEach(function(value:any) {
            r.push({id:value});
          });
          this.data={
            userName:this.userform.value.userName,
            password:this.userform.value.password,
            name:this.userform.value.name,
            famil:this.userform.value.famil,
            roles:r
          }
          this.userservice.RegisterUser(this.data)
          .subscribe({
                next:(res)=>{
                  this.userform.reset();
                  this.GetUsers();
                  this.toastr.success('Register was Successfull','Alert');
                },
                error:(res)=>{
                  
                  this.toastr.error('Register was Faild','Alert');
                }
          });
        }else{
          ValidateForm.validateAllFormFiles(this.userform);
          this.toastr.warning('Please Fill All Fields','Alert');
        }
    }else{
      if(this.userform.valid){
        let rol=this.userform.value.roles;
        let r:any=[];
        rol.forEach(function(value:any) {
          r.push({id:value});
        });
        this.data={
          id:this.userid,
          userName:this.userform.value.userName,
          password:this.userform.value.password,
          name:this.userform.value.name,
          famil:this.userform.value.famil,
          status:this.userform.value.status,
          roles:r
        }
        this.userservice.Edit(this.data)
        .subscribe({
              next:(res)=>{
                this.userform.reset();
                this.GetUsers();
                this.toastr.success('Edit was Successfull','Alert');
              },
              error:(res)=>{
                
                this.toastr.error('Edit was Faild','Alert');
              }
        });
      }else{
        ValidateForm.validateAllFormFiles(this.userform);
        this.toastr.warning('Please Fill All Fields','Alert');
      }
    }








  }
}
