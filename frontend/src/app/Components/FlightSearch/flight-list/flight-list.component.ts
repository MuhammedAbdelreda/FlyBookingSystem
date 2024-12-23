import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FlightDataService } from '../Services/flight-data.service';
import { FlightDto } from '../../../Components_SharedData/SharedFlightDetails';


@Component({
  selector: 'app-flight-list',
  templateUrl: './flight-list.component.html',
  styleUrl: './flight-list.component.scss'
})
export class FlightListComponent implements OnInit {

  constructor(private router:Router,private flightDataService:FlightDataService){}

    flights: FlightDto[] = [];
    isLoading = true;
    errorMessage: string = ''; 

  selectedFlight: FlightDto | null = null;

  // selectFlight(flight: Flight) {
  //   this.selectedFlight = flight;
  // }

  // bookFlight(flight: Flight) {
  //   // Implement booking logic here
  //   //alert(`Booking flight from ${flight.from} to ${flight.to} at \$${flight.price}`);
  //   this.router.navigate(['/flight-categories'], { state: { selectedFlight: flight }
  //    });
  //   // You could redirect to a booking page or handle booking logic here
  // }
  
  // ngOnInit(): void {
  //   this.flightDataService.getFlights().subscribe(
  //     (data)=>{
  //       console.log(data);
  //       this.flights = data;
  //       this.isLoading = false;
  //     },
  //     (error)=>{
  //       console.error('Error fetching Data',error);
  //       this.isLoading = false;
  //     }
  //   )
  // }

  ngOnInit(): void {
    this.fetchFlights();
  }

  public fetchFlights():void{
    this.flightDataService.getFlights().subscribe({
      next:(data:FlightDto[])=>{
        this.flights = data;
        console.log(data);
      },
      error:(err) =>{
        console.log(err);
      }
    });
  }

  selectFlight(flight: FlightDto) {
    this.selectedFlight = flight;
    this.flightDataService.setSelectedFlight(flight);
  }

  bookFlight(flight: FlightDto) {
    this.selectFlight(flight);
    this.router.navigate(['/flight-categories']); // or any other route
  }

  searchTerm:any={};

  //parsing to maxduration
  parseDuration(duration: string): number {
    const hoursMatch = duration.match(/(\d+)h/);
    const minutesMatch = duration.match(/(\d+)m/);
    const hours = hoursMatch ? parseInt(hoursMatch[1], 10) : 0;
    const minutes = minutesMatch ? parseInt(minutesMatch[1], 10) : 0;
    return hours + minutes / 60; // Convert total duration to hours
  }

  filteredFlights() {
    return this.flights.filter(flight => {
      const matchesFrom = this.searchTerm.from ? flight.from.toLowerCase().includes(this.searchTerm.from.toLowerCase()) : true;
      const matchesTo = this.searchTerm.to ? flight.to.toLowerCase().includes(this.searchTerm.to.toLowerCase()) : true;
      const matchesDepartureDate = this.searchTerm.departureDate ? flight.date === this.searchTerm.departureDate : true;
      const matchesPrice = this.searchTerm.maxPrice ? flight.price <= this.searchTerm.maxPrice : true;
      const matchesDuration = this.searchTerm.maxDuration ? this.parseDuration(flight.duration) <= this.searchTerm.maxDuration : true;
  
      return matchesFrom && matchesTo && matchesDepartureDate && matchesPrice && matchesDuration;
    });
  }
  
  
}
