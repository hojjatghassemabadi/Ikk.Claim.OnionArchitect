import { Component, OnInit } from '@angular/core';
import { PartsService } from '../../../services/parts.service';
import { FormBuilder, FormGroup,Validator,Validators } from '@angular/forms';
import * as Icons from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { RequestDto } from 'src/app/models/RequestDto';
import ValidateForm from 'src/app/helper/validateform';
import { CommonVariables } from 'src/app/components/common/Statics';

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
  constructor(private partsService:PartsService,private fb:FormBuilder,private toastr:ToastrService,private statics:CommonVariables) { }

  ngOnInit(): void {
    this.partform=this.fb.group({
      partName:['',Validators.required],
      partNumber:['',Validators.required],
      status:['',Validators.required]
    });
    this.GetParts();
    
  }
  pageChanged(p:number){
    this.p=p;
   this.GetParts();
 }

  GetParts(){
    debugger;
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
            this.toastr.success(this.statics.CHANGE_STATUS_OK,'Success');
          },
          error:(res:any)=>{
            this.GetParts();
            this.toastr.error(this.statics.CHANGE_STATUS_FAILD,'Error');
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
                  partName:res.partName,
                  partNumber:res.partNumber,
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
        partName:this.partform.value.partName,
        partNumber:this.partform.value.partNumber,
        status:this.partform.value.status
      }
       this.partsService.RegisterPart(this.data)
       .subscribe({
            next:(res)=>{
              this.partform.reset();
              this.GetParts();
              this.toastr.success(this.statics.REGISTER,'Alert');
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
    if(this.partform.valid){
      this.data={
        partName:this.partform.value.partName,
        partNumber:this.partform.value.partNumber,
        status:this.partform.value.status,
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
