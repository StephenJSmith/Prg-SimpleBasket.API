import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
let ProductsService = class ProductsService {
    constructor(http) {
        this.http = http;
        this.baseUrl = 'http://localhost:/5000/api/products';
    }
    getProducts() {
        const url = this.baseUrl;
        return this.http.get(url);
    }
};
ProductsService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], ProductsService);
export { ProductsService };
//# sourceMappingURL=products.service.js.map