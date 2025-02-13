import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Media } from '../media';
import { MediaService } from '../media.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  allMedia: Media[] = [];
  constructor(private mediaService: MediaService, private router: Router) { }
  ngOnInit(): void {
    this.get();
  }
  get() {
    this.mediaService.get().subscribe((data) => {
      this.allMedia = data;
    })
  }

}
