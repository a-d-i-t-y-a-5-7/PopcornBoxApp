import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IFavouriteMedia } from 'src/app/models/IFavouriteMedia';
import { Media } from 'src/app/models/media';
import { FavouriteMediaServicesService } from 'src/app/services/favourite-media-services.service';
import { MediaService } from 'src/app/services/media.service';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-tvshows',
  templateUrl: './tvshows.component.html',
  styleUrls: ['./tvshows.component.css']
})
export class TvshowsComponent implements OnInit {

  constructor(private mediaService: MediaService, private router: Router,private favouriteMediaService :FavouriteMediaServicesService, private userService :UserServiceService) { }
  myMedia: Media[] | any[] = [];
  userId : number = this.userService.GetUserId();
  fMedia : Media[] = [];
  favMedObj : IFavouriteMedia  ={
    UserId : 0,
    MediaId : 0
  } 
  ngOnInit(): void {
    this.getMedia(1);
    this.GetMediaArray();
  }

  getMedia(id: number) {
    this.mediaService.getMedia(id).
      subscribe(response => {
        this.myMedia = response;
        console.log(response);
      })
  }

  GetMediaArray(){
    this.favouriteMediaService.GetFavouriteMedia(this.userId).subscribe({
      next:(response => {
        this.fMedia = response;
      })
    })
    console.log(this.fMedia+" FMedia");
    return this.fMedia;
  }

  IsFavouriteMedia(id:number) : boolean{
    for(const element of this.fMedia){
      if(element.id==id){
        return true;
      }
    }
    return false;
  }
  deleteFavourite(id:number){
    this.favMedObj.MediaId = id;
    this.favMedObj.UserId = this.userId;
    this.favouriteMediaService.RemoveFavourites(this.favMedObj).subscribe({
      next:(resposne=>{
        console.log(resposne);
        this.ngOnInit();
      })
    });
  }
  addFavourite(id:number){
    this.favMedObj.MediaId = id;
    this.favMedObj.UserId = this.userId;
    this.favouriteMediaService.AddFavouriteMedia(this.favMedObj).subscribe({
      next:(resposne=>{
        console.log(resposne);
        this.ngOnInit();
      })
    });
  }
  searchText : string = '';

  onSearchTextEntered(searchValue:string){
    this.searchText = searchValue;
    console.log(this.searchText);
    
  }
  PlayMedia(id:number){
    this.router.navigate(['/media/player',id]);
  }
}
