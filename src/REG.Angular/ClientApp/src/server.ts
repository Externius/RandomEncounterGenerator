import { bootstrapApplication, BootstrapContext } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideTranslateService } from '@ngx-translate/core';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { provideRouter, TitleStrategy } from '@angular/router';
import { routes } from './app/app.routing';
import { CustomTitleStrategy } from './app/shared/strategies/custom.title.strategy';
import { CookieService } from 'ngx-cookie-service';
import { enableProdMode, provideZonelessChangeDetection } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localeHu from '@angular/common/locales/hu';
import localeEnGB from '@angular/common/locales/en-GB';
import { environment } from './environments/environment';
import { ServerErrorInterceptor } from './app/core/interceptors/server.error.interceptor';

if (environment.production) {
  enableProdMode();
}

registerLocaleData(localeEnGB, 'en');
registerLocaleData(localeHu, 'hu');

const bootstrap = (context: BootstrapContext) =>
  bootstrapApplication(
    AppComponent,
    {
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
          fallbackLang: 'en',
          lang: 'en'
        }),
        provideZonelessChangeDetection()
      ]
    },
    context
  );

export default bootstrap;
