import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Media } from '../media';
import { MediaService } from '../media.service';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  allMedia: Media[] = [];
  constructor(
    private route: ActivatedRoute,
    private router:Router,
    private mediaService: MediaService
  ) {}
  getMediaFromServices():void{
    this.mediaService.get().subscribe(
      (data)=>{
        this.allMedia=data;
        console.log(data);
      }
    )
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      const id = Number(param.get('id'));
      this.getById(id);
    });
  }
  mediaForm:Media={
    id:0,
    name:"",
    actors:"",
    directors:"",
    genreId:0,
    year:"",
    mediaId:0,
    clientId:0,
    thumbnail:"",
    trailer:"",
    fullLength:"",
    
  };
  getById(id: number){
    this.mediaService.getById(id).subscribe((data)=>{
      this.mediaForm = data;
    })
  }
}
