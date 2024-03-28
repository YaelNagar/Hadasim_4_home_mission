import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MembersListComponent } from './home/members-list/members-list.component';
import { MemberCardComponent } from './home/members-list/member-card/member-card.component';
import { GraphComponent } from './home/graph/graph.component';

const routes: Routes = [
  // { path: 'members-list', component:  MembersListComponent},
  { path: '', component:  GraphComponent},
  { path: 'graph', component:  GraphComponent},
  { path: 'members-list', component: MembersListComponent},
  { path: 'member-card', component: MemberCardComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
