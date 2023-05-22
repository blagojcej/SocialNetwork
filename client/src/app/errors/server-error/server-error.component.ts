import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})
export class ServerErrorComponent implements OnInit {
  error: any;

  constructor(private router: Router) {
    // We have to access NavigationExtras from the ErrorInteceptor in the constructior.
    // In the ngOnInit is to late to access this data
    const navigation = this.router.getCurrentNavigation();
    // Access the error object of the extras
    this.error = navigation?.extras?.state?.['error'];
  }

  ngOnInit(): void {
  }
}
