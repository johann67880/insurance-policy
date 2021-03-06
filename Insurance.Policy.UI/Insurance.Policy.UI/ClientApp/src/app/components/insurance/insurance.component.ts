import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog } from '@angular/material';
import { InsuranceService } from './insurance.service';
import { Insurance } from 'src/app/models/insurance.model';
import { InsuranceDetailComponent } from './insurance-detail/insurance-detail.component';

@Component({
    selector: 'insurance',
    templateUrl: './insurance.component.html',
    styleUrls: ['./insurance.component.css'],
    providers : [InsuranceService]
})
export class InsuranceComponent implements OnInit, AfterViewInit {
    displayedColumns: string[] = [
        'Name', 
        'Description', 
        'StartDate', 
        'CoverageType', 
        'CoveragePeriod',
        'CoveragePercentage', 
        'Pricing',
        'RiskType',
        'ActionColumn'
    ];

    insurances : MatTableDataSource<Insurance>;
    isBusy : boolean = false;
    paginatorLength : number = 0;
    selectedInsurance : Insurance;

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(public dialog: MatDialog, private service : InsuranceService) {

    }

    ngOnInit() {
        this.getInsurances();
    }

    ngAfterViewInit() {
        // If the user changes the sort order, reset back to the first page.
        this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    }

    private getInsurances() {
        this.isBusy = true;
        this.service.getAll().subscribe(data => {
            this.isBusy = false;
            this.insurances = new MatTableDataSource(data);
            this.insurances.sort = this.sort;
            this.insurances.paginator = this.paginator;
            this.paginatorLength = data.length;
        });
    }

    openDialog(insurance : Insurance) : void {
        const dialogRef = this.dialog.open(InsuranceDetailComponent, {
            width: '450px',
            data: insurance
        });

        dialogRef.afterClosed().subscribe(result => {
            setTimeout(() => {
                this.getInsurances();
            }, 500);
        });
    }

    createInsurance() {
        let insurance = new Insurance();
        insurance.Id = 0;

        this.selectedInsurance = insurance;
        this.openDialog(this.selectedInsurance);
    }

    updateInsurance(insurance : Insurance) {
        this.selectedInsurance = insurance;
        this.openDialog(this.selectedInsurance);
    }

    deleteInsurance(insurance : Insurance) {
        if(confirm("¿Está seguro de eliminar la poliza de seguro? " + insurance.Name)) {
            this.service.delete(insurance).subscribe(response => {
                this.getInsurances();
            });
        }
    }
}
