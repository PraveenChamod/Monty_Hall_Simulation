import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SimulationService {
  private apiUrl = environment.API_URL;

  constructor(private http: HttpClient) {}

  startSimulation(
    simulationCount: number,
    switchStatus: boolean
  ): Observable<any> {
    const url = `${this.apiUrl}?simulationCount=${simulationCount}&switchStatus=${switchStatus}`;
    return this.http.get<any>(url, {});
  }
}
