import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-rectangle',
  templateUrl: './rectangle.component.html',
  styleUrls: ['./rectangle.component.css']
})
export class RectangleComponent implements OnInit {
    constructor(private route: ActivatedRoute){}

    shapeHeight: number=0;
    shapeWidth: number=0;
    rectangle={
      title:"",
      result:0
    }
    ngOnInit(): void {
      this.shapeHeight = Number(this.route.snapshot.queryParams['height']);
      this.shapeWidth = Number(this.route.snapshot.queryParams['width']);
        if((this.shapeHeight==this.shapeWidth)||(Math.abs(this.shapeHeight-this.shapeWidth)>5)){
          this.rectangle.title="חישוב שטח המלבן";
          this.rectangle.result=this.shapeHeight*this.shapeWidth;
        }
        else {
          this.rectangle.title="חישוב היקף המלבן";
          this.rectangle.result=(this.shapeHeight*2)+(this.shapeWidth*2);
        }
    }
    
}
