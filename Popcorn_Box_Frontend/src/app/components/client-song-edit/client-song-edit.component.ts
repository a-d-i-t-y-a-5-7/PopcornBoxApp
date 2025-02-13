import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Song } from 'src/app/models/song';
import { ClientServiceService } from 'src/app/services/client-service.service';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-client-song-edit',
  templateUrl: './client-song-edit.component.html',
  styleUrls: ['./client-song-edit.component.css']
})
export class ClientSongEditComponent implements OnInit{
  songForm: Song = {
    songsId:0,
    name:"",
    singers:"",
    composer:"",
    lyrics:"",
    year:0,
    genreId:0,
    clientId:this.userService.GetUserId(),
    thumbnail:"",
    songUrl:""

  };

  allClients: Song[] = [];

  constructor(private route: ActivatedRoute, private formBuilder:FormBuilder,private clientService:ClientServiceService,
    private router:Router, private http:HttpClient, private userService: UserServiceService){}

    SongForm = this.formBuilder.group({
      name: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(40)]),
  
      singers: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(40)]),
  
      composer: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(40)]),
  
      lyrics: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(500)]),
  
      year: new FormControl('', [Validators.required]),
  
      genreId: new FormControl('', [Validators.required]),      

  
  
    });

    get name(): FormControl {
      return this.SongForm.get("name") as FormControl;
    }
  
    get singers(): FormControl {
      return this.SongForm.get("singers") as FormControl;
    }
  
    get composer(): FormControl {
      return this.SongForm.get("composer") as FormControl;
    }
  
    get lyrics(): FormControl {
      return this.SongForm.get("lyrics") as FormControl;
    }
  
    get year(): FormControl {
      return this.SongForm.get("year") as FormControl;
    }
  
    get genreId(): FormControl {
      return this.SongForm.get("genreId") as FormControl;
    }
  
    

    getSongFromServices():void{
      this.clientService.getSongs(this.songForm.clientId).subscribe(
        (data)=>{
          this.allClients=data;
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

  getById(id: number) {
    this.clientService.getSongById(id).subscribe((data) => {
      this.songForm = data;
    });
  }

  update() {
    this.clientService.updateSong(this.songForm)
      .subscribe({
        next: () => {
          this.router.navigate(['my-song/' + this.songForm.clientId]);
        },
        error: (err) => {
          console.log(err);
        }
      })
  }

  selectedFile: File | null = null;

  repeatPass: string = 'none';

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  fileResponse: string = "";

  uploadFile() {
    if (this.selectedFile) {
      if (this.selectedFile.size < 52428800) {
        const formData = new FormData();
        formData.append('file', this.selectedFile);

        this.http.post<string>('https://localhost:7059/api/Videos/upload', formData).subscribe(
          response => {
            console.log('File uploaded successfully!', response);
            this.fileResponse = response;
            const fileLocation = "../../../assets/videos/";
            this.songForm.songUrl = fileLocation.concat(this.fileResponse);
            
            console.log('fulllLength', this.songForm.songUrl);

          },
          error => {
            console.error('An error occured while uploading the file:', error);
          }
        );
      }
      else {
        alert("File is too big!");

      }
    }
  }

  uploadImage() {
    if (this.selectedFile) {
      if (this.selectedFile.size < 52428800) {
        const formData = new FormData();
        formData.append('file', this.selectedFile);

        this.http.post<string>('https://localhost:7059/api/Videos/uploadimage', formData).subscribe(
          response => {
            console.log('File uploaded successfully!', response);
            this.fileResponse = response;
            let fileLocation = "../../../assets/images/";
            this.songForm.thumbnail = fileLocation.concat(this.fileResponse);

            console.log('thumbnail', this.songForm.thumbnail);

          },
          error => {
            console.error('An error occured while uploading the file:', error);
          }
        );
      }
      else {
        alert("File is too big!");

      }
    }
  }

}
