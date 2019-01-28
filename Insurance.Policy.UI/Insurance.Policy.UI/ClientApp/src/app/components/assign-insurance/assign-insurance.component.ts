import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomerService } from  '../customer/customer.service';
import { Customer } from '../../models/customer.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Insurance } from 'src/app/models/insurance.model';
import { InsuranceService } from '../insurance/insurance.service';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';
import { InsuranceByCustomerService } from '../assign-insurance/insurancesByCustomer.service';
import { InsurancesByCustomer } from '../../models/insurancesByCustomer.model';
import { forEach } from '@angular/router/src/utils/collection';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'assign-insurance',
  templateUrl: './assign-insurance.component.html',
  styleUrls: ['./assign-insurance.component.css'],
  providers : [CustomerService, InsuranceService, InsuranceByCustomerService]
})
export class AssignInsuranceComponent implements OnInit {

  form: FormGroup;
  customers : Customer[] = [];
  currentAssignations : InsurancesByCustomer[] = [];
  newAssignations : InsurancesByCustomer[] = [];
  insurances : MatTableDataSource<Insurance>;
  isBusy : boolean = false;
  paginatorLength : number = 0;
  selection = new SelectionModel<Insurance>(true, []);

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  displayedColumns: string[] = [
    'Select',
    'Name', 
    'StartDate', 
    'CoverageType', 
    'CoveragePeriod',
    'CoveragePercentage', 
    'Pricing',
    'RiskType',
  ];

  constructor(private customerService : CustomerService,
    private insuranceService : InsuranceService,
    private assignationService : InsuranceByCustomerService,
    private formBuilder : FormBuilder,
    private snackBar : MatSnackBar) {

    this.getCustomers();
    this.getInsurances();
    this.getAssignations();
  }

  ngOnInit() {
    this.form = this.formBuilder.group({ 
      SelectCustomer : ['', Validators.required]
    });
  }

  getCustomers() {
    this.customerService.getAll().subscribe(data => {
      this.customers = data;
    });
  }

  private getInsurances() {
    this.isBusy = true;
    this.insuranceService.getAll().subscribe(data => {
        this.isBusy = false;
        this.insurances = new MatTableDataSource(data);
        this.insurances.sort = this.sort;
        this.insurances.paginator = this.paginator;
        this.paginatorLength = data.length;
    });
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.insurances.data.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.insurances.data.forEach(
          row => this.selection.select(row)
        );
  }

  saveAssignation() {
    this.isBusy = true;

    if(this.form && this.form.controls.SelectCustomer.value) {
      let customerId = this.form.controls.SelectCustomer.value;
      this.newAssignations = [];
      
      if(!this.selection.selected) {
        this.newAssignations.push({Id : 0, CustomerId : customerId, InsuranceId : 0});
      }

      for(let item of this.selection.selected) {
        this.newAssignations.push({Id : 0, CustomerId : customerId, InsuranceId : item.Id});
      }

      this.assignationService.save(this.newAssignations).subscribe(data => {
        this.currentAssignations = this.newAssignations;
        this.isBusy = false;
        this.snackBar.open('Se ha guardado la asignación correctamente.', "Ok", { duration : 5000 });
      });
    }
  }

  checkInsurances() {
    let customerId = this.form.controls.SelectCustomer.value;
    for(let item of this.currentAssignations) {
      let rowToCheck = this.insurances.data.find(x => x.Id === item.InsuranceId && customerId === item.CustomerId);
      this.selection.select(rowToCheck);
    }
  }

  getAssignations() {
    this.isBusy = true;

    if(this.form) {
      this.selection = new SelectionModel<Insurance>(true, []);
      let customerId = this.form.controls.SelectCustomer.value;

      if(customerId > 0) {
        this.assignationService.getAssignations(customerId).subscribe(data => {
          this.currentAssignations = data;
          this.checkInsurances();
          this.isBusy = false;
        });
      }
    }
  }

}
