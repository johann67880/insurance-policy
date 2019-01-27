import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from "./components/login/login.component";
import { InsuranceComponent } from "./components/insurance/insurance.component";

const routes: Routes = [
  { path: "", component: LoginComponent, data: { title: "Login" } },
  { path: "login", component: LoginComponent, data: { title: "Login" } },
  { path: "insurance", component: InsuranceComponent, data: { title: "Insurance Policy" } }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
