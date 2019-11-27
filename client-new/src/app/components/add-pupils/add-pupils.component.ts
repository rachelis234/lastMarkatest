import { Component, OnInit } from "@angular/core";
import { ApiService } from "src/app/services/api.service";
import { Student } from "src/app/Models/Student";
import { UserService } from "src/app/services/user.service";
import { Teacher } from "src/app/Models/Teacher";
import { User } from "src/app/Models/User";
import { Class } from "src/app/Models/Class";
import { ActivatedRoute } from "@angular/router";
import { saveAs } from "file-saver";
import Swal from "sweetalert2";
import "sweetalert2/src/sweetalert2.scss";

import {
  FormControl,
  Validators,
  FormGroupDirective,
  NgForm,
  FormGroup,
  FormBuilder
} from "@angular/forms";
import { ErrorStateMatcher } from "@angular/material/core";
import { MatButtonModule } from "@angular/material/button";

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(
    control: FormControl | null,
    form: FormGroupDirective | NgForm | null
  ): boolean {
    const isSubmitted = form && form.submitted;
    return !!(
      control &&
      control.invalid &&
      (control.dirty || control.touched || isSubmitted)
    );
  }
}

@Component({
  selector: "app-add-pupils",
  templateUrl: "./add-pupils.component.html",
  styleUrls: ["./add-pupils.component.css"]
})
export class AddPupilsComponent implements OnInit {
  myForm: FormGroup;
  emailFormControl = new FormControl("", [
    Validators.required,
    Validators.pattern("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$"),
    Validators.email
  ]);

  matcher = new MyErrorStateMatcher();
  fileToUpload: File = null;
  student: Student = new Student();
  classId: number;
  nameControl = new FormControl("", Validators.required);
  passwordControl = new FormControl("", [
    Validators.required,
    Validators.pattern("^[0-9]")
  ]);
  identityControl = new FormControl("", [
    Validators.required,
    Validators.maxLength(9)
  ]);
  //classControl = new FormControl("", [Validators.required]);
  //selectFormControl = new FormControl("", Validators.required);
  constructor(
    private apiService: ApiService,
    private userService: UserService,
    private router: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.student.user = new User();
    this.router.params.subscribe(data => {
      this.classId = +data["classId"];
    });
    // userService.getClassesForTeacher().subscribe(
    //   (res:Class[])=>{userService.classesForTeacher=res,console.log(res)},
    //   (err)=>console.log(err)
    // );
  }

  ngOnInit() {
    this.myForm = this.fb.group({
      nameControl: this.nameControl,
      emailFormControl: this.emailFormControl,
      passwordControl: this.passwordControl,
      identityControl: this.identityControl
    });
  }
  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
  }
  uploadFileToActivity() {
    this.apiService.postFile(this.fileToUpload, this.classId).subscribe(
      res => {
        console.log(res);
      },
      err => {
        console.log(err);
      }
    );
  }
  addPupil() {
    this.student.user.status = 2;
    this.student.userId = 0;
    this.student.class_id = this.classId;
    this.apiService.addStudent(this.student).subscribe(
      res => {
        console.log(res);
        Swal.fire({
          type: "success",
          title: "התלמיד נוסף בהצלחה",
          showConfirmButton: false,
          timer: 1500
        });
      },
      err => console.log(err)
    );
  }
  download() {
    this.apiService.download().subscribe(res => {
      saveAs(res, "file.xlsx");
    });
  }
}
