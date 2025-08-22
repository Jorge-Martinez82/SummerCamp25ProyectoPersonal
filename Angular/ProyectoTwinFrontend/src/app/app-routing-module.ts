import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { Home } from './pages/home/home';
import { Monitor } from './pages/monitor/monitor';
import { About } from './pages/about/about';

const routes: Routes = [
  { path: '', component: Home },
  { path: 'home', component: Home },
  { path: 'monitor', component: Monitor },
  { path: 'about', component: About },
  { path: '**', redirectTo: '', pathMatch: 'full' }    // Redirige a Home
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
