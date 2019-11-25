import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule, Routes } from '@angular/router';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { TeacherSettingsComponent } from './components/teacher-settings/teacher-settings.component';
import { AddSubjectComponent } from './components/add-subject/add-subject.component';
import { AddSubThemeComponent } from './components/add-sub-theme/add-sub-theme.component';
import { AddGroupComponent } from './components/add-group/add-group.component';
import { AddQuestionComponent } from './components/add-question/add-question.component';
import { StudentHomeComponent } from './components/student-home/student-home.component';
import { AddPupilsComponent } from './components/add-pupils/add-pupils.component';
import { CreateTestComponent } from './components/create-test/create-test.component';
import { ViewClassesComponent } from './components/view-classes/view-classes.component';
import { MyProfileComponent } from './components/my-profile/my-profile.component';
import { ViewSubjectsComponent } from './components/view-subjects/view-subjects.component';
import { ViewSubThemesComponent } from './components/view-sub-themes/view-sub-themes.component';
import { ViewQuestionsComponent } from './components/view-questions/view-questions.component';
import { ViewStudentsComponent } from './components/view-students/view-students.component';
import { SolveTestComponent } from './components/solve-test/solve-test.component';
import { EditStudentComponent } from './components/edit-student/edit-student.component';
import { ViewStudentComponent } from './components/view-student/view-student.component';
import { ViewTestsComponent } from './components/view-tests/view-tests.component';
import { WaitingComponent } from './components/waiting/waiting.component';
import { StudentChartComponent } from './components/student-chart/student-chart.component';
const appRoutes: Routes = [
  { path: '', component: SignInComponent },
  { path: 'waiting', component: WaitingComponent },
  { path: 'signUp', component: SignUpComponent },
  { path: 'forgotPassword', component: ForgotPasswordComponent },
  {
    path: 'teachersettings', component: TeacherSettingsComponent,
    children: [
      { path: 'addSubject', component: AddSubjectComponent },
      { path: 'addSubTheme', component: AddSubThemeComponent },
      {
        path: 'addGroup', component: AddGroupComponent,
        children: [
          { path: 'addPupils', redirectTo: 'addPupils' }
        ]
      },
      { path: 'addQuestion', component: AddQuestionComponent },
      { path: 'addPupils/:classId', component: AddPupilsComponent },
      { path: 'createTest', component: CreateTestComponent },
      {
        path: 'viewClasses', component: ViewClassesComponent,
        children: [
          {
            path: 'viewStudents/:class_id', component: ViewStudentsComponent
          }
        ]
      },
      { path: 'editStudent/:studentId', component: EditStudentComponent },
      { path: 'viewDetails/:studentId', component: ViewStudentComponent },
      { path: 'viewMarks/:studentId', component:StudentChartComponent },
      { path: 'myProfile', component: MyProfileComponent },
      { path: 'viewSubjects', component: ViewSubjectsComponent },
      { path: 'viewSubThemes', component: ViewSubThemesComponent },
      { path: 'viewQuestions', component: ViewQuestionsComponent },
      { path: 'viewTests', component: ViewTestsComponent }

    ]
  },
  {
    path: 'studentHome', component: StudentHomeComponent,
    children: [
      { path: 'solveTest', component: SolveTestComponent }]
  },

  { path: '**', redirectTo: '' }
]
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }  