import { enableProdMode, provideZonelessChangeDetection } from '@angular/core';
import { environment } from './environments/environment';
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideRouter, TitleStrategy } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { CustomTitleStrategy } from './app/shared/strategies/custom.title.strategy';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { routes } from './app/app.routing';
import { provideTranslateService } from '@ngx-translate/core';
import { provideTranslateHttpLoader } from '@ngx-translate/http-loader';
import { registerLocaleData } from '@angular/common';
import localeHu from '@angular/common/locales/hu';
import localeEnGB from '@angular/common/locales/en-GB';
import { ServerErrorInterceptor } from './app/core/interceptors/server.error.interceptor';

if (environment.production) {
  enableProdMode();
}

registerLocaleData(localeEnGB, 'en');
registerLocaleData(localeHu, 'hu');

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi()),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ServerErrorInterceptor,
      multi: true
    },
    { provide: TitleStrategy, useClass: CustomTitleStrategy },
    { provide: 'API_URL', useValue: environment.apiUrl },
    CookieService,
    provideTranslateService({
      loader: provideTranslateHttpLoader({
        prefix: 'assets/i18n/',
        suffix: '.json'
      }),
      fallbackLang: 'en',
      lang: 'en'
    }),
    provideZonelessChangeDetection()
  ]
});
