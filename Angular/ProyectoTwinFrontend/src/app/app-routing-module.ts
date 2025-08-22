import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { Home } from './pages/home/home';
import { Monitor } from './pages/monitor/monitor';
import { About } from './pages/about/about';
import { Detalle } from './pages/detalle/detalle';

const routes: Routes = [
  { path: '', component: Home },
  { path: 'home', component: Home },
  { path: 'monitor', component: Monitor },
  { path: 'about', component: About },
  { path: 'detalle/:id', component: Detalle },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
