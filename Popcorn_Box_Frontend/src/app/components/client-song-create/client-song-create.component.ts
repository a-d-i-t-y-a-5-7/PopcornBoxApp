import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClientSong } from 'src/app/models/clientSong';
import { ClientServiceService } from 'src/app/services/client-service.service';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-client-song-create',
  templateUrl: './client-song-create.component.html',
  styleUrls: ['./client-song-create.component.css']
})
export class ClientSongCreateComponent implements OnInit {
  selectedFile: File | null = null;

  songForm: ClientSong = {

    name:"",
    singers:"",
    composer:"",
    lyrics:"",
    year:"",
    genreId:0,
    clientId:this.userService.GetUserId(),
    thumbnail:"",
    songUrl:""

  };

  repeatPass: string = 'none';

  constructor(private formBuilder: FormBuilder, private clientService: ClientServiceService,
    private router: Router, private http: HttpClient, private userService: UserServiceService) { }

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
  
    

  ngOnInit(): void {
    
  }

  create() {
    console.log(this.songForm);

    this.clientService.postSongs(this.songForm)
      .subscribe({
        next: (data) => {
          this.router.navigate(['my-song/' + this.songForm.clientId])
        }
      })
  }

}
