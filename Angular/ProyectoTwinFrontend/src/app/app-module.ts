import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';


import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Header } from './components/header/header';
import { Footer } from './components/footer/footer';
import { Home } from './pages/home/home';
import { Monitor } from './pages/monitor/monitor';
import { About } from './pages/about/about';

@NgModule({
  declarations: [
    App,
    Header,
    Footer,
    Home,
    Monitor,
    About
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
