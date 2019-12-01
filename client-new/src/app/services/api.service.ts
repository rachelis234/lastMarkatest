import { Injectable, OnInit } from "@angular/core";
import { Sub_category } from "../Models/Sub_category";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Category } from "../Models/Category";
import { Class } from "../Models/Class";
import { Student } from "../Models/Student";
import { Test } from "../Models/Test";
import { Type } from "../Models/Type";
import { Question } from "../Models/Question";
import { SimpleTest } from "../Models/SimpleTest";
import { GeneratedTest } from "../Models/GeneratedTest";
import { Answer } from "../Models/Answer";

@Injectable({
  providedIn: "root"
})
export class ApiService implements OnInit {
  ngOnInit(): void {}
  subCategory: Sub_category = new Sub_category();
  studentsForClass: Student[];
  subCategoriesForCat: Sub_category[];
  types: Type[];
  questionsForSubCategory: Question[];
  constructor(
    private http: HttpClientModule,
    private httpService: HttpClient
  ) {}
  getTypes() {
    return this.httpService.get(environment.api + "/Type/getTypes");
  }
  addCategory(category: Category) {
    return this.httpService.post(
      environment.api + "/Category/addCategory",
      category
    );
  }
  addSubCategory(subCategory: Sub_category) {
    return this.httpService.post(
      environment.api + "/SubCategory/addSubCategory",
      subCategory
    );
  }
  addClass(cls: Class) {
    return this.httpService.post(environment.api + "/Class/addClass", cls);
  }
  download() {
    return this.httpService.get(environment.api + "/student/generate", {
      responseType: "blob"
    });
  }
  postFile(file: File, classId: number) {
    // const endpoint = 'environment.api';
    const formData: FormData = new FormData();
    formData.append("uploadFile", file, file.name);
    return this.httpService.post(
      environment.api + "/Student/addStudents?classId=" + classId,
      formData
    );
    // .map(() => { return true; })
    // .catch((e) => this.handleError(e));
  }
  addStudent(student: Student) {
    return this.httpService.post(
      environment.api + "/Student/addStudent",
      student
    );
  }
  getSubCategoriesForCat(categoryId: number) {
    return this.httpService.get(
      environment.api +
        "/SubCategory/getSubCategoriesForCategory?categoryId=" +
        categoryId
    );
  }
  createSimpleTest(test: SimpleTest) {
    return this.httpService.post(environment.api + "/Test/addTest", test);
  }
  createGeneratedTest(test: GeneratedTest) {
    return this.httpService.post(environment.api + "/Test/addTest", test);
  }
  forgotPassword(emailAddress: string) {
    return this.httpService.get(
      environment.api + "/User/forgotPassword?emailAddress=" + emailAddress
    );
  }
  getStudentsForClass(class_id: number) {
    return this.httpService.get(
      environment.api + "/Class/getStudentsForClass?classId=" + class_id
    );
  }
  deleteStudent(studentId: number) {
    return this.httpService.get(
      environment.api + "/Student/deleteStudent?studentId=" + studentId
    );
  }
  editStudent(student: Student) {
    return this.httpService.post(
      environment.api + "/Student/editStudent",
      student
    );
  }
  addQuestion(question: Question, answers: Answer[]) {
    const json = { ques: question, ans: answers };
    return this.httpService.post(
      environment.api + "/Question/addQuestion",
      json
    );
  }
}
