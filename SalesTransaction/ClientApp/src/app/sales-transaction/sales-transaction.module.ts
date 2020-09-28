import { SalesTransactionComponent } from './sales-transaction.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesTransactionFormComponent } from './sales-transaction-form/sales-transaction-form.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { CdkTableModule } from '@angular/cdk/table';
import { SalesTransactionService } from './sales-transaction.service';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { MaterialModule } from '../shared/material.module';

const routes: Routes = [
  { path: '', component: SalesTransactionComponent }
];

@NgModule({
  declarations: [
    SalesTransactionComponent,
    [SalesTransactionFormComponent]
  ],
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
    MaterialModule,
    MatDialogModule
  ],
  exports: [
    SalesTransactionComponent
  ],
  providers: [
    SalesTransactionService
  ]
})
export class SalesTransactionModule { }
