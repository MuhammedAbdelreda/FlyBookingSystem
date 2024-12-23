import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FlightDto } from '../../../Components_SharedData/SharedFlightDetails';

@Component({
  selector: 'app-flight-confirmation',
  templateUrl: './flight-confirmation.component.html',
  styleUrl: './flight-confirmation.component.scss'
})
export class FlightConfirmationComponent {
  
  selectedFlight:FlightDto | undefined;

  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    if(navigation?.extras.state){
      this.selectedFlight = navigation.extras.state['selectedFlight'] as FlightDto;
    }
  }
}
