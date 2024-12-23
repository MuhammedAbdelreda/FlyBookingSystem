import { Component } from '@angular/core';
import { Router } from '@angular/router';

interface Category {
  name: string;
  seat: string;
  bag: string;
  flexibility: string;
  price: number;
}

interface PassengerDetails {
  name: string;
  email: string;
  phone: string;
  nationality: string;
  dob: string;
  gender: string;
}

interface ExtraServices {
  extraLargeBaggage?: boolean;
  priorityBoarding?: boolean;
}

interface NavigationState {
  selectedCategory?: Category;
  passengerDetails?: PassengerDetails;
  extraServices?: ExtraServices;
}

@Component({
  selector: 'app-extra-services',
  templateUrl: './extra-services.component.html',
  styleUrl: './extra-services.component.scss'
})
export class ExtraServicesComponent {

  selectedCategory: Category | null = null;
  passengerDetails: PassengerDetails | null = null;

  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    if (navigation?.extras.state) {
      const state = navigation.extras.state as NavigationState;
      this.selectedCategory = state.selectedCategory ??null;
      this.passengerDetails = state.passengerDetails ??null;
    }
  }

  continue() {
    this.router.navigate(['/overview'], { state: { selectedCategory: this.selectedCategory, passengerDetails: this.passengerDetails, extraServices: {} } });
  }

  addExtraLargeBaggage() {
    this.router.navigate(['/overview'], { state: { selectedCategory: this.selectedCategory, passengerDetails: this.passengerDetails, extraServices: { extraLargeBaggage: true } } });
  }

  addPriorityBoarding() {
    this.router.navigate(['/overview'], { state: { selectedCategory: this.selectedCategory, passengerDetails: this.passengerDetails, extraServices: { priorityBoarding: true } } });
  }
}
