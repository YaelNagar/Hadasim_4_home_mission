import { Component, OnInit } from '@angular/core';
import { VaccineToMemberService } from '../services/vaccine-to-member.service';
import { HMOMembersService } from '../services/hmomembers.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(public VaccineToMemberService: VaccineToMemberService, public HMOMembersService: HMOMembersService) { }
  membersVaccine: Number = 0
  membersNotVaccine: Number = 0
  allMembers: Number = 0

  ngOnInit(): void {

    this.HMOMembersService.getAll().subscribe(
      res => {
        this.allMembers = (res.length)
        this.VaccineToMemberService.CountMemberVaccine().subscribe(
          resV => {
            this.membersVaccine = resV
            this.membersNotVaccine = Number(this.allMembers)-Number(this.membersVaccine)
          },
          errV => {
            alert("error")
          }
        )
      },
      err => {
        alert("error")
      }
    )
  }
}
