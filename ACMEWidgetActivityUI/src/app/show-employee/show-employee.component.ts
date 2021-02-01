import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared/services/shared.service';
import { ErrorHandlerService } from './../shared/services/error-handler.service';

@Component({
  selector: 'app-show-employee',
  templateUrl: './show-employee.component.html',
  styleUrls: ['./show-employee.component.css']
})
export class ShowEmployeeComponent implements OnInit {

  public errorMessage: string = '';
  Employee: any = [];

  constructor(public service: SharedService,
              private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    this.loadEmployees()
  }

  // Get employees list
  loadEmployees() {
    return this.service.getEmployees().subscribe((data: {}) => {
      this.Employee = data;
    },
    (error) => {                
    this.errorHandler.handleError(error);
    this.errorMessage = this.errorHandler.errorMessage;
  })
}
}
