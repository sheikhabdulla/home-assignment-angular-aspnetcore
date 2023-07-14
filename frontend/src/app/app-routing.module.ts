import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NoMatchPageComponent } from './no-match-page/no-match-page.component';
import { PostDetailListComponent } from './post-detail-list/post-detail-list.component';
import { ResourceSectionComponent } from './resource-section/resource-section.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/resource-section',
    pathMatch: 'full',
  },
  {
    path: 'resource-section',
    component: ResourceSectionComponent,
  },
  {
    path:'post-detail-list',
    component: PostDetailListComponent
  },
  {
    path: '**',
    component: NoMatchPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
