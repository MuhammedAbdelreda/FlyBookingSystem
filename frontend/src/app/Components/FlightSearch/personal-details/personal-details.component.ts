import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-personal-details',
  templateUrl: './personal-details.component.html',
  styleUrl: './personal-details.component.scss'
})
export class PersonalDetailsComponent implements OnInit {
  passengerForm!:FormGroup;

  constructor(private fb: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.passengerForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
      nationality: ['', Validators.required],
      dob: ['', Validators.required],
      gender: ['', Validators.required]
    });
  }

  // onSubmit(): void {
  //   if (this.passengerForm.valid) {
  //     const requestBody = this.passengerForm.value;
  //     console.log('Form is valid, navigating to extra-services',requestBody);
  //     this.router.navigate(['/extra-services']);
  //   } else {
  //     console.log('Form is invalid');
  //   }
  // }

  onSubmit(): void {
    if (this.passengerForm.valid) {
      const requestBody = this.passengerForm.value;
      const selectedCategory = history.state.selectedCategory; // Get the category from state
      this.router.navigate(['/extra-services'], { state: { selectedCategory, passengerDetails: requestBody } });
    } else {
      console.log('Form is invalid');
    }
  }
  
}
