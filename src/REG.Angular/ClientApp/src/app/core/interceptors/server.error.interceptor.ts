import { Injectable, inject, Injector } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable, EMPTY, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertDialogComponent } from '../alertdialog/alertdialog.component';
import { TranslateService } from '@ngx-translate/core';
import { PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

@Injectable()
export class ServerErrorInterceptor implements HttpInterceptor {
  private readonly modalService = inject(NgbModal);
  private readonly injector = inject(Injector);
  private readonly platformId = inject(PLATFORM_ID);

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const request = req.clone({ withCredentials: true });
    return next.handle(request).pipe(
      catchError(err => {
        const isBrowser = isPlatformBrowser(this.platformId);
        if (isBrowser && (err.status === 400 || err.status === 500)) {
          const translate = this.injector.get(TranslateService);
          const dialogRef = this.modalService.open(AlertDialogComponent);
          dialogRef.componentInstance.title = translate.instant('error.title');
          dialogRef.componentInstance.message = err.error?.Message;
          dialogRef.componentInstance.stackTrace = err.error?.StackTrace;
          return EMPTY;
        }
        return throwError(() => err);
      })
    );
  }
}
