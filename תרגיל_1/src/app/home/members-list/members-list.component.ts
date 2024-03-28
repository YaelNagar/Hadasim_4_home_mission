import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { HMOMembers } from 'src/app/classes/HMOMembers';
import { HMOMembersService } from 'src/app/services/hmomembers.service';
import { MemberCardComponent } from './member-card/member-card.component';

export enum statuses {
  show,
  edit,
  new
}
@Component({
  selector: 'app-members-list',
  templateUrl: './members-list.component.html',
  styleUrls: ['./members-list.component.css']
})
export class MembersListComponent implements OnInit {
  constructor(
    public router: Router,
    public HMOMembersService: HMOMembersService) { }

  membersList: Array<HMOMembers> = new Array<HMOMembers>()
  currentMember: HMOMembers = new HMOMembers()

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.HMOMembersService.getAll().subscribe(
      res => {
        this.HMOMembersService.allMembers = res;
        this.membersList = res;
      },
      err => {
        console.log(err);
      }
    )
  }

  edit(id: Number) {
    this.router.navigate(['/member-card'], { queryParams: { 'id': id, 'status': statuses.edit } })
  }

  show(id: Number) {
    this.router.navigate(['/member-card'], { queryParams: { 'id': id, 'status': statuses.show } })
  }

  add() {
    this.router.navigate(['/member-card'], { queryParams: { 'status': statuses.new } })
  }

  delete(id: Number) {
    this.HMOMembersService.Delete(id).subscribe(
      res => {
        this.getAll();
        console.log("success:", res);
      },
      err => {
        console.log("error:", err)
      }
    )
  }
}
