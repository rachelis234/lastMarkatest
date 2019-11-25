import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { UserService } from 'src/app/services/user.service';
import { Test } from 'src/app/Models/Test';

@Component({
  selector: 'app-view-tests',
  templateUrl: './view-tests.component.html',
  styleUrls: ['./view-tests.component.css']
})
export class ViewTestsComponent implements OnInit {

  constructor( private apiService:ApiService,private userService:UserService) {
    this.userService.getTestsForTeacher().subscribe(
      (res:Test[])=>this.userService.testsForTeacher=res,
      (err)=>console.log(err)
    );
   }

  ngOnInit() {
  }

}
