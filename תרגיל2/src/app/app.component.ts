import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{
  constructor(private route: Router){}
  title = 'AngularProject_YaelNagar';
  ngOnInit(): void {
  }

  close(){
    // this.route.navigate(['https://www.google.com']);
    window.open('https://www.google.com', '_blank');
    window.close()
  }
}