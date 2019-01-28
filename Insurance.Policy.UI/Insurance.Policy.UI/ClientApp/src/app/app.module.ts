import { NgModule, ErrorHandler } from "@angular/core";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from "@ngx-translate/core";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from "./components/app.component";
import { LoginComponent } from "./components/login/login.component";
import { InsuranceComponent } from "./components/insurance/insurance.component";
import { InsuranceDetailComponent } from "./components/insurance/insurance-detail/insurance-detail.component";
import { AssignInsuranceComponent } from  './components/assign-insurance/assign-insurance.component';
import { HomeComponent } from './components/home/home.component';
import { MaterialModule } from "./common/material.module";

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    MaterialModule
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    InsuranceComponent,
    InsuranceDetailComponent,
    AssignInsuranceComponent,
    HomeComponent
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl }
  ],
  bootstrap: [AppComponent],
  entryComponents : [
    InsuranceDetailComponent
  ]
})
export class AppModule {
}

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
