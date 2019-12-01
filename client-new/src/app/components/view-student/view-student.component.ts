import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ApiService } from "src/app/services/api.service";
import { Student } from "src/app/Models/Student";
import { Class } from "src/app/Models/Class";
import { UserService } from "src/app/services/user.service";
import { MatIconModule } from "@angular/material/icon"; // <----- Here

@Component({
  selector: "app-view-student",
  templateUrl: "./view-student.component.html",
  styleUrls: ["./view-student.component.css"]
})
export class ViewStudentComponent implements OnInit {
  student: Student;
  class: Class;
  constructor(
    private router: ActivatedRoute,
    private apiService: ApiService,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.router.params.subscribe(data => {
      this.student = this.apiService.studentsForClass.find(
        s => s.userId == +data["studentId"]
      );
    });
    this.class = this.userService.classesForTeacher.find(
      c => c.class_id == this.student.class_id
    );
  }
}
