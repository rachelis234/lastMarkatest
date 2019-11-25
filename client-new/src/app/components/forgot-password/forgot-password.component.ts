import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  constructor(private apiService:ApiService,private router:Router) { }

  ngOnInit() {
  }
  forgotPassword(emailAddress:string){
    this.apiService.forgotPassword(emailAddress).subscribe(
      (res)=>{
        Swal.fire(
        'Good job!',
        'We sent you an email!',
        'success'
      )
      this.router.navigate(['']);
    },
      (err)=>console.log(err)
    );
    // Swal.fire(
    //   'Good job!',
    //   'We sent you an email!',
    //   'success'
    // )
  }
}
