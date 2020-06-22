import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { KhachHangComponent } from './khach-hang/khach-hang.component';
import { NhanvienComponent } from './nhanvien/nhanvien.component';
import { SanphamComponent } from './sanpham/sanpham.component';
import { HeaderComponent } from "./share/header/header.component";
import { LoginComponent } from "./share/login/login.component";
import { FooterComponent} from "./share/footer/footer.component";
import { CartComponent } from "./cart/cart.component"

@NgModule({
  declarations: [
    AppComponent,
    CartComponent,
    HomeComponent,
    LoginComponent,
    HeaderComponent,
    FooterComponent,
    CounterComponent,
    FetchDataComponent,
    KhachHangComponent,
    NhanvienComponent,
    SanphamComponent
  
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'search-khach-hang', component: KhachHangComponent },
      { path: 'search-nhanvien', component: NhanvienComponent },
      { path: 'search-sanpham', component: SanphamComponent },
      { path: "login", component: LoginComponent },
      { path: "cart", component: CartComponent },
     
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
