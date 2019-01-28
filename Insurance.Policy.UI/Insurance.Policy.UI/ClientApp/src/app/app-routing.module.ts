import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from "./components/login/login.component";
import { InsuranceComponent } from "./components/insurance/insurance.component";
import { AssignInsuranceComponent } from "./components/assign-insurance/assign-insurance.component";
import { HomeComponent } from "./components/home/home.component";
import { AuthGuard } from "./components/login/auth.guard.service";

const routes: Routes = [
  { path: "", component: HomeComponent, canActivate: [AuthGuard], data: { title: "Home" } },
  { path: "insurance", component: InsuranceComponent, canActivate: [AuthGuard], data: { title: "Insurance Policy" } },
  { path: "home", component: HomeComponent, canActivate: [AuthGuard], data: { title: "Home" } },
  { path: "login", component: LoginComponent, data: { title: "Login" } },
  { path: "insurance", component: InsuranceComponent, canActivate: [AuthGuard], data: { title: "Insurance Policy" } },
  { path: "assign", component: AssignInsuranceComponent, canActivate: [AuthGuard], data: { title: "Assign Insurance" } }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
