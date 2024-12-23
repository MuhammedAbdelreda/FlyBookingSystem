import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoriesDto } from '../../../Components_SharedData/SharedFlightDetails';
import { FlightDataService } from '../Services/flight-data.service';

@Component({
  selector: 'app-flight-categories',
  templateUrl: './flight-categories.component.html',
  styleUrl: './flight-categories.component.scss'
})
export class FlightCategoriesComponent implements OnInit {
  categories:CategoriesDto[]=[];

  selectedCategory: any;
  
  constructor(private router: Router,private flightDataService: FlightDataService) {}

  selectCategory(category: any) {
    this.selectedCategory = category;
    this.router.navigate(['/personal-details'], { state: { selectedCategory: category } });
  }

  ngOnInit(): void {
    this.fetchCategories();
  }

  fetchCategories():void{
    this.flightDataService.getCategories().subscribe({
      next:(data:CategoriesDto[]) =>{
        this.categories = data;
        console.log(data);
      },
      error:(err) =>{
        console.log(err);
      }
    })
  }
}
