import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { DefaultComponent } from './default/default.component';
import { ConfigurationComponent } from './configuration/configuration.component';
import { HomeGuard } from './home.guard';
import { InteriorComponent } from './interior/interior.component';
import { ExteriorComponent } from './exterior/exterior.component';
import { IndComponent } from './ind/ind.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { HeaderComponent } from './header/header.component';



const routes: Routes = [
  { path: '', component:IndComponent},
  { path:'registration', component:RegistrationComponent},
  { path: 'login', component:LoginComponent},
  { path: 'home', component:HomeComponent,canActivate:[HomeGuard]},
  { path: 'default', component:DefaultComponent},
  { path: 'configuration', component:ConfigurationComponent},
  { path: 'interior', component:InteriorComponent},
  { path: 'exterior', component:ExteriorComponent},
  { path: 'ind', component:IndComponent},
  { path: 'invoice', component:InvoiceComponent},
  { path: 'header', component:HeaderComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
