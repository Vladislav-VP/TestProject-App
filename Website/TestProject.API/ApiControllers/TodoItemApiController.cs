﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;
using ViewModels.Api.TodoItem;

namespace TestProject.API.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoItemApiController : Controller
    {
        private readonly ITodoItemApiService _todoItemService;

        public TodoItemApiController(ITodoItemApiService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        
        [Route("GetUsersTodoItems")]
        [HttpGet]
        public GetListTodoItemApiView GetList()
        {
            GetListTodoItemApiView usersTodoItems = _todoItemService.GetUsersTodoItems(User);
            return usersTodoItems;
        }

        [Route("Get/{id}")]
        [HttpGet]
        public GetTodoItemApiView Get(int id)
        {
            GetTodoItemApiView todoItem = _todoItemService.GetTodoItem(id);
            return todoItem;
        }

        [Route("Create")]
        [HttpPost]
        public ResponseCreateTodoItemApiView Create([FromBody]RequestCreateTodoItemApiView todoItem)
        {
            ResponseCreateTodoItemApiView response = _todoItemService.Create(todoItem, User);
            return response;
        }

        [Route("Edit")]
        [HttpPost]
        public ResponseEditTodoItemApiView Edit([FromBody]RequestEditTodoItemApiView todoItem)
        {
            ResponseEditTodoItemApiView response = _todoItemService.EditTodoItem(todoItem);
            return response;
        }
        
        [Route("Delete/{id}")]
        [HttpDelete]
        public DeleteTodoItemApiView Delete(int id)
        {
            DeleteTodoItemApiView response = _todoItemService.Delete(id);
            return response;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}