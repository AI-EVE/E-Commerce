import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { Type } from '../shared/models/type';
import { GetProductParams } from '../shared/models/getProductParams';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  apiUrl: string = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getProducts(getProductParams: GetProductParams) {
    let params = new HttpParams();

    if (getProductParams.brandId > 0) {
      params = params.append('brandId', getProductParams.brandId.toString());
    }

    if (getProductParams.typeId) {
      params = params.append('typeId', getProductParams.typeId.toString());
    }

    params = params.append('sortedBy', getProductParams.sort);
    params = params.append('pageNum', getProductParams.pageNumber);
    params = params.append('pageSize', getProductParams.pageSize);
    params = params.append('search', getProductParams.search);

    return this.http.get<Pagination<Product[]>>(this.apiUrl + 'products', {
      params,
    });
  }

  getTypes() {
    return this.http.get<Type[]>(this.apiUrl + 'products/types');
  }

  getBrands() {
    return this.http.get<Type[]>(this.apiUrl + 'products/brands');
  }
}
