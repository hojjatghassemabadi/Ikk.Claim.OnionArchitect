import { Component, OnInit } from '@angular/core';
import * as Icons from '@fortawesome/free-solid-svg-icons';
import { FormBuilder, FormGroup,Validator,Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RequestDto } from 'src/app/models/RequestDto';
import { PartsService } from '../../../services/parts.service';

@Component({
  selector: 'app-part-declaration',
  templateUrl: './part-declaration.component.html',
  styleUrls: ['./part-declaration.component.css']
})
export class PartDeclarationComponent implements OnInit {
  checked = Icons.faCheck;
  notchecked=Icons.faClose;
  crash=Icons.faTrash;
  edit=Icons.faEdit;
  partform!:FormGroup;
  data:any={};
  public partlist:any=[];
  p:number=1;
  pages:any[]=[];
  itemPerPage:number=3;
  totalParts:any;
  editpart:boolean=false;
  partid:number=0;
  constructor(private partsService:PartsService,private fb:FormBuilder,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.partform=this.fb.group({
      partname:['',Validators.required],
      partnumber:['',Validators.required],
      status:['',Validators.required]
    });
    this.GetParts();
    
  }
  pageChanged(p:number){
    this.p=p;
   this.GetParts();
 }

  GetParts(){
    var request=new RequestDto();
    request.SearchKey='';
    request.Page=this.p;
    request.PageSize=this.itemPerPage;
    this.partsService.GetParts(request)
    .subscribe((res:any)=>{
      this.totalParts=res.rowCount;
      this.partlist=res;
    });
  }
  changeStatus(id:number){
   
    this.partsService.ChangeStatus(id)
        .subscribe({
          next:(res:any)=>{
            this.GetParts(); 
            this.toastr.success('Change Status was Successfull','Success');
          },
          error:(res:any)=>{
            this.GetParts();
            this.toastr.error('Change Status was Faild','Error');
          }
        })
  }
  delete(id:number){
   
    this.partsService.Delete(id)
        .subscribe({
          next:(res:any)=>{
            this.GetParts(); 
            this.toastr.success('Delete was Successfull','Success');
          },
          error:(res:any)=>{
            this.GetParts();
            this.toastr.error('Delete was Faild','Error');
          }
        })
  }
  get(id:number){
   
    this.partsService.Get(id)
        .subscribe({
          next:(res:any)=>{
            this.editpart=true;
            this.partid=id;
            this.partform.setValue({
                  name:res.name,
                  status:res.status

            });
            
           
          },
          error:(res:any)=>{
          }
        })
  }
  onSubmit(){
  if(this.editpart==false){
    if(this.partform.valid){
      this.data={
        name:this.partform.value.name,
        status:this.partform.value.status,
      }
       this.partsService.RegisterPart(this.data)
       .subscribe({
            next:(res)=>{
              this.roleform.reset();
              this.GetParts();
              this.toastr.success('Register was Successfull','Alert');
            },
            error:(res)=>{
              
              this.toastr.error('Register was Faild','Alert');
            }
       });
    }else{
      ValidateForm.validateAllFormFiles(this.partform);
      this.toastr.warning('Please Fill All Fields','Alert');
    }
  }else{
    if(this.partsService.valid){
      this.data={
        name:this.partsService.value.name,
        status:this.partsService.value.status,
        id:this.partid
      }
       this.partsService.Edit(this.data)
       .subscribe({
            next:(res)=>{
              this.partform.reset();
              this.GetParts();
              this.toastr.success('Edit was Successfull','Alert');
            },
            error:(res)=>{
              
              this.toastr.error('Edit was Faild','Alert');
            }
       });
    }else{
      ValidateForm.validateAllFormFiles(this.partform);
      this.toastr.warning('Please Fill All Fields','Alert');
    }
  }
  }

}
