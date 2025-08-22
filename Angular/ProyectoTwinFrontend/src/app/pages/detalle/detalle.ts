import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ComponenteTwinService, ComponenteTwinDto } from '../../services/componente-twin.service';

@Component({
  selector: 'tw-detalle',
  standalone: false,
  templateUrl: './detalle.html',
  styleUrl: './detalle.css'
})
export class Detalle implements OnInit {
  componente?: ComponenteTwinDto;
  loading = true;
  error: string | null = null;

  constructor(private route: ActivatedRoute, private service: ComponenteTwinService) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.service.getComponenteById(id).subscribe({
        next: (data) => {
          this.componente = data;
          this.loading = false;
        },
        error: () => {
          this.error = 'No se pudo cargar el componente';
          this.loading = false;
        }
      });
    } else {
      this.error = 'ID no válido';
      this.loading = false;
    }
  }
}
