﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Repositories;
using DataAccess.Context;
using Services;
using ViewModels.Api.TodoItem;

namespace TestProject.API.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemApiController : Controller
    {
        private readonly TodoListContext _context;
        private readonly TodoItemService _todoItemService;

        public TodoItemApiController(TodoListContext context)
        {
            _context = context;
            _todoItemService = new TodoItemService(_context);            
        }
        
        [Route("GetUsersTodoItems/userId={userId}")]
        [HttpGet]
        public GetListTodoItemApiView GetList(int userId)
        {
            GetListTodoItemApiView usersTodoItems = _todoItemService.GetUsersTodoItems(userId);
            return usersTodoItems;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAllTodoItems()
        {// TODO: Remove this method later?
            IEnumerable<TodoItem> todoItems = null;

            todoItems = _todoItemService.GetAllObjects();

            return todoItems;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            TodoItem todoItem = _todoItemService.FindById(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            var result = new ObjectResult(todoItem);
            return result;
        }

        [Route("Create")]
        [HttpPost]
        public ResponseCreateTodoItemApiView Create([FromBody]RequestCreateTodoItemApiView todoItem)
        {
            ResponseCreateTodoItemApiView response = _todoItemService.Insert(todoItem);
            return response;
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult EditTodoItem([FromBody]TodoItem todoItem)
        {
            if (todoItem == null)
            {
                return BadRequest();
            }
            TodoItem todoItemToModify = _todoItemService.FindById(todoItem.Id);
            if (todoItemToModify == null)
            {
                return NotFound();
            }
            _todoItemService.EditTodoItem(todoItem);
            return Ok(todoItem);
        }
        
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteTodoItem(int id)
        {
            TodoItem todoItem = _todoItemService.FindById(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _todoItemService.Delete(id);
            return Ok(todoItem);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}