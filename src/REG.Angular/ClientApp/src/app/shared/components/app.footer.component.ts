import { Component } from '@angular/core';
import { Constant } from '../constants/constant';
const { version: version } = require('../../../../package.json')

@Component({
    selector: 'app-footer',
    templateUrl: './app.footer.component.html'
})

export class AppFooterComponent {
    public version: string = version;
    public siteName: string = Constant.SiteName;
    public year: number = new Date().getFullYear();
}
