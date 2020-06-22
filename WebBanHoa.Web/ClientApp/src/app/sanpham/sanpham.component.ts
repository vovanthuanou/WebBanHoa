import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $: any;
@Component({
  selector: 'app-sanpham',
  templateUrl: './sanpham.component.html',
  styleUrls: ['./sanpham.component.css']
})
export class SanphamComponent implements OnInit {
  sanphams: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    totalpage: 0
  }
  sanpham: any = {
      maHoa: 0,
      tenHoa: "",
      giaMua: 0,
      giaBan: 0,
      soLuong: 0,
      tonKho: 0,
      moTa: ""
    }
    isEdit: boolean = true;
    constructor(
      private http: HttpClient,
      @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchSanpham(1);
  }
  searchSanpham(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: ""
    }
    this.http.post('https://localhost:44321/api/SanPham/search_sanpham', x).subscribe(result => {
      this.sanphams = result;
      this.sanphams = this.sanphams.data;
    }, error => console.error(error));
  }
  searchNext() {
    if (this.sanphams.page < this.sanphams.totalPages) {
      let nextPage = this.sanphams.page + 1;
      this.searchSanpham(nextPage);
    }
    else {
      alert("Bạn đang ở trang cuối !");
    }
  }
  searchPrevious() {
    if (this.sanphams.page > 1) {
      let prePage = this.sanphams.page - 1;
      this.searchSanpham(prePage);
    }
    else {
      alert("Bạn đang ở trang đầu tiên !");
    }
  }
  openModal(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.sanpham = {
      maHoa: 0,
      tenHoa: "",
      giaMua: 0,
      giaBan: 0,
      soLuong: 0,
      tonKho: 0,
      mota: null,
      }
    }
    else {
      this.isEdit = true;
      this.sanpham = this.sanphams.data[index];
     
    }
    $('#exampleModal').modal("show");
  }
  addSanpham() {
    try {
      this.sanpham.maHoa = parseInt(this.sanpham.maHoa);
    }
    catch
    {
      alert("Lỗi mã noa");
    }
    this.http.post('https://localhost:44321/api/SanPham/creat_sanPham', this.sanpham).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.sanpham = res.data;
        this.isEdit = true;
        this.searchSanpham(1);
        alert("Tạo sản phẩm mới thành công.");
      }
      else {
        alert(res.message);
      }
    }, error => {
      alert("Server error !!");
    });

  }
  updateSanpham() {
    this.http.post('https://localhost:44321/api/SanPham/update_sanpham', this.sanpham).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.sanpham = res.data;
        this.isEdit = true;
        this.searchSanpham(1);
        alert("Đã lưu thay đổi!");
      }
      else {
        alert(res.message);
      }
    }, error => {
      alert("Server error !!");
    });

  }
  deleteSanpham(index) {
    var r = confirm("Bạn chắc chắn muốn xóa ?");
    if (r == true) {
      this.sanpham = this.sanphams.data[index];
      var x:any = {maHoa: this.sanpham.maHoa};
      console.log(x);
      this.http.post('https://localhost:44321/api/SanPham/delete_sanpham', x).subscribe(result => {
        var res: any = result;
        if (res.success) {
          this.searchSanpham(1);
          alert("Đã xóa thành công !");
        }
        else {
          alert(res.message);
        }
      }, error => {
        alert(error);
      });
    }
  }

}
  
