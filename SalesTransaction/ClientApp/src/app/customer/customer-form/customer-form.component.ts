import { AfterViewInit, Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MvEditCustomer } from '../customer.model';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.scss']
})
export class CustomerFormComponent implements OnInit, AfterViewInit {

  customerForm: FormGroup;
  action: string;
  // tslint:disable-next-line: radix
  userId = parseInt(localStorage.getItem('userId'));
  selectedCustomer: MvEditCustomer = <MvEditCustomer>{};

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<CustomerFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) {
    this.action = data.action;
    this.selectedCustomer = data.data || {};
  }

  ngOnInit(): void {
    this.customerForm = this.fb.group({
      firstName: ['', Validators.required],
      middleName: ['', Validators.required],
      lastName: ['', Validators.required],
      customerAddress: ['', Validators.required],
      emailId: ['', Validators.required],
      phoneNo: ['', [Validators.required, Validators.pattern('[0-9]*')]],
      insertPersonId: [this.userId]
    });
  }

  onSubmit() {
    this.dialogRef.close(this.selectedCustomer);
  }

  onClose() {
    this.dialogRef.close();
  }

  ngAfterViewInit(): void {
    this.customerForm.updateValueAndValidity();
  }

}
