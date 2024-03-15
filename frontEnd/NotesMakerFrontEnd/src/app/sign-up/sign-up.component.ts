import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [RouterLink,RouterLinkActive,FormsModule],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent implements OnInit{

  ngOnInit(): void {
  }
  email: string='';
  Password: string = '';
  name: string = '';

  validateForm(): void{
    console.log(this.email);
    console.log(this.name);
    console.log(this.Password);
  }


}
