import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Insurance } from '../../../models/insurance.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CoverageTypeService } from '../../coverageType/coverage.service';
import { CoverageType } from '../../../models/coverageType.model';
import { RiskTypeService } from '../../riskType/riskType.service';
import { RiskType } from '../../../models/riskType.model';

@Component({
  selector: 'insurance-detail',
  templateUrl: './insurance-detail.component.html',
  styleUrls: ['./insurance-detail.component.css'],
  providers : [CoverageTypeService, RiskTypeService]
})
export class InsuranceDetailComponent implements OnInit {
  form: FormGroup;
  tempInsurance : Insurance;
  coverages : CoverageType[] = [];
  risks : RiskType[] = [];
  modifiedInsurance : Insurance;

  constructor(private formBuilder : FormBuilder,
    private service : CoverageTypeService,
    private riskService : RiskTypeService,
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

}
