import {enableProdMode} from '@angular/core';
import {AppModule} from './app/app.module';
import {environment} from './environments/environment';
import {platformBrowser} from "@angular/platform-browser";

export function getApiUrl() {
  return environment.apiUrl;
}

const providers = [{provide: 'API_URL', useFactory: getApiUrl, deps: []}];

if (environment.production) {
  enableProdMode();
}

platformBrowser(providers)
  .bootstrapModule(AppModule)
  .catch((err) => console.log(err));
