import {enableProdMode, provideZonelessChangeDetection} from '@angular/core';
import {environment} from './environments/environment';
import {bootstrapApplication} from "@angular/platform-browser";
import {AppComponent} from "./app/app.component";
import {provideRouter, TitleStrategy} from "@angular/router";
import {CookieService} from "ngx-cookie-service";
import {CustomTitleStrategy} from "./app/shared/strategies/custom.title.strategy";
import {provideHttpClient, withInterceptorsFromDi} from "@angular/common/http";
import {routes} from "./app/app.routing";
import {provideTranslateService} from "@ngx-translate/core";
import {provideTranslateHttpLoader} from "@ngx-translate/http-loader";

if (environment.production) {
  enableProdMode();
}

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi()),
    {provide: TitleStrategy, useClass: CustomTitleStrategy},
    CookieService,
    provideTranslateService({
      loader: provideTranslateHttpLoader({prefix: "./assets/i18n/", suffix: ".json"}),
      fallbackLang: "en",
      lang: "en"
    }),
    provideZonelessChangeDetection()
  ]
});
