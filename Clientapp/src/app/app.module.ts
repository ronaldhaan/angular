//modules
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';
//components
import { AppComponent } from './app.component';
import { HeroesComponent } from './components/heroes/heroes-index/heroes-index.component';
import { HeroDetailComponent } from './components/heroes/hero-detail/hero-detail.component';
import { HeroSearchComponent } from './components/heroes/hero-search/hero-search.component';
import { MessagesComponent } from './components/messages/messages.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HeroCreateComponent } from './components/heroes/hero-create/hero-create.component';
import { AbilityAddComponent } from './components/abilities/ability-add/ability-add.component';
import { AbilityDetailComponent } from './components/abilities/ability-detail/ability-detail.component';
import { AbilitiesIndexComponent } from './components/abilities/abilities-index/abilities-index.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  declarations: [
    AppComponent,
    // BaseComponent,
    DashboardComponent,
    HeroesComponent,
    HeroDetailComponent,
    HeroSearchComponent,
    MessagesComponent,
    HeroCreateComponent,
    AbilityAddComponent,
    AbilityDetailComponent,
    AbilitiesIndexComponent
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }