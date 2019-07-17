import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// para chamar api
import { HttpClientModule } from '@angular/common/http';
// para utilizar o "tiuei databaide" caixa de banana [()]
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
//ngx bootstrap
import { TooltipModule, BsDropdownModule, ModalModule } from 'ngx-bootstrap';

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
      DateTimeFormatPipePipe //formato de datas criado
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      // parachamarapi
      HttpClientModule,
      // para utilizar o "tiuei databaide" 
      FormsModule,

      //ngx bootstrap
      BsDropdownModule.forRoot(), //disponível para toda raiz do projeto
      TooltipModule.forRoot(),
      ModalModule.forRoot()
   ],
   providers: [
      EventoService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
