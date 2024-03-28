import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-tower-data',
  templateUrl: './tower-data.component.html',
  styleUrls: ['./tower-data.component.css']
})
export class TowerDataComponent implements OnInit {
  towerForm: FormGroup = new FormGroup({})
  constructor(public ar: ActivatedRoute, public myRouter: Router) { }
  title = ""
  ngOnInit(): void {
    this.towerForm = new FormGroup({
      "height": new FormControl(null, [Validators.required, Validators.min(2)]),
      "width": new FormControl(null, [Validators.required]),
    })
    this.ar.params.subscribe(p => {
      if (p['shape'] == 1)
        this.title = "הכנס גובה ורוחב מלבן"
      else
        this.title = "הכנס גובה ורוחב משולש"
    })
  }

  get getHeight() {
    return this.towerForm.controls['height'];
  }
  get getWidth() {
    return this.towerForm.controls['width'];
  }

  okForm() {
    this.ar.params.subscribe(p => {
      if (p['shape'] == 1)
        this.myRouter.navigate(['/rectangle'], { queryParams: { 'height': this.getHeight.value, 'width': this.getWidth.value } })
      else this.myRouter.navigate(['/triangular'], { queryParams: { 'height': this.getHeight.value, 'width': this.getWidth.value } })
    })

  }
}
