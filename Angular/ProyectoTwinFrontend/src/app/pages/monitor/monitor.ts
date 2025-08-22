// ...existing code...
import { Component, OnInit } from '@angular/core';
import { ComponenteTwinService, ComponenteTwinDto, ComponenteTwinResponse } from '../../services/componente-twin.service';


@Component({
  selector: 'tw-monitor',
  standalone: false,
  templateUrl: './monitor.html',
  styleUrl: './monitor.css'
})
export class Monitor implements OnInit {
  componentes: ComponenteTwinDto[] = [];
  totalRegistros: number = 0;
  totalPaginas: number = 1;
  paginaActual: number = 1;
  tamanoPagina: number = 10;
  loading = false;
  error: string | null = null;

  // Filtros
  nombre: string = '';
  estadoReal: string = '';
  estadoDigital: string = '';

  constructor(private componenteTwinService: ComponenteTwinService) {}

  ngOnInit() {
    this.buscar();
  }

  buscar() {
    this.loading = true;
    this.error = null;
    this.componenteTwinService.getComponentes(
      this.nombre || undefined,
      this.estadoReal || undefined,
      this.estadoDigital || undefined,
      this.paginaActual,
      this.tamanoPagina
    ).subscribe({
      next: (resp: ComponenteTwinResponse) => {
        this.componentes = resp.items;
        this.totalRegistros = resp.total;
        this.totalPaginas = Math.ceil(this.totalRegistros / this.tamanoPagina) || 1;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Error al cargar los datos';
        this.loading = false;
      }
    });
  }

  resetFiltros() {
    this.nombre = '';
    this.estadoReal = '';
    this.estadoDigital = '';
    this.paginaActual = 1;
    this.buscar();
  }



  irPrimeraPagina(): void {
    if (this.paginaActual > 1) {
      this.paginaActual = 1;
      this.buscar();
    }
  }

  irUltimaPagina(): void {
    if (this.paginaActual < this.totalPaginas) {
      this.paginaActual = this.totalPaginas;
      this.buscar();
    }
  }

  paginaAnterior(): void {
    if (this.paginaActual > 1) {
      this.paginaActual--;
      this.buscar();
    }
  }

  paginaSiguiente(): void {
    if (this.paginaActual < this.totalPaginas) {
      this.paginaActual++;
      this.buscar();
    }
  }
}
