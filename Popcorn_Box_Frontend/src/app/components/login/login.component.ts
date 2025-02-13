import { Component, ɵsetAlternateWeakRefImpl } from '@angular/core';
import{ FormBuilder} from '@angular/forms';
import { FormControl, Validators } from '@angular/forms';
import{ UserServiceService } from 'src/app/services/user-service.service';
import{ Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  LogEmail = "";
  LogPassword = "";

  constructor(private formBuilder: FormBuilder, private service: UserServiceService, private router: Router) { }
  LoginForm = this.formBuilder.group({
    Email: new FormControl('', [Validators.required, Validators.email]),

    Password: new FormControl('', [Validators.required, Validators.minLength(8)]),
  });
  get Email(): FormControl {
    return this.LoginForm.get("Email") as FormControl;
  }
  get Password(): FormControl {
    return this.LoginForm.get("Password") as FormControl;
  }
  Login() {
    this.service.Login(this.LogEmail, this.LogPassword).subscribe({
      next: (data => {
        if (data === "Please try after sometime your Account is not approved yet") {
          alert('Please try after sometime your Account is not approved yet');
          this.router.navigate(['/login']);
        }
        else if(data === "User not found"){
          alert('Login Failed');
          this.router.navigate(['/login']);
        }
        else {
          localStorage.setItem("jwt",data.toString());  
          this.router.navigate(['/home']);
        }
        console.log();
      }),
      error: console.log
    });
  }
}
