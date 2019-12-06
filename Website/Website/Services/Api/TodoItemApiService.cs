﻿using System.Collections.Generic;

using DataAccess.Repositories.Interfaces;
using Entities;
using Services.Interfaces;
using ViewModels.Api.TodoItem;

namespace Services.Api
{
    public class TodoItemApiService : BaseApiService<TodoItem>, ITodoItemApiService
    {
        private ITodoItemRepository _todoItemRepository;

        public TodoItemApiService(ITodoItemRepository todoItemRepository)
            : base()
        {
            _todoItemRepository = todoItemRepository;
        }

        public ResponseEditTodoItemApiView EditTodoItem(RequestEditTodoItemApiView todoItem)
        {
            var response = new ResponseEditTodoItemApiView();
            if (string.IsNullOrEmpty(todoItem.Description))
            {
                response.Message = "Todo item description can not be empty";
                return response;
            }
            TodoItem todoItemToModify = _todoItemRepository.FindById(todoItem.Id);
            todoItemToModify.Description = todoItem.Description;
            todoItemToModify.IsDone = todoItem.IsDone;
            _todoItemRepository.Update(todoItemToModify);
            response.IsSuccess = true;
            response.Message = "Todo item successfully updated";
            return response;
        }

        public GetListTodoItemApiView GetUsersTodoItems(string userId)
        {
            var usersTodoItems = new GetListTodoItemApiView
            {
                TodoItems = new List<TodoItemGetListTodoItemApiViewItem>()
            };
            IEnumerable<TodoItem> retrievedTodoItems = _todoItemRepository.GetUsersTodoItems(userId);
            foreach (TodoItem todoItem in retrievedTodoItems)
            {
                var usersTodoItem = new TodoItemGetListTodoItemApiViewItem
                {
                    Id = todoItem.Id,
                    Name = todoItem.Name,
                    IsDone = todoItem.IsDone
                };
                usersTodoItems.TodoItems.Add(usersTodoItem);
            }
            return usersTodoItems;
        }

        public ResponseCreateTodoItemApiView Insert(RequestCreateTodoItemApiView todoItem)
        {
            var response = new ResponseCreateTodoItemApiView();
            if (string.IsNullOrEmpty(todoItem.Name))
            {
                response.Message = "Todo item name cannot be empty";
                return response;
            }
            if (string.IsNullOrEmpty(todoItem.Description))
            {
                response.Message = "Todo item description can not be empty";
                return response;
            }
            var todoItemToInsert = new TodoItem
            {
                Name = todoItem.Name,
                Description = todoItem.Description,
                IsDone = todoItem.IsDone,
                UserId = todoItem.UserId
            };
            base.Insert(todoItemToInsert);
            response.IsSuccess = true;
            response.Message = "Todo item successfully created";
            return response;
        }

        public GetTodoItemApiView GetTodoItem(int id)
        {
            TodoItem retrievedTodoItem = FindById(id);
            if (retrievedTodoItem == null)
            {
                return null;
            }
            var todoItem = new GetTodoItemApiView
            {
                Id = retrievedTodoItem.Id,
                Name = retrievedTodoItem.Name,
                Description = retrievedTodoItem.Description,
                IsDone = retrievedTodoItem.IsDone
            };
            return todoItem;
        }

        public new DeleteTodoItemApiView Delete(int id)
        {
            var response = new DeleteTodoItemApiView();
            base.Delete(id);
            response.IsSuccess = true;
            response.Messsage = "Todo item deleted";
            return response;
        }
    }
}