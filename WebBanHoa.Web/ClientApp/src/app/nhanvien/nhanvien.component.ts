import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $: any;

@Component({
  selector: 'app-nhanvien',
  templateUrl: './nhanvien.component.html',
  styleUrls: ['./nhanvien.component.css']
})
export class NhanvienComponent implements OnInit {
  nhanviens: any = {
    data: [],
    totalRecord: 0,
    page: 0,
    size: 5,
    totalpage: 0
  }
  nowDate = new Date();
  nhanvien: any = {

    maNv: 0,
    hoNv: "",
    tenNv: "",
    gioiTinh: "",
    chucVu: "",
    ngaySinh: this.nowDate.toJSON(),
    ngayLam: this.nowDate.toJSON(),
    soCmnd: 0,
    diaChi: "string",
    luong: 0
  }
  isEdit: boolean = true;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchNhanVien(1);
  }
  searchNhanVien(cPage) {
    let x = {
      page: cPage,
      size: 5,
      keyword: ""
    }
    this.http.post('https://localhost:44321/api/NhanVien/search_NhanVien', x).subscribe(result => {
      this.nhanviens = result;
      this.nhanviens = this.nhanviens.data;
    }, error => console.error(error));
  }
  searchNext() {
    if (this.nhanviens.page < this.nhanviens.totalpage) {
      let nextPage = this.nhanviens.page + 1;
      this.searchNhanVien(nextPage);
    }
    else {
      alert("Bạn đang ở trang cuối !");
    }
  }
  searchPrevious() {
    if (this.nhanviens.page > 1) {
      let prePage = this.nhanviens.page - 1;
      this.searchNhanVien(prePage);
    }
    else {
      alert("Bạn đang ở trang đầu tiên !");
    }
  }

  openModal(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.nhanvien = {

        maNv: 0,
        hoNv: "",
        tenNv: "",
        gioiTinh: "",
        chucVu: "",
        ngaySinh: this.nowDate.toJSON(),
        ngayLam: this.nowDate.toJSON(),
        soCmnd: 0,
        diaChi: "string",
        luong: 0
      }
    }
    else {
      this.isEdit = true;
      this.nhanvien = this.nhanviens.data[index];
      console.log(this.nhanvien);
    }
    $('#exampleModal').modal("show");
  }
  addNhanvien() {
    try {
      this.nhanvien.maNv = parseInt(this.nhanvien.maNv);
    }
    catch
    {
      alert("Lỗi mã nhân viên");
    }
    this.http.post('https://localhost:44321/api/NhanVien/create_nhanvien', this.nhanvien).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.nhanvien = res.data;
        this.isEdit = true;
        this.searchNhanVien(1);
        alert("Tạo nhân viên mới thành công.");
      }
      else {
        alert(res.message);
      }
    }, error => {
      alert("Server error !!");
    });

  }

  updateNhanvien() {
    this.http.put('https://localhost:44321/api/NhanVien/update_nhanvien', this.nhanvien).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.nhanvien = res.data;
        this.isEdit = true;
        this.searchNhanVien(1);
        alert("Đã lưu thay đổi!");
      }
      else {
        alert(res.message);
      }
    }, error => {
      alert("Server error !!");
    });

  }

  deleteNhanvien(index) {
    var r = confirm("Bạn chắc chắn muốn xóa ?");
    if (r == true) {
      this.nhanvien = this.nhanviens.data[index];
      var x:any = {maNv: this.nhanvien.maNv};
      console.log(x);
      this.http.post('https://localhost:44321/api/NhanVien/delete-nhanvien', x).subscribe(result => {
        var res: any = result;
        if (res.success) {
          this.searchNhanVien(1);
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


