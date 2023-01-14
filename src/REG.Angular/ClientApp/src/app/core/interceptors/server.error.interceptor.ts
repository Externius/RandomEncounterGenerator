import { Injectable } from '@angular/core';
import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { AlertDialogComponent } from '../alertdialog/alertdialog.component';

@Injectable()
export class ServerErrorInterceptor implements HttpInterceptor {
  constructor(private modalService: NgbModal, private translate: TranslateService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<any> {
    request = request.clone({
      withCredentials: true
    });

    return next.handle(request).pipe(
      catchError((err) => {
        if ([500].indexOf(err.status) !== -1 || [400].indexOf(err.status) !== -1) {
          const dialogRef = this.modalService.open(AlertDialogComponent);
          dialogRef.componentInstance.title = this.translate.instant('error.title');
          dialogRef.componentInstance.message = err.error.Message;
          dialogRef.componentInstance.stackTrace = err.error.StackTrace;
        } else {
          throw err;
        }
        return EMPTY;
      })
    );
  }
}
