import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BodyComponent } from './Components/Body/body/body.component';
import { FlightListComponent } from './Components/FlightSearch/flight-list/flight-list.component';
import { FlightCategoriesComponent } from './Components/FlightSearch/flight-categories/flight-categories.component';
import { PersonalDetailsComponent } from './Components/FlightSearch/personal-details/personal-details.component';
import { ExtraServicesComponent } from './Components/FlightSearch/extra-services/extra-services.component';
import { OverViewComponent } from './Components/FlightSearch/over-view/over-view.component';
import { FlightConfirmationComponent } from './Components/FlightSearch/flight-confirmation/flight-confirmation.component';

const routes: Routes = [
  {path:'',redirectTo:'/body',pathMatch:'full'},
  {path:'body',component:BodyComponent},
  {path:'flight-list',component:FlightListComponent},
  {path:'flight-categories',component:FlightCategoriesComponent},
  {path:'personal-details',component:PersonalDetailsComponent},
  {path:'extra-services',component:ExtraServicesComponent},
  {path:'overview',component:OverViewComponent},
  {path:'confirm',component:FlightConfirmationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
