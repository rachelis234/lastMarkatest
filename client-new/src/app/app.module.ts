import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app-routing.module";
import { UserService } from "./services/user.service";
import { HttpClientModule } from "@angular/common/http";
import { SignInComponent } from "./components/sign-in/sign-in.component";
import { SignUpComponent } from "./components/sign-up/sign-up.component";
import { ForgotPasswordComponent } from "./components/forgot-password/forgot-password.component";
import { TeacherSettingsComponent } from "./components/teacher-settings/teacher-settings.component";
import { StudentHomeComponent } from "./components/student-home/student-home.component";
import { AddSubjectComponent } from "./components/add-subject/add-subject.component";
import { AddSubThemeComponent } from "./components/add-sub-theme/add-sub-theme.component";
import { AddGroupComponent } from "./components/add-group/add-group.component";
import { AddQuestionComponent } from "./components/add-question/add-question.component";
import { AddPupilsComponent } from "./components/add-pupils/add-pupils.component";
import { CreateTestComponent } from "./components/create-test/create-test.component";
import { CookieService } from "ngx-cookie-service";
import { NavbarComponent } from "./components/navbar/navbar.component";
import { ViewStudentsComponent } from "./components/view-students/view-students.component";
import { ViewClassesComponent } from "./components/view-classes/view-classes.component";
import { ViewQuestionsComponent } from "./components/view-questions/view-questions.component";
import { ViewTestsComponent } from "./components/view-tests/view-tests.component";
import { MyProfileComponent } from "./components/my-profile/my-profile.component";
import { ViewSubjectsComponent } from "./components/view-subjects/view-subjects.component";
import { ViewSubThemesComponent } from "./components/view-sub-themes/view-sub-themes.component";
import { SolveTestComponent } from "./components/solve-test/solve-test.component";
import { EditStudentComponent } from "./components/edit-student/edit-student.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ViewStudentComponent } from "./components/view-student/view-student.component";
import {
  MatTableModule,
  MatFormFieldModule,
  MatCheckboxModule,
  MatNativeDateModule,
  MatDatepickerModule
} from "@angular/material";
import { MatPaginatorModule } from "@angular/material";
import { WaitingComponent } from "./components/waiting/waiting.component";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";
import { MatAutocompleteModule } from "@angular/material/autocomplete";
import { ClickOutsideModule } from "ng-click-outside";
import { CreateSimpleTestComponent } from "./components/create-simple-test/create-simple-test.component";
import { CreateGeneratedTestComponent } from "./components/create-generated-test/create-generated-test.component";
import { MatRadioModule } from "@angular/material/radio";
//import { AmericanQuesionComponent } from './components/american-quesion/american-quesion.component';
import { YesNoQuestionComponent } from "./components/yes-no-question/yes-no-question.component";
import { AmericanQuestionComponent } from "./components/american-question/american-question.component";
//import { MatchQuestionComponent } from './components/match-question/match-question.component';

import { MatchQuestionComponent } from "./components/match-question/match-question.component";
import { ChartsModule } from "@progress/kendo-angular-charts";
import "hammerjs";
import { StudentChartComponent } from "./components/student-chart/student-chart.component";
// import {MatDatepickerModule} from '@angular/material/datepicker';
// import { FusionChartsModule } from "angular-fusioncharts";
import * as FusionCharts from "fusioncharts";
import * as Charts from "fusioncharts/fusioncharts.charts";
import { MatIconModule } from "@angular/material/icon"; // <----- Here

import * as FusionTheme from "fusioncharts/themes/fusioncharts.theme.fusion";
import { MatListModule } from "@angular/material/list";
import { MatButtonModule } from "@angular/material/button";
import { HomePageComponent } from "./components/home-page/home-page.component";
import { SendEmailComponent } from "./components/send-email/send-email.component";
// FusionChartsModule.fcRoot(FusionCharts, Charts, FusionTheme);

@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    SignUpComponent,
    ForgotPasswordComponent,
    TeacherSettingsComponent,
    StudentHomeComponent,
    AddSubjectComponent,
    AddSubThemeComponent,
    AddGroupComponent,
    AddQuestionComponent,
    AddPupilsComponent,
    CreateTestComponent,
    NavbarComponent,
    ViewStudentsComponent,
    ViewClassesComponent,
    ViewQuestionsComponent,
    ViewTestsComponent,
    MyProfileComponent,
    ViewSubjectsComponent,
    ViewSubThemesComponent,
    SolveTestComponent,
    EditStudentComponent,
    ViewStudentComponent,
    WaitingComponent,
    CreateSimpleTestComponent,
    CreateGeneratedTestComponent,
    //AmericanQuesionComponent,
    AmericanQuestionComponent,
    YesNoQuestionComponent,
    MatchQuestionComponent,
    //MatchQuestionComponent,
    StudentChartComponent,
    HomePageComponent,
    SendEmailComponent
  ],
  imports: [
    MatInputModule,
    BrowserModule,
    FormsModule,
    MatFormFieldModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatRadioModule,
    MatAutocompleteModule,
    ClickOutsideModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    // FusionChartsModule,
    ChartsModule,
    MatListModule,
    MatButtonModule,
    MatIconModule
  ],
  providers: [UserService, CookieService],
  bootstrap: [AppComponent]
})
export class AppModule {}
