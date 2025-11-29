import {ChangeDetectionStrategy, Component} from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import {Router} from '@angular/router';
import {CookieService} from 'ngx-cookie-service';

@Component({
  selector: 'app-language-menu',
  standalone: false,
  templateUrl: './app.language.menu.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppLanguageMenuComponent {
  constructor(private cookieService: CookieService, public translate: TranslateService, private router: Router) {
    const cookie = this.cookieService.get('.AspNetCore.Culture');
    if (cookie) {
      const lang = cookie.slice(-2);
      translate.use(lang);
    } else {
      translate.setFallbackLang('en');
    }
  }

  langClick(lang: string) {
    this.translate.use(lang);
    this.cookieService.set('.AspNetCore.Culture', `c=${lang}|uic=${lang}`);
    this.router.navigate(['/']);
  }
}
