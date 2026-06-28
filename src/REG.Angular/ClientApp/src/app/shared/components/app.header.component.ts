import {Component} from '@angular/core';
import {AppNavMenuComponent} from "./app.nav-menu.component";

@Component({
  selector: 'app-header',
  imports: [AppNavMenuComponent],
  templateUrl: './app.header.component.html'
})
export class AppHeaderComponent {
}
