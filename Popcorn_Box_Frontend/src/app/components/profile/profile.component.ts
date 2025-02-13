import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IUser } from 'src/app/models/IUser';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  repeatPass = 'none'
  responseData: any;
  user:IUser ={
    UserId:0,
    Name:'',
    Email:'',
    Contact:'',
    Password:'',
    ProfilePic:'',
    RoleId:0,
    IsActive : false,
    IsSubscribed: false,
    IsApproved:0
  }
  constructor(private service: UserServiceService,private formBuilder: FormBuilder,private route : ActivatedRoute, private router:Router) { }
  ngOnInit(): void {
    let id:number=0;
    this.route.paramMap.subscribe((param) => {
      id = this.service.GetUserId();
    })
    this.GetUser(id);
  }
  GetUser(id:number){
    this.service.GetUserById(id).subscribe({
      next:(response:any)=>{
        this.user.UserId = response.userId;
        this.user.Name = response.name;
        this.user.Email = response.email;
        this.user.Contact = response.contact;
        this.user.Password = response.password;
        this.user.ProfilePic = response.profilePic;
        this.user.RoleId = response.roleId;
        this.user.IsActive = response.isActive;
        this.user.IsSubscribed = response.isSubscribed;
        this.user.IsApproved = response.isApproved;
      }
    }
    )
  }
  UpdateForm = this.formBuilder.group({
    Name: new FormControl(this.user.Name, [Validators.required, Validators.minLength(3), Validators.maxLength(40), Validators.pattern('[a-zA-Z ]*')]),

    Contact: new FormControl(this.user.Contact, [Validators.required, Validators.minLength(10), Validators.maxLength(10), Validators.pattern('[0-9]*')]),

    Role: new FormControl(this.user.RoleId, [Validators.required]),

    Email: new FormControl(this.user.Email, [Validators.required, Validators.email]),

    Password: new FormControl(this.user.Password, [Validators.required, Validators.minLength(8)]),
  })
  get Name(): FormControl {
    return this.UpdateForm.get("Name") as FormControl;
  }

  get Email(): FormControl {
    return this.UpdateForm.get("Email") as FormControl;
  }
  get Contact(): FormControl {
    return this.UpdateForm.get("Contact") as FormControl;
  }
  get Role(): FormControl {
    return this.UpdateForm.get("Role") as FormControl;
  }
  get Password(): FormControl {
    return this.UpdateForm.get("Password") as FormControl;
  }
  UpdateUser(){
    if(this.Password.value){
      this.repeatPass = 'none';
      this.service.UpdateUser(this.service.GetUserId(),this.user).subscribe({
        next:(response =>{
          console.log(response);
          localStorage.removeItem('jwt');
          alert('Please Login again');
          this.router.navigate(['/login']);
        })
      })
    }
  }
}
