import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../shared/models/product';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';
import { GetProductParams } from '../shared/models/getProductParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  @ViewChild('search') search?: ElementRef;
  products: Product[] = [];
  brands: Brand[] = [];
  types: Type[] = [];
  getProductParams: GetProductParams = new GetProductParams();
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' },
  ];

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.getProductParams).subscribe({
      next: (response) => {
        this.products = response.data;
        this.getProductParams.pageNumber = response.pageNum;
        this.getProductParams.pageSize = response.pageSize;
        this.getProductParams.count = response.count;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  getBrands() {
    this.shopService.getBrands().subscribe({
      next: (response) => {
        this.brands = [{ id: 0, name: 'All' }, ...response];
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  getTypes() {
    this.shopService.getTypes().subscribe({
      next: (response) => {
        this.types = [{ id: 0, name: 'All' }, ...response];
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  onBrandSelected(brandId: number) {
    this.getProductParams.brandId = brandId;
    this.getProductParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeId: number) {
    this.getProductParams.typeId = typeId;
    this.getProductParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(event: any) {
    this.getProductParams.sort = event.target.value;
    this.getProducts();
  }

  onSearch() {
    this.getProductParams.search = this.search?.nativeElement.value;
    this.getProductParams.pageNumber = 1;
    this.getProducts();
  }

  onReset() {
    this.search!.nativeElement.value = '';
    this.getProductParams = new GetProductParams();
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.getProductParams.pageNumber !== event) {
      this.getProductParams.pageNumber = event;
      this.getProducts();
    }
  }
}
