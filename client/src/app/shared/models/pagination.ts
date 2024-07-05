export interface Pagination<T> {
  pageNum: number;
  pageSize: number;
  count: number;
  data: T;
}
