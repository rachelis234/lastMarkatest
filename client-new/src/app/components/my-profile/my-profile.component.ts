import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/Models/User';
import { Teacher } from 'src/app/Models/Teacher';
import { Student } from 'src/app/Models/Student';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {

  user:any;
  constructor(private userService:UserService) { debugger
  }

  ngOnInit() {
    if(this.userService.user.status==1)
    {
      this.user=this.userService.user as Teacher;
    }
    else if(this.userService.user.status==2)
    {
      this.user=this.userService.user as Student;
    }
  }

}
