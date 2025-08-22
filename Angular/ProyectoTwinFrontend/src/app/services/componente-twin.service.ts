import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ComponenteTwinDto {
  idComponente: number;
  nombre?: string;
  tipoDatos?: string;
  estadoReal?: string;
  estadoDigital?: string;
  ultimaActualizacion: string;
  indicadorSostenibilidad?: string;
  mantenimientoProgramado: boolean;
}

@Injectable({ providedIn: 'root' })
export class ComponenteTwinService {
  private apiUrl = 'https://localhost:7110/api/ComponenteTwin';

  constructor(private http: HttpClient) {}

  getComponentes(
    nombre?: string,
    estadoReal?: string,
    estadoDigital?: string,
    numeroPagina: number = 1,
    tamanoPagina: number = 10
  ): Observable<ComponenteTwinDto[]> {
    let params = new HttpParams();
    if (nombre) params = params.set('nombre', nombre);
    if (estadoReal) params = params.set('estadoReal', estadoReal);
    if (estadoDigital) params = params.set('estadoDigital', estadoDigital);
    params = params.set('numeroPagina', numeroPagina.toString());
    params = params.set('tamanoPagina', tamanoPagina.toString());
    return this.http.get<ComponenteTwinDto[]>(this.apiUrl, { params });
  }

  getComponenteById(id: number): Observable<ComponenteTwinDto> {
    return this.http.get<ComponenteTwinDto>(`${this.apiUrl}/${id}`);
  }
}
