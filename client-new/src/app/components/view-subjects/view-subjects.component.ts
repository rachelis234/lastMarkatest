import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Category } from 'src/app/Models/Category';

@Component({
  selector: 'app-view-subjects',
  templateUrl: './view-subjects.component.html',
  styleUrls: ['./view-subjects.component.css']
})
export class ViewSubjectsComponent implements OnInit {

  constructor(private userService:UserService) { }

  ngOnInit() {
  }

}
