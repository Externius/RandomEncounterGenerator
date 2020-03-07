import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './modules/home/home.component';
import { AppNavMenuComponent } from './shared/components/app.nav-menu.component';
import { AppHeaderComponent } from './shared/components/app.header.component';
import { AppBodyComponent } from './shared/components/app.body.component';
import { AppFooterComponent } from './shared/components/app.footer.component';
import { EncounterListComponent } from './modules/encounter/encounter.list.component';
import { EncounterDetailComponent } from './modules/encounter/encounter.detail.component';
import { AppRoutingModule } from './app.routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import localeHu from '@angular/common/locales/hu';
import localeEnGB from '@angular/common/locales/en-GB';
import { registerLocaleData } from '@angular/common';
import { AppLanguageMenuComponent } from './shared/components/app.language.menu.component';
import { CookieService } from 'ngx-cookie-service';
import { ServerErrorInterceptor } from './core/interceptors/server.error.interceptor';
import { AlertDialogComponent } from './core/alertdialog/alertdialog.component';
import { SortableHeaderDirective } from './shared/directive/sortable.directive';

export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient);
}

@NgModule({
  declarations: [
    AppComponent,
    AppNavMenuComponent,
    AppHeaderComponent,
    AppBodyComponent,
    AppFooterComponent,
    AppLanguageMenuComponent,
    AlertDialogComponent,
    HomeComponent,
    SortableHeaderDirective,
    EncounterListComponent,
    EncounterDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    NgSelectModule,
    FormsModule,
    ReactiveFormsModule,
    FontAwesomeModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ]),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
   exports: [TranslateModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ServerErrorInterceptor,
      multi: true
    },
    CookieService
  ],
  entryComponents: [
    AlertDialogComponent
  ],
  bootstrap: [AppComponent,
    AppNavMenuComponent,
    AppHeaderComponent,
    AppBodyComponent,
    AppFooterComponent,
    AppLanguageMenuComponent
  ]
})
export class AppModule {
  constructor() {
    registerLocaleData(localeEnGB, 'en');
    registerLocaleData(localeHu, 'hu');
  }
}
