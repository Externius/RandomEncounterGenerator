import { Component } from '@angular/core';
import packageInfo from '../../../../package.json';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'app-footer',
  imports: [TranslatePipe],
  templateUrl: './app.footer.component.html'
})
export class AppFooterComponent {
  public version: string = packageInfo.version;
  public year: number = new Date().getFullYear();
}
