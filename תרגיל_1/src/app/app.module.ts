import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GraphComponent } from './home/graph/graph.component';
import { MembersListComponent } from './home/members-list/members-list.component';
import { MemberCardComponent } from './home/members-list/member-card/member-card.component';
import { HttpClientModule } from '@angular/common/http';
import { VaccineToMemberService } from './services/vaccine-to-member.service';
import { HMOMembersService } from './services/hmomembers.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CanvasJSAngularChartsModule } from '@canvasjs/angular-charts';
import { GoogleMapsModule } from '@angular/google-maps';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GraphComponent,
    MembersListComponent,
    MemberCardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,  
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    CanvasJSAngularChartsModule,
    GoogleMapsModule,
    MatSelectModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule
  ],
  providers: [VaccineToMemberService, HMOMembersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
