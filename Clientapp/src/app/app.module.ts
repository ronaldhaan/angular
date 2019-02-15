// modules
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
// components
import { AppComponent } from './app.component';
import { MetaHumanIndexComponent } from './components/metahumans/metahumans-index/metahuman-index.component';
import { MetahumanDetailComponent } from './components/metahumans/metahuman-detail/metahuman-detail.component';
import { MetahumanSearchComponent } from './components/metahumans/metahuman-search/metahuman-search.component';
import { MessagesComponent } from './components/messages/messages.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MetahumanCreateComponent } from './components/metahumans/metahuman-create/metahuman-create.component';
import { AbilityCreateComponent } from './components/abilities/ability-create/ability-create.component';
import { AbilityDetailComponent } from './components/abilities/ability-detail/ability-detail.component';
import { AbilitiesIndexComponent } from './components/abilities/abilities-index/abilities-index.component';
import { MetahumanAbilityAddComponent } from './components/metahumans/metahuman-ability-add/metahuman-ability-add.component';
import { TeamIndexComponent } from './components/teams/team-index/team-index.component';
import { TeamDetailsComponent } from './components/teams/team-details/team-details.component';
import { TeamCreateComponent } from './components/teams/team-create/team-create.component';
import { TeamMetahumanAddComponent } from './components/teams/team-metahuman-add/team-metahuman-add.component';
import {TruncatePipe} from './Pipes/truncate-pipe';

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
    MetaHumanIndexComponent,
    MetahumanDetailComponent,
    MetahumanSearchComponent,
    MessagesComponent,
    MetahumanCreateComponent,
    AbilityCreateComponent,
    AbilityDetailComponent,
    AbilitiesIndexComponent,
    MetahumanAbilityAddComponent,
    TeamIndexComponent,
    TeamDetailsComponent,
    TeamCreateComponent,
    TeamMetahumanAddComponent,
    TruncatePipe,
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
