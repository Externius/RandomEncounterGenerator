import {Pipe, PipeTransform} from '@angular/core';

@Pipe({standalone: false, name: 'savingThrow'})
export class SavingThrowPipe implements PipeTransform {
  transform(value: number, ability: number): string {
    if (value > 0) {
      return '+' + value;
    }
    const result = -5 + Math.floor(ability / 2);
    if (result > 0) {
      return '+' + result;
    } else if (result === 0) {
      return ' ' + result;
    }
    return result.toString();
  }
}
