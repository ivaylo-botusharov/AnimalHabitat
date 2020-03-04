import { Routes } from '@angular/router';

import { HomeComponent } from '../../home/home.component';
import { CreateDistributionComponent } from '../../create-distribution/create-distribution.component';
import { SpeciesDistributionComponent } from '../../species-distribution/species-distribution.component';

export const AdminLayoutRoutes: Routes = [
    // {
    //   path: '',
    //   children: [ {
    //     path: 'dashboard',
    //     component: HomeComponent
    // }]},
    // {
    //     path: '',
    //     children: [ {
    //         path: 'upgrade',
    //         component: UpgradeComponent
    //     }]
    // }
    { path: 'home',           component: HomeComponent },
    { path: 'create-distribution',   component: CreateDistributionComponent },
    { path: 'species-distribution',     component: SpeciesDistributionComponent },
];
