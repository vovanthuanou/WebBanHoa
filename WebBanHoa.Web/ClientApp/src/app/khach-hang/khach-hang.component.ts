import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;



@Component({
  selector: 'app-khach-hang',
  templateUrl: './khach-hang.component.html',
  styleUrls: ['./khach-hang.component.css']
})
export class KhachHangComponent implements OnInit {
khachhangs:any ={
  data:[],
  totalRecord:0,
  page:0,
  size:3,
  totalpage:0
}
khachhang:any ={
maKh:0,
hoKh:"",
tenKh:"",
gioiTinh:"",
diaChi:"",
sdt:0

}
isEdit: boolean = true;
  constructor(
    private http: HttpClient,
     @Inject('BASE_URL') baseUrl: string
  ) { }

  ngOnInit() {
    this.searchKhachHang(1);
  }
  searchKhachHang(cPage){
    let x ={
      page:cPage,
      size:3,
      keyword:""
    }
   this.http.post('https://localhost:44321/api/KhachHang/search_khach-hang',x).subscribe(result=>{
    this.khachhangs =result;
    this.khachhangs = this.khachhangs.data;
     
  },error => console.error(error));
  
}
searchNext() {
  if (this.khachhangs.page < this.khachhangs.totalpage) {
    let nextPage = this.khachhangs.page + 1;
    this.searchKhachHang(nextPage);
  }
  else {
    alert("Bạn đang ở trang cuối !");
  }
}
searchPrevious() {
  if (this.khachhangs.page > 1) {
    let prePage = this.khachhangs.page - 1;
    this.searchKhachHang(prePage);
  }
  else {
    alert("Bạn đang ở trang đầu tiên !");
  }
}
openModal(isNew, index)
{
  if(isNew)
  {
    this.isEdit =false;
    this.khachhang={
    maKh:0,
    hoKh:"",
    tenKh:"",
    gioiTinh: "",
    diaChi: "",
    sdt: 0
    
  
    }
  }
  else{
    this.isEdit=true;
    this.khachhang= this.khachhangs.data[index];
    console.log(this.khachhang);
  }
  $('#exampleModal').modal('show')
}
addKhachHang()
{
  try
    {
      this.khachhang.maKh = parseInt( this.khachhang.maKh);
    }
    catch
    {
      alert("Lỗi mã khach hang");
    }
 
  this.http.post("https://localhost:44321/api/KhachHang/create_khach-hang",this.khachhang).subscribe(result=>
  {
  var res:any = result;
  if(res.success){
    this.khachhang=res.data;
     this.isEdit = true;
     this.searchKhachHang(1);
     alert("Tạo nhân viên mới thành công.");
  }  
  else
  {
    alert(res.message);
  }
}, error => {
  alert("Server error !!");
});
}
 

updateKhachHang()
{

  this.http.post("https://localhost:44321/api/KhachHang/update_khach-hang",this.khachhang).subscribe(result=>{
  var res:any = result;
  if(res.success){
    this.khachhang=res.data;
     this.isEdit = true;
     this.searchKhachHang(1);
     alert("Đã lưu thay đổi!");
    }
    else {
      alert(res.message);
    }
  }, error => {
    alert("Server error !!");
  });
}
deleteKhachHang(index) {
  var r = confirm("Bạn chắc chắn muốn xóa ?");
  if (r == true) {
    this.khachhang = this.khachhangs.data[index];
    var x:any = {maKh: this.khachhang.maKh};
    console.log(x);
    this.http.post('https://localhost:44321/api/KhachHang/delete_khachhang', x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.searchKhachHang(1);
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



