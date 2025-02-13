import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Song } from 'src/app/models/song';
import { MediaService } from '../media.service';

@Component({
  selector: 'app-song-player',
  templateUrl: './song-player.component.html',
  styleUrls: ['./song-player.component.css']
})
export class SongPlayerComponent implements OnInit{
  allSongs: Song[] = [];

  constructor(
    private route: ActivatedRoute,
    private router:Router,
    private mediaService: MediaService
  ) {}

  getMediaFromServices():void{
    this.mediaService.get().subscribe(
      (data)=>{
        this.allSongs=data;
        console.log(data);
      }
    )
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      const id = Number(param.get('id'));
      this.getSongById(id);
    });
  }

  songForm:Song={
    songsId:0,
    name:"",
    singers:"",
    composer:"",
    lyrics:"",
    year:0,
    genreId:0,
    clientId:0,
    thumbnail:"",
    songUrl:""
    
  };

  getSongById(id: number){
    this.mediaService.getSongById(id).subscribe((data)=>{
      this.songForm = data;
    })
  }
}
