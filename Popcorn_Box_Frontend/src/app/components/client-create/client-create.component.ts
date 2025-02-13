import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClientMedia } from 'src/app/models/clientmedia';
import { HttpClient } from '@angular/common/http';
import { ClientServiceService } from 'src/app/services/client-service.service';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-client-create',
  templateUrl: './client-create.component.html',
  styleUrls: ['./client-create.component.css']
})
export class ClientCreateComponent implements OnInit {
  selectedFile: File | null = null;
  mediaForm: ClientMedia = {

    name: "",
    actors: "",
    directors: "",
    genreId: 0,
    year: "",
    mediaId: 0,
    clientId: this.userService.GetUserId(),
    thumbnail: "",
    trailer: "",
    fullLength: "",

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
            this.mediaForm.trailer = fileLocation.concat(this.fileResponse);
            this.mediaForm.fullLength = fileLocation.concat(this.fileResponse);
            console.log('fulllLength', this.mediaForm.fullLength);

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
            this.mediaForm.thumbnail = fileLocation.concat(this.fileResponse);

            console.log('thumbnail', this.mediaForm.thumbnail);

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
  MediaForm = this.formBuilder.group({
    name: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(40)]),

    actors: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(40)]),

    directors: new FormControl('', [Validators.required, Validators.minLength(5), Validators.maxLength(40)]),

    genreId: new FormControl('', [Validators.required]),

    year: new FormControl('', [Validators.required]),

    mediaId: new FormControl('', [Validators.required]),
    



  });

  get name(): FormControl {
    return this.MediaForm.get("name") as FormControl;
  }

  get actors(): FormControl {
    return this.MediaForm.get("actors") as FormControl;
  }

  get directors(): FormControl {
    return this.MediaForm.get("directors") as FormControl;
  }

  get genreId(): FormControl {
    return this.MediaForm.get("genreId") as FormControl;
  }

  get year(): FormControl {
    return this.MediaForm.get("year") as FormControl;
  }

  get mediaId(): FormControl {
    return this.MediaForm.get("mediaId") as FormControl;
  }

  



  ngOnInit(): void {

  }

  create() {
    console.log(this.mediaForm);

    this.clientService.post(this.mediaForm)
      .subscribe({
        next: (data) => {
          this.router.navigate(['my-media/' + this.mediaForm.clientId])
        }
      })
  }

}
