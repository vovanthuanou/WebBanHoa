import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { ProductsComponent } from "./products/products.component";
import { AppComponent } from "./app.component";
import { CartComponent } from "./cart/cart.component";
import { HeaderComponent } from "./share/header/header.component";
import { LoginComponent } from "./share/login/login.component";
import { HomeComponent } from "./home/home.component";
import { FooterComponent} from "./share/footer/footer.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HeaderComponent,
    ProductsComponent,
    FooterComponent,
    CartComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },

      { path: "login", component: LoginComponent },
      
      { path: "product-detail", component: ProductsComponent },

      // Access for Registered Users
      { path: "shopping-cart", component: CartComponent },


    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
