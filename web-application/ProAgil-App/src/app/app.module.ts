import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// para chamar api
import { HttpClientModule } from '@angular/common/http';
// para utilizar o "tiuei databaide" caixa de banana [()]
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { NavComponent } from './nav/nav.component';


@NgModule({
   declarations: [
      AppComponent,
      EventosComponent,
      NavComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule, // parachamarapi
      FormsModule // para utilizar o "tiuei databaide"
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
