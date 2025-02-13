import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/app/services/user-service.service';
import { GuidedTour, Orientation, GuidedTourModule, GuidedTourService } from 'ngx-guided-tour';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  constructor(public service: UserServiceService, private router: Router, private guidedTourService: GuidedTourService) {
    setTimeout(() => {
      this.guidedTourService.startTour(this.dashboardTour);
    }, 1000);
  }
  CheckLogIn: boolean = this.service.IsLoggedin();
  IsClient: boolean = this.service.IsClient();
  IsAdmin: boolean = this.service.IsAdmin();
  IsMenuOpen = false;

  Logout() {
    localStorage.removeItem('jwt');
    this.router.navigate(['login']);
  }
  public id: number = this.service.GetUserId();
  FavouriteMediaNavigate() {
    debugger
    console.log("id is " + this.id);
    this.router.navigate(['favouriteMedia']);
  }
  ProfileNavigate() {
    this.router.navigate(['profile']);
  }

  // ToggleMenu(): void {
  //   this.IsMenuOpen = !this.IsMenuOpen;
  // }

  public dashboardTour: GuidedTour = {
    tourId: 'experiment-tour',
    useOrb: false,
    steps: [
      {
        title: 'Welcome to the PopCorn Box App!',
        content: 'This tour will take you through the basic features availabale on this app.',
      },
      {
        title: 'Welcome to the PopCorn Box App!',
        selector: '#stepOne',
        content: 'Click here to go to our home page',
        orientation: Orientation.Bottom
      },
      {
        title: 'Movies Section',
        selector: '#stepTwo',
        content: 'Click here to go to our movies page',
        orientation: Orientation.Bottom
      },
      {
        title: 'TV Shows Section',
        selector: '#stepThree',
        content: 'Click here to go to our tv shows page',
        orientation: Orientation.Right
      },
      {
        title: 'Songs Section',
        selector: '#stepFour',
        content: 'Click here to go to our songs page',
        orientation: Orientation.Right
      },
      {
        title: 'Features Menu',
        selector: '#stepFive',
        content: 'Click here to go get access to additional features',
        orientation: Orientation.Left
      },
      {
        title: 'Content',
        selector: '#stepSix',
        content: 'Click here to watch any particular content by clicking on its image',
        orientation: Orientation.Right
      },
      {
        title: 'Favourites',
        selector: '#stepSeven',
        content: 'Click here to add any particular movie to your favourites by clicking on the heart icon',
        orientation: Orientation.Right
      },
      {
        title: 'Delete Favourites',
        selector: '#stepEight',
        content: 'Click here to delete any particular movie from your favourites by clicking on the heart icon',
        orientation: Orientation.Right
      },
      {
        title: 'Watch the movie',
        selector: '#stepNine',
        content: 'Click on the button to play or pause the video. ',
        orientation: Orientation.TopLeft
      },
      {
        title: 'Movies',
        selector: '#stepTen',
        content: 'Click here to watch any particular movie by clicking on its image',
        orientation: Orientation.Top
      },
      {
        title: 'Favourites',
        selector: '#stepEleven',
        content: 'Click here to add any particular movie to your favourites by clicking on the heart icon',
        orientation: Orientation.TopLeft
      },
      {
        title: 'Delete Favourites',
        selector: '#stepTwelve',
        content: 'Click here to delete any particular movie from your favourites by clicking on the heart icon',
        orientation: Orientation.TopLeft
      },
      {
        title: 'Search Feature',
        selector: '#stepThirteen',
        content: 'Using this search bar, you can search for whichever content you want to search',
        orientation: Orientation.Left
      },
      {
        title: 'Login',
        selector: '#stepFourteen',
        content: 'Have an already existing account? Login by entering your registered email here.',
        orientation: Orientation.Left
      },
      {
        title: 'Enter password',
        selector: '#stepFifteen',
        content: 'Enter your password here.',
        orientation: Orientation.Left
      },
      {
        title: 'Submit',
        selector: '#stepSixteen',
        content: 'Login by clicking on submit button',
        orientation: Orientation.Left
      },
      {
        title: 'Register',
        selector: '#stepSeventeen',
        content: 'Are you a new user? Click here to register yourself first.',
        orientation: Orientation.Left
      },
      {
        title: 'Register',
        selector: '#stepEighteen',
        content: 'Are you a new user? Register by entering your name here',
        orientation: Orientation.Left
      },
      {
        title: 'Email',
        selector: '#stepNineteen',
        content: 'Enter your email here.',
        orientation: Orientation.Left
      },
      {
        title: 'Password',
        selector: '#stepTwenty',
        content: 'Enter your password here.',
        orientation: Orientation.Left
      },
      {
        title: 'Confirm Password',
        selector: '#stepTwentyOne',
        content: 'Enter the same password that you have entered in the previous field.',
        orientation: Orientation.Left
      },
      {
        title: 'Contact',
        selector: '#stepTwentyTwo',
        content: 'Enter your contact number here.',
        orientation: Orientation.Left
      },
      {
        title: 'Role',
        selector: '#stepTwentyThree',
        content: 'Select your role from here. You can either be a user or a client.',
        orientation: Orientation.Left
      },
      {
        title: 'Submit',
        selector: '#stepTwentyFour',
        content: 'Register by clicking on submit button',
        orientation: Orientation.Left
      },
      {
        title: 'Login',
        selector: '#stepTwentyFive',
        content: 'Are you already a user? Click here to login.',
        orientation: Orientation.Left
      }
    ]
  };

  public onTourStart(): void {
    this.guidedTourService.startTour(this.dashboardTour);
  }
  
}
