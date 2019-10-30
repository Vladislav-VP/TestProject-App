﻿using System.Threading.Tasks;

using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

using TestProject.Core.ViewModelResults;
using TestProject.Entities;
using TestProject.Services.Helpers.Interfaces;
using TestProject.Services.Interfaces;
using TestProject.Services.Repositories.Interfaces;

namespace TestProject.Core.ViewModels
{
    public class CreateTodoItemViewModel : TodoItemViewModel, IMvxViewModelResult<CreationResult<TEntity>>
    {
        public CreateTodoItemViewModel(IMvxNavigationService navigationService, IUserStorageHelper storage, ICancelDialogService cancelDialogService,
            IValidationHelper validationHelper, ITodoItemRepository todoItemRepository, IDialogsHelper dialogsHelper, ITodoItemService webService)
            : base(navigationService, storage,cancelDialogService, validationHelper, todoItemRepository, dialogsHelper, webService)
        {
            CreateTodoItemCommand = new MvxAsyncCommand(HandleEntity);
        }
        
        public IMvxAsyncCommand CreateTodoItemCommand { get; private set; }

        protected override async Task HandleEntity()
        {
            User currerntUser = await _storage.Get();
            var todoItem = new TEntity
            {
                Name = Name,
                Description = Description,
                IsDone = IsDone,
                UserId = currerntUser.Id
            };

            bool isTodoItemValid = _validationHelper.IsObjectValid(todoItem);
            if (!isTodoItemValid)
            {
                return;
            }

            await _webService.AddToApi(todoItem);
            await _todoItemRepository.Insert(todoItem);
            var creationResult = new CreationResult<TEntity>
            {
                Entity = todoItem,
                IsSucceded = true
            };

            await _navigationService.Close(this, result: creationResult);
        }
    }
}