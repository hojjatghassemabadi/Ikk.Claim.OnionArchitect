import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule} from 'ngx-pagination';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations'
import { ToastrModule} from 'ngx-toastr';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BachNumbersComponent } from './bach-numbers/bach-numbers.component';
import { UsersComponent } from '../UserManagement/users/users.component';
import { RolesComponent } from '../UserManagement/roles/roles.component';
import { PartDeclarationComponent } from '../part-declaration/part-declaration.component';
import { CarDeclarationComponent } from '../car-declaration/car-declaration.component';


@NgModule({
  declarations: [
    UsersComponent,
    RolesComponent,
    PartDeclarationComponent,
    CarDeclarationComponent,
    BachNumbersComponent,

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
export class BaseInfoModule { }
