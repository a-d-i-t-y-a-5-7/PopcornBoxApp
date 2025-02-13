import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Media } from 'src/app/media/media';
import { ClientServiceService } from 'src/app/services/client-service.service';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-client-edit',
  templateUrl: './client-edit.component.html',
  styleUrls: ['./client-edit.component.css']
})
export class ClientEditComponent implements OnInit {
  mediaForm: Media = {
    id: 0,
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

  allClients: Media[] = [];

  constructor(private route: ActivatedRoute, private formBuilder:FormBuilder,private clientService:ClientServiceService,
    private router:Router, private http:HttpClient, private userService: UserServiceService){}

    MediaForm = this.formBuilder.group({
      name:new FormControl('',[Validators.required,Validators.minLength(3),Validators.maxLength(40)]),
  
      actors:new FormControl('',[Validators.required,Validators.minLength(5),Validators.maxLength(40)]),
  
      directors:new FormControl('',[Validators.required,Validators.minLength(5),Validators.maxLength(40)]),
  
      genreId:new FormControl('',[Validators.required]),
  
      year:new FormControl('',[Validators.required]),
  
      mediaId:new FormControl('',[Validators.required])
      
      
  
    });

    get name():FormControl{
      return this.MediaForm.get("name") as FormControl;
    }

    get actors():FormControl{
      return this.MediaForm.get("actors") as FormControl;
    }

    get directors():FormControl{
      return this.MediaForm.get("directors") as FormControl;
    }

    get genreId():FormControl{
      return this.MediaForm.get("genreId") as FormControl;
    }

    get year():FormControl{
      return this.MediaForm.get("year") as FormControl;
    }

    get mediaId():FormControl{
      return this.MediaForm.get("mediaId") as FormControl;
    }

    


    getMediaFromServices():void{
      this.clientService.get(this.mediaForm.clientId).subscribe(
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
    this.clientService.getById(id).subscribe((data) => {
      this.mediaForm = data;
    });
  }

  update() {
    this.clientService.update(this.mediaForm)
      .subscribe({
        next: () => {
          this.router.navigate(['my-media/' + this.mediaForm.clientId]);
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

}
