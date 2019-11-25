import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { Teacher } from 'src/app/Models/Teacher';
import { Student } from 'src/app/Models/Student';
import { CookieService } from 'ngx-cookie-service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  checked: boolean = false;
  loginForm : FormGroup;

  constructor(private userService: UserService, private router: Router, private cookieService: CookieService,private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      'userName' : [null, Validators.required],
      'userPassword': [null,  Validators.required],
      'rememberMe':[false]
    });
    console.log(this.loginForm);
    this.loginForm.valueChanges.subscribe( (form: any) => {
      console.log('form changed to:', form);
    }
    );
   }
  ngOnInit() {
    // $(function () {
    //   $('.button-checkbox').each(function () {
    //     var $widget = $(this),
    //       $button = $widget.find('button'),
    //       $checkbox = $widget.find('input:checkbox'),
    //       color = $button.data('color'),
    //       settings = {
    //         on: {
    //           icon: 'glyphicon glyphicon-check'
    //         },
    //         off: {
    //           icon: 'glyphicon glyphicon-unchecked'
    //         }
    //       };

    //     $button.on('click', function () {
    //       $checkbox.prop('checked', !$checkbox.is(':checked'));
    //       $checkbox.triggerHandler('change');
    //       updateDisplay();
    //     });

    //     $checkbox.on('change', function () {
    //       updateDisplay();
    //     });

    //     function updateDisplay() {
    //       var isChecked = $checkbox.is(':checked');
    //       // Set the button's state
    //       $button.data('state', (isChecked) ? "on" : "off");

    //       // Set the button's icon
    //       $button.find('.state-icon')
    //         .removeClass()
    //         .addClass('state-icon ' + settings[$button.data('state')].icon);

    //       // Update the button's color
    //       if (isChecked) {
    //         $button
    //           .removeClass('btn-default')
    //           .addClass('btn-' + color + ' active');
    //       }
    //       else {
    //         $button
    //           .removeClass('btn-' + color + ' active')
    //           .addClass('btn-default');
    //       }
    //     }
    //     function init() {
    //       updateDisplay();
    //       // Inject the icon if applicable
    //       if ($button.find('.state-icon').length == 0) {
    //         $button.prepend('<i class="state-icon ' + settings[$button.data('state')].icon + '"></i> ');
    //       }
    //     }
    //     init();
    //   });
    // });
    var username = this.cookieService.get('userName');
    var password = this.cookieService.get('password');
    if (username != null && username != "" && password != null && password != "") {
      this.signIn(username, password)
    }
  }

  signIn(user_name: string, user_password: string) {
    this.userService.showSpinner=true;
    this.userService.getUser(user_name, user_password).subscribe(
      (res: any) => {
        this.userService.showSpinner=false;
        if (this.checked == true) {
          let expire = new Date();
          var time = Date.now() + ((3600 * 1000) * 2);  
          expire.setTime(time);
          this.cookieService.set('userName', user_name, expire);
          this.cookieService.set('password', user_password, expire);
        }
        if (res.user['status'] == 1) {
          this.userService.user = res as Teacher;
          this.router.navigate(['/teachersettings']);
        }
        else {
          this.userService.user = res as Student;
          this.router.navigate(['/studentHome']);
        }
      },
      (err) => console.log(err));
  }

}
