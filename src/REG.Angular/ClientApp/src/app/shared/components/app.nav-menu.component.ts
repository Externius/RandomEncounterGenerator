import { Component } from '@angular/core';
import { TranslatePipe } from '@ngx-translate/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { NgClass } from '@angular/common';
import { AppLanguageMenuComponent } from './app.language.menu.component';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './app.nav-menu.component.html',
  imports: [TranslatePipe, RouterLink, NgClass, RouterLinkActive, AppLanguageMenuComponent],
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
