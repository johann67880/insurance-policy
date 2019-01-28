import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from "./components/login/login.component";
import { InsuranceComponent } from "./components/insurance/insurance.component";
import { AssignInsuranceComponent } from "./components/assign-insurance/assign-insurance.component";

const routes: Routes = [
  { path: "", component: InsuranceComponent, data: { title: "Login" } },
  //{ path: "login", component: LoginComponent, data: { title: "Login" } },
  { path: "insurance", component: InsuranceComponent, data: { title: "Insurance Policy" } },
  { path: "assign", component: AssignInsuranceComponent, data: { title: "Assign Insurance" } }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
