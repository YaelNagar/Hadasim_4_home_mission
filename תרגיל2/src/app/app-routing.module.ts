import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RectangleComponent } from './rectangle/rectangle.component';
import { TriangularComponent } from './triangular/triangular.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TowerDataComponent } from './tower-data/tower-data.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'tower-data/:shape', component: TowerDataComponent },
  { path: 'rectangle', component: RectangleComponent },
  { path: 'triangular', component: TriangularComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ReactiveFormsModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
