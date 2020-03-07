import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RequestHttpOption } from './http.option';

@Injectable({ providedIn: 'root' })
export class EncounterService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient,
    private rho: RequestHttpOption,
    @Inject('API_URL') private apiUrl: string,
  ) {
  }

  public getMonsterTypes() {
    return this.httpClient.get<string[]>(this.apiUrl + '/Encounter/monstertypes', this.rho.httpOptions);
  }

  public getDifficulties() {
    return this.httpClient.get<string[]>(this.apiUrl + '/Encounter/difficulties', this.rho.httpOptions);
  }

  public generate(data: string) {
    return this.httpClient.post(`${this.apiUrl}/Encounter`, data, this.rho.httpOptions);
  }
}
