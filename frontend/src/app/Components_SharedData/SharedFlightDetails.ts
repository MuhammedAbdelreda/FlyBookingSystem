export interface FlightDto {
  id: number;
  date: string;
  departureTime: string;
  arrivalTime: string;
  duration: string;
  from: string;
  to: string;
  price: number;
}


  export interface CategoriesDto {
    id:number;
    name: string;
    seat: string;
    bag: string;
    flexibility: string;
    price: number;
  }
  
  export interface PassengerDetails {
    name: string;
    email: string;
    phone: string;
    nationality: string;
    dob: string;
    gender: string;
  }
  
  export interface ExtraServices {
    extraLargeBaggage?: boolean;
    priorityBoarding?: boolean;
  }
  
  export interface NavigationState {
    selectedFlight?:FlightDto;
    selectedCategory?: CategoriesDto;
    passengerDetails?: PassengerDetails;
    extraServices?: ExtraServices;
  }