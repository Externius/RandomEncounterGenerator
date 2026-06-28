import {bootstrapApplication, BootstrapContext} from '@angular/platform-browser';
import {AppComponent} from './app/app.component';
import {provideServerRendering} from '@angular/platform-server';

const bootstrap = (context: BootstrapContext) =>
  bootstrapApplication(AppComponent, {
    providers: [
      provideServerRendering()
    ]
  }, context);
export default bootstrap;
