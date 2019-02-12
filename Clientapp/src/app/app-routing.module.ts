import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MetaHumanIndexComponent } from './components/metahumans/metahumans-index/metahuman-index.component';
import { MetahumanDetailComponent } from './components/metahumans/metahuman-detail/metahuman-detail.component';
import { MetahumanCreateComponent } from './components/metahumans/metahuman-create/metahuman-create.component';
import { AbilityDetailComponent } from './components/abilities/ability-detail/ability-detail.component';
import { AbilityCreateComponent } from './components/abilities/ability-create/ability-create.component';
import { AbilitiesIndexComponent } from './components/abilities/abilities-index/abilities-index.component';
import { MetahumanAbilityAddComponent } from './components/metahumans/metahuman-ability-add/metahuman-ability-add.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  // Heroes routes
  { path: 'metahuman', children: [
      { path: '', component: MetaHumanIndexComponent },
      { path: 'create', component: MetahumanCreateComponent },
      { path: ':id/detail', component: MetahumanDetailComponent },
      { path: ':id/add', component: MetahumanAbilityAddComponent },
    ]
  },
  // abilities routes
  { path: 'abilities', children: [
      { path: '', component: AbilitiesIndexComponent },
      { path: ':id/detail', component: AbilityDetailComponent},
      { path: 'add', component: AbilityCreateComponent },
    ]
  }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
