import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationComponent } from './registration/registration.component';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { DefaultComponent } from './default/default.component';
import { ConfigurationComponent } from './configuration/configuration.component';
import { InteriorComponent } from './interior/interior.component';
import { ExteriorComponent } from './exterior/exterior.component';
import { IndComponent } from './ind/ind.component';
import { InvoiceComponent } from './invoice/invoice.component';
//import { OperxjComponent } from './operxj/operxj.component';


@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    LoginComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    DefaultComponent,
    ConfigurationComponent,
    InteriorComponent,
    ExteriorComponent,
    IndComponent,
    InvoiceComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
