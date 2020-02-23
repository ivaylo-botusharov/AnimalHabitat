import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginFormComponent } from './shared/components';
import { AuthGuardService } from './shared/services';
import { HomeComponent } from './pages/home/home.component';
import { AnimalsComponent } from './pages/animals/animals.component';
import { DisplayDataComponent } from './pages/display-data/display-data.component';
import {
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
    path: 'display-data',
    component: DisplayDataComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'animals',
    component: AnimalsComponent,
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
    DxDataGridModule,
    DxFormModule,
    DxButtonModule,
    DxTreeMapModule,
    DxChartModule
  ],
  providers: [AuthGuardService],
  exports: [RouterModule],
  declarations: [HomeComponent, AnimalsComponent, DisplayDataComponent, ChartsComponent]
})
export class AppRoutingModule { }
