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
  saleTransaction: MvSalesTransaction = {} as MvSalesTransaction;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<SalesTransactionFormComponent>,
    private ps: ProductService,
    private cs: CustomerService,
  ) {
    this.action = data.action;
    this.saleTransaction = data.data || {};
    dialogRef.disableClose = true;
  }

  ngOnInit(): void {
    this.salesTransactionForm = this.fb.group({
      customerId: [this.saleTransaction.customerId, Validators.required],
      productId: [this.saleTransaction.productId, Validators.required],
      quantity: [this.saleTransaction.quantity, Validators.required],
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
    this.saleTransaction.customerId = this.salesTransactionForm.get('customerId').value;
    this.saleTransaction.productId = this.salesTransactionForm.get('productId').value;
    this.saleTransaction.quantity = this.salesTransactionForm.get('quantity').value;
    this.dialogRef.close(this.saleTransaction);
  }

}
