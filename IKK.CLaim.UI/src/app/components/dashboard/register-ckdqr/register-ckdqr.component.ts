import { Component, OnInit } from '@angular/core';
import * as Icons from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { FormGroup } from '@angular/forms';
import { RegisterclaimService } from 'src/app/services/registerclaim.service';
import { RequestDto } from 'src/app/models/RequestDto';
import { RegistercqdqrService } from '../../../services/registercqdqr.service';

@Component({
  selector: 'app-register-ckdqr',
  templateUrl: './register-ckdqr.component.html',
  styleUrls: ['./register-ckdqr.component.css']
})
export class RegisterCKDQRComponent implements OnInit {
  ckdqrform!:FormGroup;
  checked = Icons.faCheck;
  notchecked=Icons.faClose;
  crash=Icons.faTrash;
  edit=Icons.faEdit;
  data:any={};
  public claimlist:any=[];
  public cqdqrlist:any=[];
  totalclaims:any;
  p:number=1;
  pages:any[]=[];
  itemPerPage:number=3;
  totalckdqrs:any;
  editckdqr:boolean=false;
  ckdqrid:number=0;
  constructor(private registerclaimService:RegisterclaimService,private cksqrService:RegistercqdqrService) { }

  ngOnInit(): void {
    this.GetClaims();
  }
  pageChanged(p:number){
    this.p=p;
   this.GetClaims();
 }
 GetClaims(){
  var request=new RequestDto();
  request.SearchKey='';
  request.Page=this.p;
  request.PageSize=this.itemPerPage;
  this.registerclaimService.GetClaims(request)
  .subscribe((res:any)=>{
    this.totalclaims=res.rowCount;
    this.claimlist=res.claims;
  });
 }
  delete(id:number){
   
    // this.bachService.Delete(id)
    //     .subscribe({
    //       next:(res:any)=>{
    //         this.GetCKDQR(); 
    //         this.toastr.success('Delete was Successfull','Success');
    //       },
    //       error:(res:any)=>{
    //         this.GetCKDQR();
    //         this.toastr.error('Delete was Faild','Error');
    //       }
    //     })
  }
  get(id:number){
   
    // this.bachService.Get(id)
    //     .subscribe({
    //       next:(res:any)=>{
    //         this.editbatch=true;
    //         this.batchid=id;
    //         this.batchform.setValue({
    //               Name:res.name,
    //               status:res.status

    //         });
            
           
    //       },
    //       error:(res:any)=>{
    //       }
    //     })
  }
  onSubmit(){
  // if(this.editbatch==false){
  //   if(this.batchform.valid){
  //     debugger;
  //     let car=this.batchform.value.cars;
  //     let r:any=[];
  //     r.push({id:car});
  //     this.data={
  //       Name:this.batchform.value.Name,
  //       CarInBatchs:r,
  //       Status:this.batchform.value.status
  //     }
  //      this.bachService.RegisterBatch(this.data)
  //      .subscribe({
  //           next:(res)=>{
  //             this.batchform.reset();
  //             this.GetCKDQR();
  //             this.toastr.success(this.statics.REGISTER,'Alert');
  //           },
  //           error:(res)=>{
              
  //             this.toastr.error('Register was Faild','Alert');
  //           }
  //      });
  //   }else{
  //     ValidateForm.validateAllFormFiles(this.batchform);
  //     this.toastr.warning('Please Fill All Fields','Alert');
  //   }
  // }else{
  //   if(this.batchform.valid){
  //     this.data={
  //       Name:this.batchform.value.Name,
  //       Status:this.batchform.value.status,
  //       id:this.batchid
  //     }
  //      this.bachService.Edit(this.data)
  //      .subscribe({
  //           next:(res)=>{
  //             this.batchform.reset();
  //             this.GetCKDQR();
  //             this.toastr.success('Edit was Successfull','Alert');
  //           },
  //           error:(res)=>{
              
  //             this.toastr.error('Edit was Faild','Alert');
  //           }
  //      });
  //   }else{
  //     ValidateForm.validateAllFormFiles(this.batchform);
  //     this.toastr.warning('Please Fill All Fields','Alert');
  //   }
  // }
  }
}
