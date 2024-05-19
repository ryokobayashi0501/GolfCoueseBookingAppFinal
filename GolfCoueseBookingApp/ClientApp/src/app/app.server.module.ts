//import { NgModule } from '@angular/core';
//import { ServerModule } from '@angular/platform-server';
//import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
//import { AppComponent } from './app.component';
//import { AppModule } from './app.module';

//@NgModule({
//    imports: [AppModule, ServerModule, ModuleMapLoaderModule],
//    bootstrap: [AppComponent]
//})
//export class AppServerModule { }


import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModule } from './app.module';
import { AppComponent } from './app.component';

@NgModule({
  imports: [
    AppModule,
    ServerModule
    // The ModuleMapLoaderModule is no longer needed and should be removed.
  ],
  bootstrap: [AppComponent],
})
export class AppServerModule { }
