import { Component, OnInit } from '@angular/core';
import { Test } from 'src/app/Models/Test';
import { UserService } from 'src/app/services/user.service';
import { ApiService } from 'src/app/services/api.service';
import { Class } from 'src/app/Models/Class';
import { SimpleTest } from 'src/app/Models/SimpleTest';
import { GeneratedTest } from 'src/app/Models/GeneratedTest';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { Category } from 'src/app/Models/Category';
import { WebResult } from 'src/app/Models/WebResult';
import { Sub_category } from 'src/app/Models/Sub_category';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { Question } from 'src/app/Models/Question';


@Component({
  selector: 'app-create-test',
  templateUrl: './create-test.component.html',
  styleUrls: ['./create-test.component.css']
})
export class CreateTestComponent implements OnInit {

  classes = new FormControl();

  questions = new FormControl();
  subCategories = new FormControl();
  //toppingList: string[] = ;
  test: Test = new Test;
  simpleTest: SimpleTest = null;
  generatedTest: GeneratedTest = null;
  generate: string ;
  myControl = new FormControl();
  options: Category[];
  filteredOptions: Observable<Category[]>;
  selectCategory: boolean = false;
  // selectSubCat: boolean;
  // afterSelectSubCat:boolean;
  displayedColumns: string[] = [ 'name', 'questions'];
  dataSource = new MatTableDataSource<Sub_category>(this.apiService.subCategoriesForCat);
  selection = new SelectionModel<Sub_category>(true, []);
  allSelectedQuestions: Question[];
  constructor(private userService: UserService, private apiService: ApiService) {
  }

  ngOnInit() {
    this.userService.getClassesForTeacher().subscribe(
      (res: Class[]) => {
        this.userService.classesForTeacher = res;
      },
      (err) => console.log(err)
    );
    this.userService.getTestsForTeacher().subscribe(
      (res: WebResult) => {
        if (res.status == true) { this.userService.testsForTeacher = res.value as Test[] } else console.log(res.message)
      },
      (err) => console.log(err)
    );
    this.userService.getCategoriesForTeacher().subscribe(
      (res: WebResult) => {
        if (res.status == true) {
          this.userService.categoriesForTeacher = res.value as Category[];
          this.options = this.userService.categoriesForTeacher; 
          this.filteredOptions = this.myControl.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filter(value))
      );
        }
      },
      (err) => console.log(err)
    );
    this.filteredOptions = this.myControl.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filter(value))
      );

  }
  createTest() {

    if (this.generate == 'true') {
      this.generatedTest.classes = this.classes.value;
      this.generatedTest.subCategories=this.subCategories.value;
      debugger
      this.apiService.createGeneratedTest(this.generatedTest).subscribe(
        (res: Test) => {
          this.userService.testsForTeacher.push(res);
          console.log(res)
        },
        (err) => console.log(err)
      );
    }
    else {
      this.simpleTest.classes = this.classes.value;
      
    //  this.simpleTest.questions = this.questions.value;
      this.apiService.createSimpleTest(this.simpleTest).subscribe(
        (res: Test) => {
          this.userService.testsForTeacher.push(res);
          console.log(res)
        },
        (err) => console.log(err)
      );
    }
  }
  onSelectionChange() {
    if (this.generate == 'true') {
      this.generatedTest = new GeneratedTest();
      this.generatedTest.test = this.test;
    }
    else {
      this.simpleTest = new SimpleTest();
      this.simpleTest.test = this.test;
    }
  }
  onSelect(cat: Category) {
    this.selectCategory = true;
    this.apiService.getSubCategoriesForCat(cat.category_id).subscribe(
      (res: WebResult) => {
        if (res.status == true) {
          this.apiService.subCategoriesForCat = res.value as Sub_category[];
          this.dataSource = new MatTableDataSource<Sub_category>(this.apiService.subCategoriesForCat);
          this.userService.getQuestionsForTeacher().subscribe(
            (res: WebResult) => {
              if (res.status == true) {
                var c: any;
                // for (c in this.apiService.subCategoriesForCat) {
                //   this.userService.questionsForTeacher.push((res.value as Question[]).filter(q => q.sub_category_id == c.sub_category_id));
                // }
                // @ts-ignore
                res['value'].forEach(v=>{
                  if(this.apiService.subCategoriesForCat.find(c=>c.sub_category_id==v.sub_category_id))
                this.userService.questionsForTeacher.push(v);
                });
                //this.userService.questionsForTeacher=res.value as Question[];
                console.log(this.userService.questionsForTeacher);
              }
            },
            (err) => console.log(err)
          );
        }
        else console.log(res.message);
      },
      (err) => console.log(err)
    );
  }
  onchangeInput() {
    this.selectCategory = false;

  }
  // changeStatus() {
  //   this.selectSubCat = true;
  // }
  // afterSelect(){
  //   debugger
  //   console.log(this.selectSubCat);
  //   console.log(this.afterSelectSubCat);
  //   if(this.selectSubCat==true){
  //     this.afterSelectSubCat=true;
  //   }
  //   console.log(this.selectSubCat);
  //   console.log(this.afterSelectSubCat);
  // }
  private _filter(value: string): Category[] {
    //const filterValue = value.toLowerCase();
    const filterValue = value;

    //return this.options.filter(option => option.category_name.toLowerCase().includes(filterValue));
    return this.options.filter(option => option.category_name.includes(filterValue));
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    debugger
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: Sub_category): string {
    
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.sub_category_id + 1}`;
  }
  onSelectSubCat(row: Sub_category) {
    console.log(this.selection);
    console.log(row); debugger
    // if(this.selection.selected.find(s=>s.sub_category_id==row.sub_category_id)!=null){
    //   this.questionsForSubCat=this.userService.questionsForTeacher.filter(q=>q.sub_category_id==row.sub_category_id);
    // }
    console.log(this.selection);
  }
  onClickSelect(row: Sub_category, event: Event) {
    debugger
    console.log(event);
  }
  onSelectQuestion(event: Event) {
     //@ts-ignore

    if(event.source.selected)
    {
     //@ts-ignore
      this.simpleTest.questions.push(event.source.value)
    }  
    else {
     //@ts-ignore
       var index=this.simpleTest.questions.indexOf(event.source.value);
       this.simpleTest.questions.splice(index,1);
       debugger
    }
      
    console.log(event);
    //this.allSelectedQuestions.push(event.)
  }
  questionByCategory(subCategoryId){
return this.userService.questionsForTeacher.filter(q=>q.sub_category_id==subCategoryId&&q.level==this.test.level);
  }
}