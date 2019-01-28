import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { Insurance } from '../../../models/insurance.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CoverageTypeService } from '../../coverageType/coverage.service';
import { CoverageType } from '../../../models/coverageType.model';
import { RiskTypeService } from '../../riskType/riskType.service';
import { RiskType } from '../../../models/riskType.model';
import { InsuranceService } from '../insurance.service';
import { config } from 'rxjs';

@Component({
  selector: 'insurance-detail',
  templateUrl: './insurance-detail.component.html',
  styleUrls: ['./insurance-detail.component.css'],
  providers : [CoverageTypeService, RiskTypeService, InsuranceService]
})
export class InsuranceDetailComponent implements OnInit {
  form: FormGroup;
  tempInsurance : Insurance;
  coverages : CoverageType[] = [];
  risks : RiskType[] = [];
  modifiedInsurance : Insurance;
  invalidForm : boolean = false;

  constructor(private formBuilder : FormBuilder,
    private service : CoverageTypeService,
    private riskService : RiskTypeService,
    private insuranceService : InsuranceService,
    private snackBar : MatSnackBar,
    public dialogRef: MatDialogRef<InsuranceDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Insurance) {
      this.tempInsurance = data;
      this.modifiedInsurance = data;
      this.getCoverages();
      this.getRisks();
    }

  ngOnInit() {
    this.form = this.formBuilder.group({
      Name: ['', Validators.required],
      Description: ['', Validators.required],
      CoveragePeriod: ['', Validators.required],
      Pricing: ['', Validators.required],
      StartDate: ['', Validators.required],
      SelectCoverage : ['', Validators.required],
      CoveragePercentage : ['', Validators.required],
      SelectRisk : ['', Validators.required]
    });

    this.form.controls.Name.setValue(this.tempInsurance.Name);
    this.form.controls.Description.setValue(this.tempInsurance.Description);
    this.form.controls.CoveragePeriod.setValue(this.tempInsurance.CoveragePeriod);
    this.form.controls.Pricing.setValue(this.tempInsurance.Pricing);
    this.form.controls.StartDate.setValue(this.tempInsurance.StartDate);
    this.form.controls.SelectCoverage.setValue(this.tempInsurance.CoverageId);
    this.form.controls.CoveragePercentage.setValue(this.tempInsurance.CoveragePercentage);
    this.form.controls.SelectRisk.setValue(this.tempInsurance.RiskId);
    this.invalidForm = this.form.invalid;

    this.form.valueChanges.subscribe(result => {
      this.invalidForm = this.form.invalid;
    });
  }

  getCoverages() {
    this.service.getAll().subscribe(data => {
      this.coverages = data;
    });
  }

  getRisks() {
    this.riskService.getAll().subscribe(data => {
      this.risks = data;
    });
  }

  closeDialog() : void {
    this.dialogRef.close();
  }

  addInsurance() {
    this.invalidForm = this.form.invalid;

    if(!this.invalidForm) {

      let insurance = new Insurance();
      insurance.Id = this.tempInsurance.Id;
      insurance.Name = this.form.controls.Name.value;
      insurance.Description = this.form.controls.Description.value;
      insurance.CoveragePeriod = this.form.controls.CoveragePeriod.value;
      insurance.Pricing = this.form.controls.Pricing.value;
      insurance.StartDate = this.form.controls.StartDate.value;
      insurance.CoverageId = this.form.controls.SelectCoverage.value;
      insurance.CoveragePercentage = this.form.controls.CoveragePercentage.value;
      insurance.RiskId = this.form.controls.SelectRisk.value;

      //Is updating
      if(insurance.Id > 0) {
        this.insuranceService.update(insurance).subscribe(data => {
            if(data) {
              this.snackBar.open('El registro se ha almacenado exitosamente.', "Ok", { duration : 5000 });
            } else {
              this.snackBar.open('El porcentaje de cobertura para riesgo alto no debe ser mayor a 50%.', 
                "Ok", { duration : 5000 });
            }
        });
      } else {
          //is new one
          this.insuranceService.save(insurance).subscribe(data => {
            if(data) {
              this.snackBar.open('El registro se ha almacenado exitosamente.', "Ok", { duration : 5000 });
            } else {
              this.snackBar.open('El porcentaje de cobertura para riesgo alto no debe ser mayor a 50%.', 
                "Ok", { duration : 5000 });
            }
          });
      }
    }
  }

}
