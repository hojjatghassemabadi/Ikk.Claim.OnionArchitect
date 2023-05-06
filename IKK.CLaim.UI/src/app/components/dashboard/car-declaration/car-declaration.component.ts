import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validator,Validators } from '@angular/forms';
import * as Icons from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { RequestDto } from 'src/app/models/RequestDto';
import ValidateForm from 'src/app/helper/validateform';
import { CommonVariables } from 'src/app/components/common/Statics';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-declaration',
  templateUrl: './car-declaration.component.html',
  styleUrls: ['./car-declaration.component.css']
})
export class CarDeclarationComponent implements OnInit {

  checked = Icons.faCheck;
  notchecked=Icons.faClose;
  crash=Icons.faTrash;
  edit=Icons.faEdit;
  Carform!:FormGroup;
  data:any={};
  public carlist:any=[];
  p:number=1;
  pages:any[]=[];
  itemPerPage:number=3;
  totalcars:any;
  editcar:boolean=false;
  carid:number=0;
  constructor(private carsService:CarService,private fb:FormBuilder,private toastr:ToastrService,private statics:CommonVariables) { }

  ngOnInit(): void {
    this.Carform=this.fb.group({
      Name:['',Validators.required],
      status:['',Validators.required]
    });
    this.GetCars();
    
  }
  pageChanged(p:number){
    this.p=p;
   this.GetCars();
 }

  GetCars(){
    var request=new RequestDto();
    request.SearchKey='';
    request.Page=this.p;
    request.PageSize=this.itemPerPage;
    this.carsService.GetCars(request)
    .subscribe((res:any)=>{
      this.totalcars=res.rowCount;
      this.carlist=res;
    });
  }
  changeStatus(id:number){
   
    this.carsService.ChangeStatus(id)
        .subscribe({
          next:(res:any)=>{
            this.GetCars(); 
            this.toastr.success(this.statics.CHANGE_STATUS_OK,'Success');
          },
          error:(res:any)=>{
            this.GetCars();
            this.toastr.error(this.statics.CHANGE_STATUS_FAILD,'Error');
          }
        })
  }
  delete(id:number){
   
    this.carsService.Delete(id)
        .subscribe({
          next:(res:any)=>{
            this.GetCars(); 
            this.toastr.success('Delete was Successfull','Success');
          },
          error:(res:any)=>{
            this.GetCars();
            this.toastr.error('Delete was Faild','Error');
          }
        })
  }
  get(id:number){
   
    this.carsService.Get(id)
        .subscribe({
          next:(res:any)=>{
            this.editcar=true;
            this.carid=id;
            this.Carform.setValue({
                  Name:res.name,
                  status:res.status

            });
            
           
          },
          error:(res:any)=>{
          }
        })
  }
  onSubmit(){
  if(this.editcar==false){
    if(this.Carform.valid){
      this.data={
        Name:this.Carform.value.Name,
        Status:this.Carform.value.status
      }
       this.carsService.RegisterCar(this.data)
       .subscribe({
            next:(res)=>{
              this.Carform.reset();
              this.GetCars();
              this.toastr.success(this.statics.REGISTER,'Alert');
            },
            error:(res)=>{
              
              this.toastr.error('Register was Faild','Alert');
            }
       });
    }else{
      ValidateForm.validateAllFormFiles(this.Carform);
      this.toastr.warning('Please Fill All Fields','Alert');
    }
  }else{
    if(this.Carform.valid){
      this.data={
        Name:this.Carform.value.Name,
        Status:this.Carform.value.status,
        id:this.carid
      }
       this.carsService.Edit(this.data)
       .subscribe({
            next:(res)=>{
              this.Carform.reset();
              this.GetCars();
              this.toastr.success('Edit was Successfull','Alert');
            },
            error:(res)=>{
              
              this.toastr.error('Edit was Faild','Alert');
            }
       });
    }else{
      ValidateForm.validateAllFormFiles(this.Carform);
      this.toastr.warning('Please Fill All Fields','Alert');
    }
  }
  }

}
