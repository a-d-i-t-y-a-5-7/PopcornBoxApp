import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { GalleryItem } from 'ng-gallery';
import { Media } from 'src/app/models/media';
import { MediaService } from 'src/app/services/media.service';
import { Section } from '../section-split/section';
import { FavouriteMediaServicesService } from 'src/app/services/favourite-media-services.service';
import { UserServiceService } from 'src/app/services/user-service.service';
import { IFavouriteMedia } from 'src/app/models/IFavouriteMedia';
import { Song } from 'src/app/models/song';
import { IFavouriteSong } from 'src/app/models/IFavouriteSong';
import { SongService } from 'src/app/services/song.service';
import { FavouriteSongService } from 'src/app/services/favourite-song.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  images!: GalleryItem[];
  public media: Media[] = [];
  fMedia : Media[] = [];
  favMedObj : IFavouriteMedia ={
    UserId:0,
    MediaId:0
  }

  mySong: Song[] = [];
  myFavSong: Song[] = [];
  favSong: IFavouriteSong = {
    UserId: 0,
    SongId: 0
  }

  userId : number = this.userService.GetUserId();

  constructor(private mediaService: MediaService, private router: Router, private favouriteMediaService:FavouriteMediaServicesService,private userService:UserServiceService,private songService : SongService, private favSongService : FavouriteSongService) { }

  ngOnInit() {
    this.GetMediaArray();
    this.getSong();
    this.GetMediaDetails();
    this.GetFavouriteSong();
  }

  imgCollection : Array<object> = [
    {
      image: `../../../assets/images/City on hills.jpg`,
      thumbImage: '../../../assets/images/City on hills.jpg',
      alt: 'City on hills',
      title: 'City on hills'
    }, {
      image: '../../../assets/images/Farzi.jpg',
      thumbImage: '../../../assets/images/Farzi.jpg',
      title: 'Farzi',
      alt: 'Farzi'
    }, {
      image: '../../../assets/images/imgc3.jpg',
      thumbImage: '../../../assets/images/imgc3.jpg',
      title: 'Avengers',
      alt: 'Avengers'
    }, {
      image: '../../../assets/images/KhudaGawah.jpg',
      thumbImage: '../../../assets/images/KhudaGawah.jpg',
      title: 'KhudaGawah',
      alt: 'KhudaGawah'
    }, {
      image: `../../../assets/images/The Family man.jpg`,
      thumbImage: '../../../assets/images/The Family man.jpg',
      alt: 'The Family Man',
      title: 'The Family Man'
    }, {
      image: '../../../assets/images/Squid Games.jpg',
      thumbImage: '../../../assets/images/Squid Games.jpg',
      title: 'Squid Games',
      alt: 'Squid Games'
    }, {
      image: '../../../assets/images/PaataalLok.jpg',
      thumbImage: '../../../assets/images/PaataalLok.jpg',
      title: 'Paataal Lok',
      alt: 'Paataal Lok'
    }, {
      image: '../../../assets/images/imgc4.jpg',
      thumbImage: '../../../assets/images/imgc4.jpg',
      title: 'Avengers 2',
      alt: 'Avengers 2'
    }, 
];

  GetMediaDetails(){
    this.mediaService.getMediaDetails().subscribe({
      next:(response =>{
        this.media = response;
      })
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

  PlaySong(id:number){
    this.router.navigate(['/media/song-player',id]);
  }

  GetFavouriteSong() {
    this.favSongService.GetFavouriteSong(this.userId).subscribe({
      next: (response => {
        this.myFavSong = response;
      })
    })
  }

  getSong() {
    this.songService.GetSong().
      subscribe(response => {
        this.mySong = response;
        console.log(response);
      })
  }

  IsFavouriteSong(id: number): boolean {
    for (const element of this.myFavSong) {
      if (element.songsId == id) {
        return true;
      }
    }
    return false;
  }

  deleteFavSong(id: number) {
    debugger
    this.favSong.SongId = id;
    this.favSong.UserId = this.userService.GetUserId();
    this.favSongService.RemoveFavourite(this.favSong).subscribe({
      next:(response => {
        this.ngOnInit();
      })
    })
  }
  AddFavSong(id: number) {
    debugger
    this.favSong.SongId = id;
    this.favSong.UserId = this.userService.GetUserId();
    this.favSongService.AddFavouriteSong(this.favSong).subscribe({
      next:(response => {
        this.ngOnInit();
      })
    })
  }
}

