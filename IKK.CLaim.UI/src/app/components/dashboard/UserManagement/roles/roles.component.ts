import { Component, OnInit } from '@angular/core';
import { RolesService } from '../../../../services/roles.service';
import { FormBuilder, FormGroup,Validator,Validators } from '@angular/forms';
import * as Icons from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { RequestDto } from 'src/app/models/RequestDto';
import ValidateForm from 'src/app/helper/validateform';


@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
export class RolesComponent implements OnInit {
  checked = Icons.faCheck;
  notchecked=Icons.faClose;
  crash=Icons.faTrash;
  edit=Icons.faEdit;
  //faregular=faregular;
  roleform!:FormGroup;
  data:any={};
  public rolelist:any=[];
  p:number=1;
  pages:any[]=[];
  itemPerPage:number=3;
  totalRoles:any;
  editrole:boolean=false;
  roleid:number=0;
  constructor(private roleService:RolesService,private fb:FormBuilder,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.roleform=this.fb.group({
     
        name:['',Validators.required],
        status:['',Validators.required]
       
      });
    this.GetRoles();
    
  }
  pageChanged(p:number){
    this.p=p;
   this.GetRoles();
 }

  GetRoles(){
    var request=new RequestDto();
    request.SearchKey='';
    request.Page=this.p;
    request.PageSize=this.itemPerPage;
    this.roleService.GetRoles(request)
    .subscribe((res:any)=>{
      this.totalRoles=res.rowCount;
      this.rolelist=res;
    });
  }
  changeStatus(id:number){
   
    this.roleService.ChangeStatus(id)
        .subscribe({
          next:(res:any)=>{
            this.GetRoles(); 
            this.toastr.success('Change Status was Successfull','Success');
          },
          error:(res:any)=>{
            this.GetRoles();
            this.toastr.error('Change Status was Faild','Error');
          }
        })
  }
  delete(id:number){
   
    this.roleService.Delete(id)
        .subscribe({
          next:(res:any)=>{
            this.GetRoles(); 
            this.toastr.success('Delete was Successfull','Success');
          },
          error:(res:any)=>{
            this.GetRoles();
            this.toastr.error('Delete was Faild','Error');
          }
        })
  }
  get(id:number){
   
    this.roleService.Get(id)
        .subscribe({
          next:(res:any)=>{
            this.editrole=true;
            this.roleid=id;
            this.roleform.setValue({
                  name:res.name,
                  status:res.status

            });
            
           
          },
          error:(res:any)=>{
          }
        })
  }
  onSubmit(){
  if(this.editrole==false){
    if(this.roleform.valid){
      this.data={
        name:this.roleform.value.name,
        status:this.roleform.value.status,
      }
       this.roleService.RegisterRole(this.data)
       .subscribe({
            next:(res)=>{
              this.roleform.reset();
              this.GetRoles();
              this.toastr.success('Register was Successfull','Alert');
            },
            error:(res)=>{
              
              this.toastr.error('Register was Faild','Alert');
            }
       });
    }else{
      ValidateForm.validateAllFormFiles(this.roleform);
      this.toastr.warning('Please Fill All Fields','Alert');
    }
  }else{
    if(this.roleform.valid){
      this.data={
        name:this.roleform.value.name,
        status:this.roleform.value.status,
        id:this.roleid
      }
       this.roleService.Edit(this.data)
       .subscribe({
            next:(res)=>{
              this.roleform.reset();
              this.GetRoles();
              this.toastr.success('Edit was Successfull','Alert');
            },
            error:(res)=>{
              
              this.toastr.error('Edit was Faild','Alert');
            }
       });
    }else{
      ValidateForm.validateAllFormFiles(this.roleform);
      this.toastr.warning('Please Fill All Fields','Alert');
    }
  }
  }
}
