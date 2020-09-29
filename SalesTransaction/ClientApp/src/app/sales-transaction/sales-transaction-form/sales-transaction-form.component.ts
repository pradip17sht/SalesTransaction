import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { MvCustomer } from 'src/app/customer/customer.model';
import { CustomerService } from 'src/app/customer/customer.service';
import { MvProduct } from 'src/app/product/product.model';
import { ProductService } from 'src/app/product/product.service';
import { UtilityService } from 'src/core/services/utility.service';
import { MvSalesTransaction } from '../sales-transaction.model';

@Component({
  selector: 'app-sales-transaction-form',
  templateUrl: './sales-transaction-form.component.html',
  styleUrls: ['./sales-transaction-form.component.scss']
})
export class SalesTransactionFormComponent implements OnInit {
  salesTransactionForm: FormGroup;
  customers = [];
  products = [];
  action: string;
  salesTransaction: MvSalesTransaction = {} as MvSalesTransaction;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<SalesTransactionFormComponent>,
    private ps: ProductService,
    private cs: CustomerService,
  ) {
    this.action = data.action;
    this.salesTransaction = data.data || {};
    dialogRef.disableClose = true;
  }

  ngOnInit(): void {
    this.salesTransactionForm = this.fb.group({
      customerId: [this.salesTransaction.customerId, Validators.required],
      productId: [this.salesTransaction.productId, Validators.required],
      quantity: [this.salesTransaction.quantity, Validators.required],
    });
    this.fetchCustomers();
    this.fetchProducts();

  }

  fetchCustomers(): void {
    this.cs.getAllCustomerDetail().subscribe(res => {
      if (res && res.data) {
        res.data.forEach(item => {
          if (item.customerId) {
            this.customers.push({
              value: item.customerId,
              viewValue: `${item.firstName} ${item.middleName || ''} ${item.lastName}`
            });
          }
        });
      }
    }, err => console.log(err));
  }

  fetchProducts(): void {
    this.ps.getAllProductDetail().subscribe(res => {
      if (res && res.data) {
        res.data.forEach(item => {
          if (item.productId) {
            this.products.push({
              value: item.productId,
              viewValue: item.productName
            });
          }
        });
      }
    }, err => console.log(err));
  }

  cancelClick(): void {
    this.dialogRef.close();
  }

  submitForm(): void {
    this.salesTransaction.customerId = this.salesTransactionForm.get('customerId').value;
    this.salesTransaction.productId = this.salesTransactionForm.get('productId').value;
    this.salesTransaction.quantity = this.salesTransactionForm.get('quantity').value;
    this.dialogRef.close(this.salesTransaction);
  }

}
