import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {SharedService} from 'src/app/shared/services/shared.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ErrorHandlerService } from './../shared/services/error-handler.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  public errorMessage: string = '';
  registerForm:any;
  submitted = false;
  @Input() employee = { FirstName: '', LastName: '', Email: '', Activity:'', Comments:'' }

  constructor(private formBuilder: FormBuilder,
              private service:SharedService,
              public router: Router, 
              private errorHandler: ErrorHandlerService) { } 

  ngOnInit(): void {

    this.registerForm = this.formBuilder.group({      
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],  
      email: ['', [Validators.required, Validators.email]],
      activity: ['', Validators.required], 
  });
  }
  get f() { return this.registerForm.controls; }

  addEmployee() {
      this.submitted = true;

      // stop here if form is invalid
      if (this.registerForm.invalid) {
          return;
      }

              this.service.addEmployee(this.employee).subscribe(re=>{             
                this.router.navigate(['/thankyou'])
              },
              (error) => {                
              this.errorHandler.handleError(error);
              this.errorMessage = this.errorHandler.errorMessage;
            })
  }

  onReset() {
    this.submitted = false;
    this.registerForm.reset();
}
}
