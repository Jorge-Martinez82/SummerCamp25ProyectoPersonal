import { Component, OnInit } from '@angular/core';
import { ComponenteTwinService, ComponenteTwinDto } from '../../services/componente-twin.service';


@Component({
  selector: 'tw-monitor',
  standalone: false,
  templateUrl: './monitor.html',
  styleUrl: './monitor.css'
})
export class Monitor implements OnInit {
  componentes: ComponenteTwinDto[] = [];
  loading = true;
  error: string | null = null;

  // Filtros
  nombre: string = '';
  estadoReal: string = '';
  estadoDigital: string = '';

  // Paginación
  numeroPagina: number = 1;
  tamanoPagina: number = 10;

  constructor(private componenteTwinService: ComponenteTwinService) {}

  ngOnInit() {
    this.cargarDatos();
  }

  cargarDatos() {
    this.loading = true;
    this.error = null;
    this.componenteTwinService.getComponentes(
      this.nombre || undefined,
      this.estadoReal || undefined,
      this.estadoDigital || undefined,
      this.numeroPagina,
      this.tamanoPagina
    ).subscribe({
      next: (data) => {
        this.componentes = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Error al cargar los datos';
        this.loading = false;
      }
    });
  }

  buscar() {
    this.numeroPagina = 1;
    this.cargarDatos();
  }

  paginaAnterior() {
    if (this.numeroPagina > 1) {
      this.numeroPagina--;
      this.cargarDatos();
    }
  }

  paginaSiguiente() {
    // No sabemos el total, así que solo avanzamos
    this.numeroPagina++;
    this.cargarDatos();
  }
}
