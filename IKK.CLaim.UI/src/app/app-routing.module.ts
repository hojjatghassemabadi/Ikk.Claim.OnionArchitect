import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guards/auth.guard';
import { UsersComponent } from 'src/app/components/dashboard/UserManagement/users/users.component';
import { RolesComponent } from './components/dashboard/UserManagement/roles/roles.component';
import { AccessComponent } from './components/dashboard/UserManagement/access/access.component';
import { PartDeclarationComponent } from './components/dashboard/part-declaration/part-declaration.component';
import { BachNumbersComponent } from './components/dashboard/bach-numbers/bach-numbers.component';
import { RegisterClaimComponent } from './components/dashboard/register-claim/register-claim.component';
import { RegisterCKDQRComponent } from './components/dashboard/register-ckdqr/register-ckdqr.component';
import { RegisterCCLRCLComponent } from './components/dashboard/register-cclrcl/register-cclrcl.component';
import { RegisterPackingListComponent } from './components/dashboard/register-packing-list/register-packing-list.component';

const routes: Routes = [ 
{path:"dashboard",component:DashboardComponent,canActivate:[AuthGuard],
 children:[{
  path:'users',
  component:UsersComponent
  
 },{
  path:'roles',
  component:RolesComponent
 }
 ,{
  path:'Access',
  component:AccessComponent
 }
 ,{
  path:'PartDeclaration',
  component:PartDeclarationComponent
 }
 ,{
  path:'BatchNumber',
  component:BachNumbersComponent
 }
 ,{
  path:'RegisterClaim',
  component:RegisterClaimComponent
 }
 ,{
  path:'RegisterCKDQR',
  component:RegisterCKDQRComponent
 }
 ,{
  path:'RegisterCCLRCL',
  component:RegisterCCLRCLComponent
 }
 ,{
  path:'RegisterPackingList',
  component:RegisterPackingListComponent
 }
]
},
{path:"login",component:LoginComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
