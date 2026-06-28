import {Component} from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import {AppHeaderComponent} from "./shared/components/app.header.component";
import {AppBodyComponent} from "./shared/components/app.body.component";
import {AppFooterComponent} from "./shared/components/app.footer.component";

@Component({
  selector: 'app-root',
  imports: [
    AppHeaderComponent,
    AppBodyComponent,
    AppFooterComponent
  ],
  templateUrl: './app.component.html'
})
export class AppComponent {
  constructor(translate: TranslateService) {
    translate.addLangs(['en', 'hu']);
    translate.setFallbackLang('en');
    translate.use('en');
  }
}
