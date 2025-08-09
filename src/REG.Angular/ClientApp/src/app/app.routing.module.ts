import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {HomeComponent} from './modules/home/home.component';
import {EncounterListComponent} from './modules/encounter/encounter.list.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

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

@NgModule({
  imports: [RouterModule.forRoot(routes), NgbModule],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
