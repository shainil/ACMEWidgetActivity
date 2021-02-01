import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {SignupComponent} from './signup/signup.component';
import {ShowEmployeeComponent} from './show-employee/show-employee.component';
import {ThankyouComponent} from './thankyou/thankyou.component';
import {NotFoundComponent} from './error-pages/not-found/not-found.component';
import {InternalServerComponent} from './error-pages/internal-server/internal-server.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'signup' },
  { path: '404', component : NotFoundComponent},
  { path: '500', component: InternalServerComponent },
  {path:'signup',component:SignupComponent},
  {path:'show-employee',component:ShowEmployeeComponent},
  {path:'thankyou',component:ThankyouComponent},
  { path: '404', component : NotFoundComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
