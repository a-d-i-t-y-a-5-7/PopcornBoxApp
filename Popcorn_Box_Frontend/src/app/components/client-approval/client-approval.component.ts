import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-client-approval',
  templateUrl: './client-approval.component.html',
  styleUrls: ['./client-approval.component.css']
})
export class ClientApprovalComponent implements OnInit{

  
  displayedColumns = ['name','email','contact','isApproved','isActive'];
  dataSource!:MatTableDataSource<any>;
  @ViewChild('paginator') paginator! : MatPaginator;
  @ViewChild(MatSort) matSort! : MatSort;
  constructor(private service: AdminService, private router:Router){}

  ngOnInit(){
    this.getUser(3);
  }

  getUser(id: number) {
    this.service.getUser(id).subscribe(
      response => {
        console.log(response);
        this.dataSource = new MatTableDataSource(response);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.matSort;
      })
  }

  delete(id:number){
    this.service.deleteUser(id)
    .subscribe({
      next:() => {
        this.ngOnInit();
        this.getUser(3);
      },
      error:(err) => {
        console.log(err);
      }
    })
  }

  approveClient(id:number){
    this.service.approveClient(id)
    .subscribe({
      next:() => {
        this.ngOnInit()
      },
      error:(err) => {
        console.log(err);
      }
    })
  }

  filterData($event : any){
    this.dataSource.filter = $event.target.value;
  }
}