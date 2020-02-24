import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginFormComponent } from './shared/components';
import { AuthGuardService } from './shared/services';
import { HomeComponent } from './pages/home/home.component';
import { SpeciesDistributionFormComponent } from './pages/species-distribution-form/species-distribution-form.component';
import { SpeciesDistributionComponent } from './pages/species-distribution/species-distribution.component';
import {
  DxSelectBoxModule,
  DxDataGridModule,
  DxFormModule,
  DxButtonModule,
  DxTreeMapModule,
  DxChartModule
} from 'devextreme-angular';
import { ChartsComponent } from './pages/charts/charts.component';

const routes: Routes = [
  {
    path: 'pages/charts',
    component: ChartsComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'species-distribution',
    component: SpeciesDistributionComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'create-distribution',
    component: SpeciesDistributionFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'login-form',
    component: LoginFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: '**',
    redirectTo: 'home',
    canActivate: [ AuthGuardService ]
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    DxSelectBoxModule,
    DxDataGridModule,
    DxFormModule,
    DxButtonModule,
    DxTreeMapModule,
    DxChartModule
  ],
  providers: [AuthGuardService],
  exports: [RouterModule],
  declarations: [
    HomeComponent,
    SpeciesDistributionFormComponent,
    SpeciesDistributionComponent,
    ChartsComponent]
})
export class AppRoutingModule { }
