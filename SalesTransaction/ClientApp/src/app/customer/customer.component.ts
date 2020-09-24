import { Component, OnInit } from '@angular/core';
import { MvCustomer } from './customer.model';
import { CustomerService } from './customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  userMessage = '';
  displayedColumns: string[];
  dataSource: MvCustomer[] = [];

  constructor(
    private customerService: CustomerService
  ) { }

  ngOnInit(): void {
    this.displayedColumns = ['customerId', 'firstName', 'middleName', 'lastName', 'customerAddress', 'emailId', 'phoneNo', 'district'];
    this.getAllCustomerDetail();
  }
  getAllCustomerDetail() {
    this.customerService.getAllCustomerDetail().subscribe((data: any) => {
      if (data && data.data) {
        this.dataSource = data.data;
      } else {
        this.dataSource = [];
        this.userMessage = 'No customer available !';
      }
    });

  }

}
