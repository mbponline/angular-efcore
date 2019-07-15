import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
//para chamar api 
import { HttpClientModule } from '@angular/common/http'; 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';


@NgModule({
   declarations: [
      AppComponent,
      EventosComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule //para chamar api 
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
