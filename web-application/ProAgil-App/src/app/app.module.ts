import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// para chamar api
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
// para utilizar o "tiuei databaide" caixa de banana [()]
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxMaskModule } from 'ngx-mask';
//ngx bootstrap
import { TooltipModule, BsDropdownModule, ModalModule, BsDatepickerModule } from 'ngx-bootstrap';

import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { NavComponent } from './nav/nav.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ContatosComponent } from './contatos/contatos.component';
import { TituloComponent } from './_shared/titulo/titulo.component';
import { EventoEditComponent } from './eventos/eventoEdit/eventoEdit.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';

import { EventoService } from './_services/evento.service';

import { DateTimeFormatPipePipe } from './_helpers/DateTimeFormatPipe.pipe';

import { AuthInterceptor } from './auth/auth.interceptor';
import { TabsModule } from 'ngx-bootstrap/tabs';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    EventosComponent,
    PalestrantesComponent,
    DateTimeFormatPipePipe,
    DashboardComponent,
    ContatosComponent,
    TituloComponent,
    UserComponent,
    LoginComponent,
    RegistrationComponent,
    EventoEditComponent
  ],
  imports: [
    BrowserModule,
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      progressBar: true,
      preventDuplicates: true
    }),
    NgxMaskModule.forRoot(),
    TabsModule.forRoot()
  ],
  providers: [
    EventoService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
