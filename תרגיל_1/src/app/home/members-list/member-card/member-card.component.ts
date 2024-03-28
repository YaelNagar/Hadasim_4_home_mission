import { Component, ElementRef, Inject, NgZone, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { HMOMembers } from 'src/app/classes/HMOMembers';
import { HMOMembersService } from 'src/app/services/hmomembers.service';
import { statuses } from '../members-list.component';
import { CoronaVaccinesService } from 'src/app/services/corona-vaccines.service';
import { CoronaVaccines } from 'src/app/classes/CoronaVaccines';
import { VaccineToMemberService } from 'src/app/services/vaccine-to-member.service';
import { CoronaPatientsService } from 'src/app/services/corona-patients.service';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  index: number = 0
  currentMember: HMOMembers = new HMOMembers()
  form: FormGroup = new FormGroup({})
  coronaPatientsForm: FormGroup = new FormGroup({})
  vaccineToMemberForm: FormGroup = new FormGroup({})
  readonly = false;
  textSubmit: string = ""
  today!: string
  hmoMember!: HMOMembers
  coronaVaccines!: Array<CoronaVaccines>
  idMember: number | undefined
  status!: statuses
  addCoronaVaccines: boolean = false
  addCoronaPatients: boolean = false
  showMoreDetails: boolean =true;

  // @ViewChild('search') public searchElementRef!: ElementRef

  // @Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<MemberCardComponent>
  constructor(
    public route: ActivatedRoute,
    public router: Router,
    public HMOMembersService: HMOMembersService,
    public coronaVaccinesService: CoronaVaccinesService,
    public vaccineToMemberService: VaccineToMemberService,
    public coronaPatientsService: CoronaPatientsService,
    // private mapsAPILoader: MapsAPILoader, private ngZone: NgZone
  ) { }

  ngOnInit(): void {
    let qp = this.route.snapshot.queryParams;
    if (qp && qp['status'])
      this.status = qp['status']
    if (qp && qp['id'])
      this.idMember = qp['id']
    
    this.showMoreDetails=(this.status != statuses.new)
    this.today = new Date().toISOString().slice(0, 10)

    this.initForms();

    this.coronaVaccinesService.getAll().subscribe(
      res => {
        if (res.length > 0) {
          this.coronaVaccines = res;
          this.vaccineToMemberForm.controls['idVaccine'].patchValue(res[0].Id);
        }
      },
      err => { console.log(err); }
    )

    this.patchValueForm();

    if (this.status == statuses.show)
      this.readonly = true
    if (this.status == statuses.show)
      this.textSubmit = "סגור"
    else
      this.textSubmit = "שלח"

      
  //     //load Places Autocomplete
  //   this.mapsAPILoader.load().then(() => {
  //     // this.geoCoder = new google.maps.Geocoder;

  //     const autocomplete = new google.maps.places.Autocomplete(this.searchElementRef.nativeElement);
  //     autocomplete.addListener("place_changed", () => {
  //       this.ngZone.run(() => {
  //         //get the place result
  //         const place: google.maps.places.PlaceResult = autocomplete.getPlace();

  //         //verify result
  //         if (place.geometry === undefined || place.geometry === null) {
  //           return;
  //         }

  //         //set latitude, longitude and zoom
  //         this.form.controls['addressLat'].patchValue( place.geometry.location.lat());
  //         this.form.controls['addressLng'].patchValue(place.geometry.location.lng());
  //       });
  //     });
  //   });
  //   // this.getCurrentLocation()
   }

  initForms() {
    this.form = new FormGroup({
      "identity": new FormControl(null, [Validators.required, this.legalIdValidator]),
      "firstName": new FormControl(null, [Validators.required, Validators.pattern('[a-zA-Zא-ת]*')]),
      "lastName": new FormControl(null, [Validators.required, Validators.pattern('[a-zA-Zא-ת]*')]),
      "birthDate": new FormControl(null, [Validators.required]),
      "telephone": new FormControl(null, [Validators.pattern("^[0-9 ]{9}")]),
      "phone": new FormControl(null, [Validators.required, Validators.pattern("[0-9 ]{10}")]),
      "address": new FormControl(null, [Validators.required, Validators.pattern("[\\u0590-\\u05FFa-zA-Z0-9 ]+")]),
      "profileImage": new FormControl(null),
    })

    this.coronaPatientsForm = new FormGroup({
      'coronaBeginDate': new FormControl(this.today),
      'coronaEndDate': new FormControl(this.today),
      'idMember': new FormControl(Number(this.idMember)),
    })

    this.vaccineToMemberForm = new FormGroup({
      'idVaccine': new FormControl(null),
      'idMember': new FormControl(Number(this.idMember)),
    })
  }

  patchValueForm() {
    if (this.idMember) {
      this.HMOMembersService.GetById(this.idMember).subscribe(res => {
        if (res) {
          this.hmoMember = res;
          this.form.controls['identity'].patchValue(res.Identity);
          this.form.controls['firstName'].patchValue(res.FirstName);
          this.form.controls['lastName'].patchValue(res.LastName);
          this.form.controls['birthDate'].patchValue(this.formatDate(res.BirthDate));
          this.form.controls['telephone'].patchValue(res.Telephone);
          this.form.controls['phone'].patchValue(res.Phone);
          this.form.controls['address'].patchValue(res.Address);
          this.form.controls['profileImage'].patchValue(res.ProfileImage);
        }
      },
        err => {
          console.log(err);
        })
    }
  }

  private formatDate(date: Date | undefined) {
    if (date) {
      const d = new Date(date);
      let month = '' + (d.getMonth() + 1);
      let day = '' + d.getDate();
      const year = d.getFullYear();
      if (month.length < 2) month = '0' + month;
      if (day.length < 2) day = '0' + day;
      return [year, month, day].join('-');
    }
    return
  }

  get getIdentity() {
    return this.form.controls['identity'];
  }

  get getFirstName() {
    return this.form.controls['firstName'];
  }

  get getLastName() {
    return this.form.controls['lastName'];
  }
  get getBirthDate() {
    return this.form.controls['birthDate'];
  }

  get getTelephone() {
    return this.form.controls['telephone'];
  }

  get getPhone() {
    return this.form.controls['phone'];
  }

  get getAddress() {
    return this.form.controls['address'];
  }

  okForm() {
    debugger
    if (this.form.valid)
      if (this.status == statuses.show) {
        this.router.navigate(['/members-list'])
      }
      else if (this.status == statuses.edit) {
        this.edit()
      } else {
        this.add()
      }
  }

  edit() {
    this.form.value.id = Number(this.idMember)
    this.HMOMembersService.Update(this.form.value).subscribe(
      res => {
        console.log("success:", res);
        this.router.navigate(['/members-list'])
      },
      err => {
        console.log("error:", err)
      }
    )
  }

  add() {
    this.HMOMembersService.Add(this.form.value).subscribe(
      res => {
        console.log("success:", res);
        this.router.navigate(['/members-list'])
      },
      err => {
        console.log("error:", err)
      }
    )
  }

  uniqErr:boolean=false
  saveCoronaVaccines() {
    this.vaccineToMemberForm.controls['idVaccine'].patchValue(Number(this.vaccineToMemberForm.controls['idVaccine'].value))
    this.vaccineToMemberService.Add(this.vaccineToMemberForm.value).subscribe(
      res=> {
        console.log(res);
        this.patchValueForm();
        this.addCoronaVaccines = false
      },
      err=> {
        console.log(err);
        this.uniqErr=true;
        setTimeout(() => {
          this.uniqErr=false
        }, 2000);
      }
    )

  }

  saveCoronaPatients() {
    this.coronaPatientsService.Add(this.coronaPatientsForm.value).subscribe(
      res=> {
        console.log(res);
        this.patchValueForm();
        this.addCoronaPatients = false
      },
      err=> {
        console.log(err);
      }
    )
  }




  legalIdValidator(control: FormControl): { [s: string]: boolean } {
      let x: number;
      let s:string=control.value;
      if (isNaN(parseInt(s, 10))) {
          return { 'invalidLegalId': false };
      }
      if (s.length < 5 || s.length > 9) {
          return { 'invalidLegalId': false };
      }
      while (s.length < 9) {
          s = "0".charCodeAt(0) + s;
      }
      let sum = 0;
      for (let i = 0; i < 9; i++) {
          let k = ((i % 2) + 1) * (parseInt(s[i], 10) - 0);
          if (k > 9) {
              k -= 9;
          }
          sum += k;
      }
      if(sum % 10 === 0)
      return {};
    else
      return { 'invalidLegalId': true };




    // if (control.value) {
    //   if (control.value.Length < 5 || control.value.Length > 9)
    //     return { 'invalidLegalId': false };
    //   let s = "";
    //   for (let i = 0; i < control.value.length; i++) {
    //     s = "0" + s;

    //   }
    //   let sum = 0;
    //   for (let i = 0; i < 9; i++) {
    //     let k = ((i % 2) + 1) * (Number(s[i]) - 48);
    //     if (k > 9)
    //       k -= 9;
    //     sum += k;
    //   }
    //   return { 'invalidLegalId': sum % 10 == 0 };
    // }
    // return { 'invalidLegalId': false }
  }
}
