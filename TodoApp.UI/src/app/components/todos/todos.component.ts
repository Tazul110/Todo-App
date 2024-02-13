import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo.model';
import { TodoService } from '../../services/todo.service';
import { log, warn } from 'node:console';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrl: './todos.component.css'
})
export class TodosComponent implements OnInit{
  todos: Todo[]= [];
  newTodo: Todo = {
    id: 0,
    title: '',
    descrip:'',
    isActive: 0,
    dueOn:new Date
    
  };

  constructor(private todoService: TodoService) {}
  ngOnInit(): void {
    this.getAllTodos();
  }

  getAllTodos(){
    this.todoService.getAllTodos()
    .subscribe({
      next: (todos) => {
        this.todos = todos;
       
        
      }
    });
  }

  // addTodo(){
  //  this.todoService.addTodo(this.newTodo)
  //  .subscribe({
  //   next: (todo) => {
  //     this.getAllTodos();
  //   }
  //  });
  // }
}
