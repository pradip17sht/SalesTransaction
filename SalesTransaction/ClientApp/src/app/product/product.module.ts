import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product.component';
import { ProductService } from './product.service';

const routes: Routes = [
    {
        path: '',
        component: ProductComponent
    }
];

@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        MatTableModule,
        MatButtonModule,
        HttpClientModule
    ],
    declarations: [
        ProductComponent

    ],
    providers: [
        ProductService
    ],
    exports: [
        ProductComponent
    ]

})

export class ProductModule {
}
