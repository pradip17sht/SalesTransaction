import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UtilityService } from 'src/core/services/utility.service';
import { InvoiceService } from '../invoice/invoice.service';
import { SalesTransactionFormComponent } from './sales-transaction-form/sales-transaction-form.component';
import { MvSalesTransaction } from './sales-transaction.model';
import { SalesTransactionService } from './sales-transaction.service';

@Component({
  selector: 'app-sales-transaction',
  templateUrl: './sales-transaction.component.html',
  styleUrls: ['./sales-transaction.component.scss']
})
export class SalesTransactionComponent implements OnInit {

  userMsg: string = null;
  displayedColumns: string[];
  dataSource: MvSalesTransaction[] = [];
  selectedSalesTransaction: MvSalesTransaction = {} as MvSalesTransaction;
  selection = new SelectionModel<MvSalesTransaction>(false, []);
  selectionCheckBox = new SelectionModel<MvSalesTransaction>(true, []);


  constructor(
    private ss: SalesTransactionService,
    private dialog: MatDialog,
    private us: UtilityService,
    private is: InvoiceService
  ) { }

  ngOnInit(): void {
    this.displayedColumns = ['select', 'salesTransactionId', 'productName', 'customerName', 'quantity', 'rate', 'invoiceId', 'amount'];
    this.getAllSalesTransactionDetail();
  }

  getAllSalesTransactionDetail(): void {
    this.ss.getAllSalesTransactionDetail().subscribe(res => {
      if (res && res.data) {
        this.dataSource = res.data;
      } else {
        this.dataSource = [];
        this.userMsg = 'No data';
      }
    }, err => console.log(err));
  }

  addSalesTransaction(): void {
    this.selection.clear();
    this.selectedSalesTransaction = {} as MvSalesTransaction;
    this.openDialog('Add');
  }
  editSalesTransaction(): void {
    this.openDialog('Edit');
  }

  openDialog(action: string): void {
    if (action === 'Edit' && !this.selection.hasValue()) {
      this.us.openSnackBar('Select a saletransaction before editing', 'warning');
      return;
    }
    const dialogRef = this.dialog.open(SalesTransactionFormComponent, {
     data: {
       action,
       data: this.selectedSalesTransaction
     }

    });

    dialogRef.afterClosed().subscribe(saleTransaction => {
      if (saleTransaction) {
        if (action === 'Edit') {
          this.ss.editSalesTransaction(saleTransaction).subscribe(res => {
            this.getAllSalesTransactionDetail();
            this.us.openSnackBar('SaleTransaction Updated', 'success');
          });
        } else {
          this.ss.addSalesTransaction(saleTransaction).subscribe(res => {
            this.getAllSalesTransactionDetail();
            this.us.openSnackBar('SaleTransaction Added', 'success');
          }, err => console.log(err));
        }
      }
    });
  }

  onRowClicked(row: any): void {
    this.selectedSalesTransaction = { ...row };
    this.selection.toggle(row);
    this.selectionCheckBox.toggle(row);
  }

  isAllSelected(): boolean {
    const numSelected = this.selectionCheckBox.selected.length;
    const numRows = this.dataSource.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle(): void {
    this.isAllSelected() ?
        this.selectionCheckBox.clear() :
        this.dataSource.forEach(row => this.selectionCheckBox.select(row));
  }

  generateInvoice(): void {
    if (!this.selectionCheckBox.hasValue()) {
      this.us.openSnackBar('Select salestransaction to generate invoice', 'warning');
    } else {
      if (this.isInvoiced(this.selectionCheckBox.selected)) {
        this.us.openSnackBar('Cannot generate invoice for an invoiced sale', 'warning');
      } else if (!this.hasSameCustomer(this.selectionCheckBox.selected)) {
        this.us.openSnackBar('Please select salestransaction with same customer', 'warning');
      } else {
        this.is.generateInvoice(this.selectionCheckBox.selected).subscribe(res => {
          this.us.openSnackBar('Invoice Generated', 'success');
          this.getAllSalesTransactionDetail();
        }, err => console.log(err));
      }
    }
  }

  hasSameCustomer(array): boolean {
    const first = array[0];
    return array.every((element) => {
        return element.customerId === first.customerId;
    });
  }

  isInvoiced(array): boolean {
    let res = false;
    array.forEach(item => {
      if (item.invoiceId) {
        res = true;
        return;
      }
    });
    return res;
  }
}
