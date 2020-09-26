import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from 'src/core/services/web-api.service';


@Injectable({
    providedIn: 'root'
})
export class ProductService {
    constructor(private api: WebApiService) { }

    getProduct(productId: number) {
        return this.api.get('product/productdetail', JSON.stringify({ productId: productId }));
    }

    getAllProductDetail() {
        return this.api.get('product/allproductdetail');
    }

    addProduct(json): Observable<any>{
        return this.api.post('/product/addproduct', json);
    }

}
