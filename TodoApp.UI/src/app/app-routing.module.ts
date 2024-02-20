import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TodosComponent } from './components/todos/todos.component';
import { StudentEditComponent } from './student-edit/student-edit.component';

const routes: Routes = [
  {
    path: '', component: TodosComponent
  },
  {
    path: 'todos',
    component: TodosComponent
  },
  {path: 'students/:id/edit', component: StudentEditComponent, title:'Update Student'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
