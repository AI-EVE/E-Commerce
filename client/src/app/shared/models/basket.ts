import * as cuid from 'cuid';

export interface BasketItem {
  id: number;
  productName: string;
  price: number;
  pictureUrl: string;
  brand: string;
  type: string;
  quantity: number;
}
export interface Basket {
  id: string;
  items: BasketItem[];
}

export class Basket implements Basket {
  id: string = cuid();
  items: BasketItem[] = [];
}

export interface BasketTotals {
  shipping: number;
  subtotal: number;
  total: number;
}
