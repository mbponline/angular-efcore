import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// para chamar api
import { HttpClientModule } from '@angular/common/http';
// para utilizar o "tiuei databaide" caixa de banana [()]
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
//ngx bootstrap
import { TooltipModule, BsDropdownModule, ModalModule, BsDatepickerModule  } from 'ngx-bootstrap';

import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { NavComponent } from './nav/nav.component';

import { DateTimeFormatPipePipe } from './_helpers/DateTimeFormatPipe.pipe';

import { EventoService } from './_services/evento.service';


@NgModule({
   declarations: [
      AppComponent,
      EventosComponent,
      NavComponent,
      DateTimeFormatPipePipe
   ],
   imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      BsDatepickerModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      AppRoutingModule,
      HttpClientModule, // parachamarapi      
      FormsModule,       // para utilizar o "tiuei databaide" 
      ReactiveFormsModule
   ],   
   providers: [
      EventoService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
