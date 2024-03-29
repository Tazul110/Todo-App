﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TodoApp.Models;
using System.Data.SqlClient;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TodoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllTodos")]
        public Response GetAllTodos()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllTodos(connection);

            return response;
        }

        [HttpPost]
        [Route("AddTodo")]
        public Response AddTodo(Todo todo)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddTodo(connection, todo);
            return response;
        }

        [HttpDelete]
        [Route("DeleteTodo/{id}")]

        public Response DeleteTodo(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteTodo(connection, id);

            return response;
        }

           [HttpPut]
           [Route("UpdateTodo")]
           public Response UpdateTodo(Todo todo)
           {
               SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
               Response response = new Response();
               DAL dal = new DAL();
               response = dal.UpdateTodo(connection, todo);
               return response;
           }

        [HttpGet]
        [Route("GetTodoById/{id}")]
        public Response GetTodoById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetTodoById(connection, id);

            return response;
        }

    }
}
