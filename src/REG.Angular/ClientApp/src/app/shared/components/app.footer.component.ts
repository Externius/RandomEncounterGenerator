import { Component } from '@angular/core';
import packageInfo from '../../../../package.json';

@Component({
  selector: 'app-footer',
  templateUrl: './app.footer.component.html'
})
export class AppFooterComponent {
  public version: string = packageInfo.version;
  public year: number = new Date().getFullYear();
}
