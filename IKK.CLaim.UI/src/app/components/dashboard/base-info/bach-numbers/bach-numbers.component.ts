import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validator,Validators } from '@angular/forms';
import * as Icons from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { RequestDto } from 'src/app/models/RequestDto';
import ValidateForm from 'src/app/helper/validateform';
import { CommonVariables } from 'src/app/components/common/Statics';
import { BachService } from 'src/app/services/bach.service';
import { CarService } from '../../../../services/car.service';



@Component({
  selector: 'app-bach-numbers',
  templateUrl: './bach-numbers.component.html',
  styleUrls: ['./bach-numbers.component.css']
})
export class BachNumbersComponent implements OnInit {

  checked = Icons.faCheck;
  notchecked=Icons.faClose;
  crash=Icons.faTrash;
  edit=Icons.faEdit;
  batchform!:FormGroup;
  data:any={};
  public batchlist:any=[];
  public carlist:any=[];
  p:number=1;
  pages:any[]=[];
  itemPerPage:number=3;
  totalbatchs:any;
  editbatch:boolean=false;
  batchid:number=0;
  constructor(private bachService:BachService,private carService:CarService,private fb:FormBuilder,private toastr:ToastrService,private statics:CommonVariables) { }

  ngOnInit(): void {
    this.batchform=this.fb.group({
      Name:['',Validators.required],
      status:['',Validators.required],
      cars:['',Validators.required]
    });
    this.GetCars();
    this.GetBatches();
    
  }
  pageChanged(p:number){
    this.p=p;
   this.GetBatches();
 }
 GetCars(){
  var request=new RequestDto();
  request.SearchKey='';
  request.Page=this.p;
  request.PageSize=this.itemPerPage;
  this.carService.GetCars(request)
  .subscribe((res:any)=>{
    this.carlist=res;
  });
}
  GetBatches(){
    var request=new RequestDto();
    request.SearchKey='';
    request.Page=this.p;
    request.PageSize=this.itemPerPage;
    this.bachService.GetBatchs(request)
    .subscribe((res:any)=>{
      this.totalbatchs=res.rowCount;
      this.batchlist=res.batches;
    });
  }
  changeStatus(id:number){
   
    this.bachService.ChangeStatus(id)
        .subscribe({
          next:(res:any)=>{
            this.GetBatches(); 
            this.toastr.success(this.statics.CHANGE_STATUS_OK,'Success');
          },
          error:(res:any)=>{
            this.GetBatches();
            this.toastr.error(this.statics.CHANGE_STATUS_FAILD,'Error');
          }
        })
  }
  delete(id:number){
   
    this.bachService.Delete(id)
        .subscribe({
          next:(res:any)=>{
            this.GetBatches(); 
            this.toastr.success('Delete was Successfull','Success');
          },
          error:(res:any)=>{
            this.GetBatches();
            this.toastr.error('Delete was Faild','Error');
          }
        })
  }
  get(id:number){
   
    this.bachService.Get(id)
        .subscribe({
          next:(res:any)=>{
            this.editbatch=true;
            this.batchid=id;
            this.batchform.setValue({
                  Name:res.name,
                  status:res.status

            });
            
           
          },
          error:(res:any)=>{
          }
        })
  }
  onSubmit(){
  if(this.editbatch==false){
    if(this.batchform.valid){
      debugger;
      let car=this.batchform.value.cars;
      let r:any=[];
      r.push({id:car});
      this.data={
        Name:this.batchform.value.Name,
        CarInBatchs:r,
        Status:this.batchform.value.status
      }
       this.bachService.RegisterBatch(this.data)
       .subscribe({
            next:(res)=>{
              this.batchform.reset();
              this.GetBatches();
              this.toastr.success(this.statics.REGISTER,'Alert');
            },
            error:(res)=>{
              
              this.toastr.error('Register was Faild','Alert');
            }
       });
    }else{
      ValidateForm.validateAllFormFiles(this.batchform);
      this.toastr.warning('Please Fill All Fields','Alert');
    }
  }else{
    if(this.batchform.valid){
      this.data={
        Name:this.batchform.value.Name,
        Status:this.batchform.value.status,
        id:this.batchid
      }
       this.bachService.Edit(this.data)
       .subscribe({
            next:(res)=>{
              this.batchform.reset();
              this.GetBatches();
              this.toastr.success('Edit was Successfull','Alert');
            },
            error:(res)=>{
              
              this.toastr.error('Edit was Faild','Alert');
            }
       });
    }else{
      ValidateForm.validateAllFormFiles(this.batchform);
      this.toastr.warning('Please Fill All Fields','Alert');
    }
  }
  }



}
