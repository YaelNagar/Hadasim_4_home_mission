import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { range } from 'rxjs';

@Component({
  selector: 'app-triangular',
  templateUrl: './triangular.component.html',
  styleUrls: ['./triangular.component.css']
})
export class TriangularComponent implements OnInit {
  constructor(private route: ActivatedRoute, public myRoute: Router) { }

  shapeHeight: number = 0;
  shapeWidth: number = 0;
  triangular = {
    title: "",
    result:0
  }
  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => {
      this.shapeHeight = Number(params.get('height'));
      this.shapeWidth = Number(params.get('width'));
    });
  }

  Scope() {
    this.arrayStar = []
    this.triangular = {
      title: "חישוב היקף המשולש",
      result: (this.shapeHeight*this.shapeWidth)/2
    };
  }

  printTringular() {
    if (this.shapeWidth % 2 == 0 || (this.shapeWidth > (this.shapeHeight * 2))) {
      alert("לא ניתן להדפיס את המשולש")
    }
    else {
      this.triangular = { title: "", result:0 }
      this.printStarTrigular()
      setTimeout(() => {
         this.myRoute.navigate(['/home']);
      }, 1000);
    }
  }

  arrayStar: Number[] = []//size height
  printStarTrigular() {
    let num = 1;
    this.arrayStar.push(num);
    num += 2
    let whole = (this.shapeHeight - 2) / ((this.shapeWidth - 2) / 2)
    let rest = (this.shapeHeight - 2) % Math.floor((this.shapeWidth - 2) / 2)
    let index;
    for (index = 1; index <= rest; index++) {
      this.arrayStar.push(num)
    }
    for (; index < this.shapeHeight - 1;) {
      for (let i = 0; i < whole; i++, index++) {
        this.arrayStar.push(num)
      }
      num += 2;
    }
    this.arrayStar.push(num);
  }
}