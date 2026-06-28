import {Routes} from '@angular/router';
import {HomeComponent} from './modules/home/home.component';
import {EncounterListComponent} from './modules/encounter/encounter.list.component';

export const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    title: 'home.homemenu'
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'encounter',
    component: EncounterListComponent,
    title: 'home.encountermenu'
  }
];
