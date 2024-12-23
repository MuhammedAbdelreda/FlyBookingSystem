import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FlightDataService } from '../Services/flight-data.service';
import { CategoriesDto, ExtraServices, FlightDto, NavigationState, PassengerDetails } from '../../../Components_SharedData/SharedFlightDetails';

@Component({
  selector: 'app-over-view',
  templateUrl: './over-view.component.html',
  styleUrls: ['./over-view.component.scss']
})
export class OverViewComponent implements OnInit {

  selectedFlight: FlightDto | null = null;
  selectedCategory: CategoriesDto | null = null;
  passengerDetails: PassengerDetails | null = null;
  extraServices: ExtraServices | null = null;

  constructor(private router: Router,private flightDataService:FlightDataService) {
    const navigation = this.router.getCurrentNavigation();
    if (navigation?.extras.state) {
      const state = navigation.extras.state as NavigationState;
      this.selectedFlight = state.selectedFlight ?? null;
      this.selectedCategory = state.selectedCategory ?? null;
      this.passengerDetails = state.passengerDetails ?? null;
      this.extraServices = state.extraServices ?? null;
    }
  }
  ngOnInit(): void {
    this.flightDataService.selectedFlight$.subscribe(flight => {
      this.selectedFlight = flight;
    });
  }

  confirmAndPay() {
    //this.router.navigate(['/confirm']); to navigate without sending data
    this.router.navigate(['/confirm'], { state: { selectedFlight: this.selectedFlight } });
    console.log("Payment confirmed!");
    // You could navigate to a payment page or perform an API call here
  }
  
}
