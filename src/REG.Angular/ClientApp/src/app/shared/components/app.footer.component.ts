import { Component } from '@angular/core';
import { environment } from '../../../environments/environment';
const { version: version } = require('../../../../package.json')

@Component({
    selector: 'app-footer',
    templateUrl: './app.footer.component.html'
})

export class AppFooterComponent {
    public debugMode: boolean = environment.debugMode;
    public version: string = version;
}
