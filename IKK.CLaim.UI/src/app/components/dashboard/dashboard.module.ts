import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './UserManagement/users/users.component';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule} from 'ngx-pagination';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations'
import { ToastrModule} from 'ngx-toastr';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RegisterClaimComponent } from './register-claim/register-claim.component';
import { RegisterCKDQRComponent } from './register-ckdqr/register-ckdqr.component';
import { RegisterCCLRCLComponent } from './register-cclrcl/register-cclrcl.component';
import { RegisterPackingListComponent } from './register-packing-list/register-packing-list.component';
import { AnalyzCKDQRComponent } from './analyz-ckdqr/analyz-ckdqr.component';
import { BaseInfoComponent } from './base-info/base-info.component';
import { BaseInfoModule } from './base-info/baseInfo.module';
import { NgbAlertModule, NgbDatepickerModule, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    RegisterClaimComponent,
    RegisterCKDQRComponent,
    RegisterCCLRCLComponent,
    RegisterPackingListComponent,
    AnalyzCKDQRComponent,
    BaseInfoComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    BrowserModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    BrowserAnimationsModule,
    BaseInfoModule,
    NgbDatepickerModule,
    ToastrModule.forRoot({
      timeOut:2000,
      progressBar:true,
      progressAnimation:'increasing'
    }),
    FontAwesomeModule
  ]
})
export class DashboardModule { }
