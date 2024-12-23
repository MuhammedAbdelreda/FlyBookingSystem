import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Components/Header/header/header.component';
import { BodyComponent } from './Components/Body/body/body.component';
import { FooterComponent } from './Components/Footer/footer/footer.component';
import { FlightListComponent } from './Components/FlightSearch/flight-list/flight-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlightCategoriesComponent } from './Components/FlightSearch/flight-categories/flight-categories.component';
import { PersonalDetailsComponent } from './Components/FlightSearch/personal-details/personal-details.component';
import { ExtraServicesComponent } from './Components/FlightSearch/extra-services/extra-services.component';
import { OverViewComponent } from './Components/FlightSearch/over-view/over-view.component';
import { FlightConfirmationComponent } from './Components/FlightSearch/flight-confirmation/flight-confirmation.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BodyComponent,
    FooterComponent,
    FlightListComponent,
    FlightCategoriesComponent,
    PersonalDetailsComponent,
    ExtraServicesComponent,
    OverViewComponent,
    FlightConfirmationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
