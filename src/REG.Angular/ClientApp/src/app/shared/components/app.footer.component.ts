import { Component } from '@angular/core';
const { version: version } = require('../../../../package.json')

@Component({
    selector: 'app-footer',
    templateUrl: './app.footer.component.html'
})

export class AppFooterComponent {
    public version: string = version;
    public year: number = new Date().getFullYear();
}
