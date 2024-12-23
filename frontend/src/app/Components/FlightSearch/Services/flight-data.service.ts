import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CategoriesDto, FlightDto } from '../../../Components_SharedData/SharedFlightDetails';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FlightDataService {
  private apiUrl = 'https://localhost:44367/api/app';
  private selectedFlightSubject = new BehaviorSubject<FlightDto | null>(null);
  selectedFlight$ = this.selectedFlightSubject.asObservable();

  constructor(private http:HttpClient){}

  setSelectedFlight(flight: FlightDto) {
    this.selectedFlightSubject.next(flight);
  }

  getFlights():Observable<FlightDto[]>{
    return this.http.get<FlightDto[]>(`${this.apiUrl}/flight`);
  }

  getCategories():Observable<CategoriesDto[]>{
    return this.http.get<CategoriesDto[]>(`${this.apiUrl}/categories`)
  }
}
