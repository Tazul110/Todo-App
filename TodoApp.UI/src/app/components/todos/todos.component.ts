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
    dueOn:new Date(),
    createdOn:new Date()
    
  };
  newTodo2: Todo = {
    id: 0,
    title: '',
    descrip:'',
    isActive: 0,
    dueOn:new Date(),
    createdOn:new Date()
    
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

  addTodo(){
   this.todoService.addTodo(this.newTodo)
   .subscribe({
    next: (todo) => {
       this.getAllTodos();
    }
   });
  }


    deleteTodo(id: number) {
        


      this.todoService.deleteTodo(id)
      .subscribe({
          next: (response) => {
              this.getAllTodos(); 
          }
      });      
    }

    fun(i: number, myTodo: Todo){
      this.newTodo2.id=myTodo.id;
      this.newTodo2.title = myTodo.title;
      this.newTodo2.descrip = myTodo.descrip;
      this.newTodo2.dueOn = myTodo.dueOn;
      
    }

    updateTodo(){
      console.log("Update is calling");

      console.log(this.newTodo2)
      this.todoService.updateTodo(this.newTodo2)
      .subscribe({
       next: (todo) => {
          this.getAllTodos();
          console.log("Update is calling");
       }
      });
    }

}
