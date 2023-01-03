import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent {
  baseUrl = 'https://localhost:5000/api/';
  validationErrors: string[] = [];

  constructor(private http: HttpClient) {}

  get404Error() {
    this.http.get(this.baseUrl + 'buggy/not-found').subscribe(responce => {
      console.log(responce);
    }, error => {
      console.log(error);
    });
  }

  get400Error() {
    this.http.get(this.baseUrl + 'buggy/bad-request').subscribe(responce => {
      console.log(responce);
    }, error => {
      console.log(error);
    });
  }

  get500Error() {
    this.http.get(this.baseUrl + 'buggy/server-error').subscribe(responce => {
      console.log(responce);
    }, error => {
      console.log(error);
    });
  }

  get401Error() {
    this.http.get(this.baseUrl + 'buggy/auth').subscribe(responce => {
      console.log(responce);
    }, error => {
      console.log(error);
    });
  }

  get400ValidationError() {
    this.http.post(this.baseUrl + 'account/register', {}).subscribe(responce => {
      console.log(responce);
    }, error => {
      console.log(error);
      this.validationErrors = error;
    });
  }
}
