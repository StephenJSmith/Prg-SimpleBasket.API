import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ProductsComponent = class ProductsComponent {
    constructor(productService) {
        this.productService = productService;
        this.products = [];
    }
    ngOnInit() {
        this.productService.getProducts()
            .subscribe(products => {
            this.products = products;
        }, err => {
            console.error(err);
        });
    }
};
ProductsComponent = __decorate([
    Component({
        selector: 'app-products',
        templateUrl: './products.component.html',
        styleUrls: ['./products.component.css']
    })
], ProductsComponent);
export { ProductsComponent };
//# sourceMappingURL=products.component.js.map