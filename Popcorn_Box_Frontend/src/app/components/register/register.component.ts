import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormControl, Validators } from '@angular/forms';
import { IUser } from 'src/app/models/IUser';
import { UserServiceService } from 'src/app/services/user-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  user: IUser = {
    UserId: 0,
    Name: "",
    Contact: "",
    Email: "",
    Password: "",
    ProfilePic: "",
    RoleId: -1,
    IsActive: false,
    IsSubscribed: false,
    IsApproved: 0
  }
  repeatPass = 'none';
  constructor(private formBuilder: FormBuilder, private service: UserServiceService, private router: Router) { }
  RegisterForm = this.formBuilder.group({
    Name: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(40), Validators.pattern('[a-zA-Z ]*')]),

    Contact: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(10), Validators.pattern('[0-9]*')]),

    Role: new FormControl('', [Validators.required]),

    Email: new FormControl('', [Validators.required, Validators.email]),

    Password: new FormControl('', [Validators.required, Validators.minLength(8)]),

    ConfirmPassword: new FormControl('', [Validators.required])

  });
  get Name(): FormControl {
    return this.RegisterForm.get("Name") as FormControl;
  }

  get Email(): FormControl {
    return this.RegisterForm.get("Email") as FormControl;
  }
  get Contact(): FormControl {
    return this.RegisterForm.get("Contact") as FormControl;
  }
  get Role(): FormControl {
    return this.RegisterForm.get("Role") as FormControl;
  }
  get Password(): FormControl {
    return this.RegisterForm.get("Password") as FormControl;
  }
  get ConfirmPassword(): FormControl {
    return this.RegisterForm.get('ConfirmPassword') as FormControl;
  }
  Register() {
    if (this.Password.value == this.ConfirmPassword.value) {
      this.repeatPass = 'none';
      this.service.Register(this.user).subscribe({
        next: (data: any) => {
          if (data === 'Email Already Exists') {
            alert('Email already exists pleas try with different email id');
          }
          else {
            this.router.navigate(['/login']);
          }
        },
        error: (e => {
          console.log(e);

        })
      })
    }
    else {
      this.repeatPass = 'inline';
    }
  }
}
