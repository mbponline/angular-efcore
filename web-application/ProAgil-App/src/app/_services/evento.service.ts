import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Evento } from '../_models/Evento';

@Injectable({
  // disponibilizado em qualquer parte da raiz  do projeto para uso
  providedIn: 'root'
})
export class EventoService {

  baseURL = 'http://localhost:5000/api/evento';

  constructor(private http: HttpClient) {
  }

  // observable é lazy / preguiçoso / economico
  // promise é eager / ansioso / impaciente
  // retorno baseado em eventos
  getAllEvento(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL );
  }

  getEventoByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/getByTema/${tema}`);
  }

  getEventoById(id: number): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/${id}`);
  }

  postUpload(file: File, name: string) {
    const fileToUpload = <File>file[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, name);
    return this.http.post(`${this.baseURL}/upload`, FormData );
  }

  postEvento(evento: Evento) {
    return this.http.post(this.baseURL, evento );
  }

  putEvento(evento: Evento) {
    return this.http.put(`${this.baseURL}/${evento.id}`, evento);
  }

  deleteEvento(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
