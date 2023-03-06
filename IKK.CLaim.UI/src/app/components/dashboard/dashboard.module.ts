import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './UserManagement/users/users.component';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import {NgxPaginationModule} from 'ngx-pagination';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import {ToastrModule} from 'ngx-toastr';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RolesComponent } from './UserManagement/roles/roles.component';
import { AccessComponent } from './UserManagement/access/access.component';
import { PartDeclarationComponent } from './part-declaration/part-declaration.component';
import { BachNumbersComponent } from './bach-numbers/bach-numbers.component';
import { RegisterClaimComponent } from './register-claim/register-claim.component';
import { RegisterCKDQRComponent } from './register-ckdqr/register-ckdqr.component';
import { RegisterCCLRCLComponent } from './register-cclrcl/register-cclrcl.component';
import { RegisterPackingListComponent } from './register-packing-list/register-packing-list.component';

@NgModule({
  declarations: [
    UsersComponent,
    RolesComponent,
    AccessComponent,
    PartDeclarationComponent,
    BachNumbersComponent,
    RegisterClaimComponent,
    RegisterCKDQRComponent,
    RegisterCCLRCLComponent,
    RegisterPackingListComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    BrowserModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut:2000,
      
      progressBar:true,
      progressAnimation:'increasing'
    }),
    FontAwesomeModule
  ]
})
export class DashboardModule { }
