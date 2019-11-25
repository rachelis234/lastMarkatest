import { Component, OnInit } from '@angular/core';
import { Sub_category } from 'src/app/Models/Sub_category';
import { UserService } from 'src/app/services/user.service';
import { Category } from 'src/app/Models/Category';
import { Teacher } from 'src/app/Models/Teacher';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-add-sub-theme',
  templateUrl: './add-sub-theme.component.html',
  styleUrls: ['./add-sub-theme.component.css']
})
export class AddSubThemeComponent implements OnInit {
  subTheme:Sub_category=new Sub_category()
  constructor(private userService:UserService,private apiService:ApiService) {
    this.getCategoriesForTeacher();
   }

  ngOnInit() {
  }
  getCategoriesForTeacher(){
    this.userService.getCategoriesForTeacher().subscribe(
      (res:Category[])=>this.userService.categoriesForTeacher=res,
      (err)=>console.log(err)
    );
  }
  addSubTheme(){
    this.apiService.addSubCategory(this.subTheme).subscribe(
      (res)=>console.log(res),
      (err)=>console.log(err)
    );
  }
}