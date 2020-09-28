import { CdkTableModule } from '@angular/cdk/table';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './customer.component';
import { CustomerService } from './customer.service';
import { CustomerFormComponent } from './customer-form/customer-form.component';


const routes: Routes = [
    {
        path: '',
        component: CustomerComponent
    }
];

@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        MatTableModule,
        MatButtonModule,
        MatInputModule,
        MatToolbarModule,
        MatFormFieldModule,
        HttpClientModule,
        ReactiveFormsModule,
        CdkTableModule,
        MatDialogModule
    ],
    declarations: [
        CustomerComponent,
        CustomerFormComponent

    ],
    providers: [
        CustomerService
    ],
    exports: [
        CustomerComponent
    ]

})

export class CustomerModule {
}
