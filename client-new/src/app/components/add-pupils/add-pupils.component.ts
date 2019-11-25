import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { Student } from 'src/app/Models/Student';
import { UserService } from 'src/app/services/user.service';
import { Teacher } from 'src/app/Models/Teacher';
import { User } from 'src/app/Models/User';
import { Class } from 'src/app/Models/Class';
import { ActivatedRoute } from '@angular/router';
import { saveAs } from 'file-saver';
import { FormControl, Validators, FormGroupDirective, NgForm } from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-add-pupils',
  templateUrl: './add-pupils.component.html',
  styleUrls: ['./add-pupils.component.css']
})
export class AddPupilsComponent implements OnInit {
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  matcher = new MyErrorStateMatcher();
  fileToUpload:File=null;
  student:Student=new Student();
  classId:number;
  classControl = new FormControl('', [Validators.required]);
  selectFormControl = new FormControl('', Validators.required);
  constructor(private apiService:ApiService,private userService:UserService,private router:ActivatedRoute) {
    this.student.user=new User();
    this.router.params.subscribe(data => {
      this.classId = +data['classId'];
    });
    // userService.getClassesForTeacher().subscribe(
    //   (res:Class[])=>{userService.classesForTeacher=res,console.log(res)},
    //   (err)=>console.log(err)
    // );
   }

  ngOnInit() {
  //   $(document).ready(function () {
  //     $('.addBtn').on('click', function () {
  //         //var trID;
  //         //trID = $(this).closest('tr'); // table row ID 
  //         addTableRow();
  //     });
  //      $('.addBtnRemove').click(function () {
  //         $(this).closest('tr').remove();  
  //     })
  //     var i = 1;
  //     function addTableRow()
  //     {
  //         var tempTr = $('<tr><td><input type="text" id="userName_' + i + '" class="form-control"/></td><td><input type="text" id="email_' + i + '" class="form-control" /></td><td><input type="text" id="password_' + i + '" class="form-control" /></td><td><span class="glyphicon glyphicon-minus addBtnRemove" id="addBtn_' + i + '"></span></td></tr>').on('click', function () {
  //            $(this).closest('tr').remove(); 
  //            $(document.body).on('click', '.TreatmentHistoryRemove', function (e) {
  //                 $(this).closest('tr').remove();  
  //             });
  //         });
  //         $("#tableAddRow").append(tempTr)
  //         i++;
  //     }
  // });
  }
  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
}
uploadFileToActivity() {

  this.apiService.postFile(this.fileToUpload,this.classId).subscribe(res => {
    console.log(res);
    }, err => {
      console.log(err);
    });
}
addPupil(){
  this.student.user.status=2;
  this.student.userId=0;
  this.apiService.addStudent(this.student).subscribe(
    (res)=>console.log(res),
    (err)=>console.log(err)
  );
}
download(){
  this.apiService.download().subscribe((res)=>{
    saveAs(res,'file.xlsx');
    })
}
}
