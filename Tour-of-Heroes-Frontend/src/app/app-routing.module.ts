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
import { TeamIndexComponent } from './components/teams/team-index/team-index.component';
import { TeamDetailsComponent } from './components/teams/team-details/team-details.component';
import { TeamCreateComponent } from './components/teams/team-create/team-create.component';
import { TeamMetahumanAddComponent } from './components/teams/team-metahuman-add/team-metahuman-add.component';

const routes: Routes = [
    { path: 'dashboard', component: DashboardComponent,  },
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    // Metas routes
    { path: 'metas', children: [
            { path: '', component: MetaHumanIndexComponent },
            { path: 'create', component: MetahumanCreateComponent },
            { path: ':id/detail', component: MetahumanDetailComponent },
            { path: ':id/add', component: MetahumanAbilityAddComponent },
        ],
    },
    // abilities routes
    { path: 'abilities', children: [
            { path: '', component: AbilitiesIndexComponent },
            { path: ':id/detail', component: AbilityDetailComponent},
            { path: 'add', component: AbilityCreateComponent },
        ]
    },
    // teams routes
    {
        path: 'teams', children: [
            { path: '', component: TeamIndexComponent },
            { path: ':id/detail', component: TeamDetailsComponent },
            { path: 'add', component: TeamCreateComponent },
            { path: ':id/add', component: TeamMetahumanAddComponent },
        ]
    }

];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
