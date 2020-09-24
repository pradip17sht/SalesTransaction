import { Injectable } from '@angular/core';
import { WebApiService } from 'src/core/services/web-api.service';


@Injectable({
    providedIn: 'root'
})
export class CustomerService {
    constructor(private api: WebApiService) { }

    getCustomer(customerId: number) {
        return this.api.get('customer/customerdetail', JSON.stringify({ customerId: customerId }));
    }

    getAllCustomerDetail() {
        return this.api.get('customer/allcustomerdetail');
    }

}
