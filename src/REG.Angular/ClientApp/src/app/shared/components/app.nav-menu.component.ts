import {Component} from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './app.nav-menu.component.html',
  standalone: false,
  styleUrls: ['./app.nav-menu.component.css']
})
export class AppNavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
