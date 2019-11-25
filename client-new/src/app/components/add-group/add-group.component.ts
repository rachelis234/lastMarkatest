import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Class } from 'src/app/Models/Class';
import { UserService } from 'src/app/services/user.service';
import { Teacher } from 'src/app/Models/Teacher';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-add-group',
  templateUrl: './add-group.component.html',
  styleUrls: ['./add-group.component.css']
})
export class AddGroupComponent implements OnInit {
  class:Class=new Class();
  constructor(private router:Router,private userService:UserService,private apiService:ApiService) {
    this.userService.getClassesForTeacher().subscribe(
      (res:Class[])=>this.userService.classesForTeacher=res,
      (err)=>console.log(err)
    );
   }

  ngOnInit() {
  }
  addClass(){
    this.class.teacher_id=(this.userService.user as Teacher).teacherId;
    this.apiService.addClass(this.class).subscribe(
      (res:Class)=>this.userService.classesForTeacher.push(res),
      (err)=>console.log(err)
    );
  }
}
