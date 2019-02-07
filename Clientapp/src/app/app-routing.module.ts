import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent }   from './components/dashboard/dashboard.component';
import { HeroesComponent }      from './components/heroes/heroes-index/heroes-index.component';
import { HeroDetailComponent }  from './components/heroes/hero-detail/hero-detail.component';
import { HeroCreateComponent } from './components/heroes/hero-create/hero-create.component';
import { AbilityDetailComponent } from './components/abilities/ability-detail/ability-detail.component';
import { AbilityAddComponent } from './components/abilities/ability-add/ability-add.component';
import { AbilitiesIndexComponent } from './components/abilities/abilities-index/abilities-index.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  // Heroes routes
  { path: 'heroes', children: [
      { path: '', component: HeroesComponent },
      { path: 'create', component: HeroCreateComponent },
      { path: ':id/detail', component: HeroDetailComponent },
    ]
  },
  // abilities routes
  { path: 'abilities', children: [
      { path: '', component: AbilitiesIndexComponent },
      { path: ':id/detail', component: AbilityDetailComponent},
      { path: ':id/add', component: AbilityAddComponent },
    ] 
  }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}