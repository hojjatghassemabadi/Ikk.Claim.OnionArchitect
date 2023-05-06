import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import * as Icons from '@fortawesome/free-solid-svg-icons';
import { RequestDto } from 'src/app/models/RequestDto';
import { RegisterclaimService } from 'src/app/services/registerclaim.service';
import { ToastrService } from 'ngx-toastr';
import { CommonVariables } from 'src/app/components/common/Statics';
import ValidateForm from 'src/app/helper/validateform';
import { NgbAlertModule, NgbDatepickerModule, NgbDateStruct, NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { PartsService } from 'src/app/services/parts.service';
import { BachService } from 'src/app/services/bach.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-register-claim',
  templateUrl: './register-claim.component.html',
  styleUrls: ['./register-claim.component.css']
})
export class RegisterClaimComponent implements OnInit {
  
  claimform!:FormGroup;
  checked = Icons.faCheck;
  notchecked=Icons.faClose;
  crash=Icons.faTrash;
  edit=Icons.faEdit;
  download=Icons.faDownload;

  data:any={};
  public claimlist:any=[];
  public carlist:any=[];
  p:number=1;
  pages:any[]=[];
  itemPerPage:number=3;
  totalclaims:any;
  editclaim:boolean=false;
  claimid:number=0;
  partList:any=[];
  batchSelectedId:any;
  batchList:any=[];
  files:any[]=[];
  uploading:boolean=false;
  tdate:any=new Date();
  today:any=new NgbDate(this.tdate.getFullYear(),this.tdate.getMonth()+1,this.tdate.getDate());
  seletedpartid:any;
  CId:any=0;
  urls:any[]=[];
  imageId:number=0;
  constructor(private registerclaimService:RegisterclaimService,private batchservice:BachService,private partservice:PartsService,private fb:FormBuilder,private toastr:ToastrService,private statics:CommonVariables) {
     
   }

  ngOnInit(): void {
    this.claimform=this.fb.group({
      ClaemNumber:['',Validators.required],
      PartId:['',Validators.required],
      CountPart:['',Validators.required],
      BatchId:['',Validators.required],
      DateRegister:['',Validators.required],
      Desc:[''],
      Company:[''],
      CarModel:[''],
      Country:[''],
      PartName:['']
    });
    
    this.urls=[];
   
    this.GetCountClaims();
    
    this.claimform.controls['Country'].setValue("IRAN");
    this.claimform.controls['Company'].setValue("IKKCO");
  
    this.claimform.controls['DateRegister'].setValue(this.today);
    
  }
  
  pageChanged(p:number){
    this.p=p;
   this.GetClaims();
 }
 searchpart(event:any){
  let partcode = (<HTMLInputElement>document.getElementById('partcode')).value;
  this.GetParts(partcode);
 
 }
 setPartName(event:any){
  let partid=event;
  let item=this.partList.find((a:any)=>a.partNumber==partid);
  (<HTMLInputElement>document.getElementById('partname')).value=item.partName;
  this.seletedpartid=item.id;
 }
 setCartName(event:any){
  let batchid=event;
  let item=this.batchservice.Get(batchid)
  .subscribe((res:any)=>{
    (<HTMLInputElement>document.getElementById('carmodel')).value=res.carModelName;
  });
 }
 searchBatch(item:any){
  let batchid = (<HTMLInputElement>document.getElementById('batchnumber')).value;
  this.GetBatches(batchid);
 }

 GetParts(searchword:string){
  var request=new RequestDto();
  request.SearchKey=searchword;
  request.Page=this.p;
  request.PageSize=this.itemPerPage;
  this.partservice.GetParts(request)
  .subscribe((res:any)=>{
    //this.totalclaims=res.rowCount;
    this.partList=res;
    this.setPartName(searchword);
  }); 
 }
 GetBatches(batchid:any){
  var request=new RequestDto();
  request.SearchKey=batchid;
  request.Page=this.p;
  request.PageSize=this.itemPerPage;
  this.batchservice.GetBatchs(request)
  .subscribe((res:any)=>{
    
    this.batchList=res.batches;
    this.batchSelectedId=res.batches[0].id;
    this.setCartName(res.batches[0].id);
  });
}
GetCountClaims(){
  this.registerclaimService.GetCountClaims()
  .subscribe((res:any)=>{
    
    this.claimform.controls['ClaemNumber'].setValue(res+1);
   return res;
  });
}
 GetClaims(){
  var request=new RequestDto();
  request.SearchKey='';
  request.Page=this.p;
  request.PageSize=this.itemPerPage;
  this.registerclaimService.GetClaims(request)
  .subscribe((res:any)=>{
    this.totalclaims=res.rowCount;
    this.claimform.controls['ClaemNumber'].setValue(res.rowCount+1);
    this.claimlist=res.batches;
  });
}
delete(id:number){
   
  this.registerclaimService.Delete(id)
      .subscribe({
        next:(res:any)=>{
          this.GetClaims(); 
          this.toastr.success('Delete was Successfull','Success');
        },
        error:(res:any)=>{
          this.GetClaims();
          this.toastr.error('Delete was Faild','Error');
        }
      })
}
deleteImage(url:any){
  
  if(url.address.length<1000){
  this.registerclaimService.DeleteImage(url.picName)
       .subscribe({
            next:(res:any)=>{
              this.toastr.success('Delete was Successfull','Success');
              
              this.urls.splice(url.id,1);
            },
            error:(res:any)=>{
              this.toastr.error('Delete was Faild','Error');
            }
       });
  }
  else{
    this.urls.splice(url.id,1);
  }
}
downloadImage(url:any){

}

onselectImage(e:any){
  
   if(e.target.files){
    
     for(let i=0;i<File.length;i++){
      this.uploading=true;
        var reader=new FileReader();
        reader.readAsDataURL(e.target.files[i]);
        this.files.push(e.target.files[i]);
        reader.onload=(events:any)=>{
          this.urls.push({
            address:events.target.result,
            id:i
            
          });
          this.uploading=false;

        }
        
      }
     
   }
}
get(id:number){
  this.files=[];
  this.urls=[];
  this.registerclaimService.Get(id)
      .subscribe({
        next:(res:any)=>{
          this.editclaim=true;
          this.claimid=id;
          let sdate=res.registerDate.split('T');
          let cdate=sdate[0].split('-');
          let y:number=Number(cdate[0]);
          let m:number=Number(cdate[1]);
          let d:number=Number(cdate[2]);
          let ccdate=new NgbDate(y,m,d);
          this.claimform.setValue({
            ClaemNumber:id,
                PartId:res.partId,
                CountPart:res.countPart,
                BatchId:res.batchName,
                Country:res.country,
                Desc:res.desc,
                Company:res.company,
                DateRegister:ccdate,
                CarModel:res.carModel,
                PartName:res.partName
          });
          this.seletedpartid=res.partId;
          this.batchSelectedId=res.batchId;
          this.CId=res.id;
          this.registerclaimService.GetClaimPics(res.id)
          .subscribe({
            next:(res:any)=>{
              let i=0;
              for(let obj of res){
                //this.urls.push(".\\Files\\Claems\\"+obj.picName);
                
                this.urls.push({
                  address:"/assets/Claims/"+obj.picName,
                  id:i++,
                  picName:obj.picName
                });
              }
             
              
            }
            
          });

        },
        error:(res:any)=>{
          this.toastr.error('Not Exist','Error');
        }
      })
}
CancelEdit(){
  this.claimform.reset();
              this.GetClaims();
              this.uploading=false;
              this.GetCountClaims();
              this.urls=[];
              this.claimform.controls['DateRegister'].setValue(this.today);
              this.editclaim=false;
}
onEditclaim(e:any){
   this.get(e.target.value);
}
onSubmit(){
  if(this.editclaim==false){
    if(this.claimform.valid){
      debugger;
      let car=this.claimform.value.cars;
      let r:any=[];
      r.push({id:car});
      this.uploading=true;
      const formdata=new FormData();
      formdata.append("ClaimNumber",this.claimform.value.ClaemNumber);
      formdata.append("CountPart",this.claimform.value.CountPart);
      formdata.append("BatchId",this.batchSelectedId);
      formdata.append("Country","IRAN");
      formdata.append("Company","IKKCo");
      formdata.append("Desc",this.claimform.value.Desc);
      formdata.append("PartId",this.seletedpartid);
      let currentdate=this.claimform.value.DateRegister;
      let sdate=currentdate.year+"-"+currentdate.month+"-"+currentdate.day;
      formdata.append("RegisterDate",sdate);
      if(this.files.length>0)
      this.files.forEach((file)=>formdata.append("files",file));
       this.registerclaimService.RegisterClaim(formdata)
       .subscribe({
            next:(res)=>{
              this.claimform.reset();
              this.GetClaims();
              this.uploading=false;
              this.toastr.success(this.statics.REGISTER,'Alert');
              this.GetCountClaims();
              this.urls=[];

            },
            error:(res)=>{
              this.uploading=false;
              this.toastr.error('Register was Faild','Alert');
            }
       });
    }else{
      ValidateForm.validateAllFormFiles(this.claimform);
      this.toastr.warning('Please Fill All Fields','Alert');
    }
  }else{
    if(this.claimform.valid){
      const formdata=new FormData();
      formdata.append("Id",this.CId);
      formdata.append("ClaimNumber",this.claimform.value.ClaemNumber);
      formdata.append("CountPart",this.claimform.value.CountPart);
      formdata.append("BatchId",this.batchSelectedId);
      formdata.append("Country","IRAN");
      formdata.append("Company","IKKCo");
      formdata.append("Desc",this.claimform.value.Desc);
      formdata.append("PartId",this.seletedpartid);
      let currentdate=this.claimform.value.DateRegister;
      let sdate=currentdate.year+"-"+currentdate.month+"-"+currentdate.day;
      formdata.append("RegisterDate",sdate);
      if(this.files.length>0)
      this.files.forEach((file)=>formdata.append("files",file));
       this.registerclaimService.Edit(formdata)
       .subscribe({
            next:(res)=>{
              this.claimform.reset();
              this.GetClaims();
              this.toastr.success('Edit was Successfull','Alert');
              this.urls=[];
              this.GetCountClaims();
            },
            error:(res)=>{
              
              this.toastr.error('Edit was Faild','Alert');
            }
       });
    }else{
      ValidateForm.validateAllFormFiles(this.claimform);
      this.toastr.warning('Please Fill All Fields','Alert');
    }
  }
  }
}
