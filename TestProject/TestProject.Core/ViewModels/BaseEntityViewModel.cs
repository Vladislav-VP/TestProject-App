﻿using System.Threading.Tasks;

using MvvmCross.Navigation;
using MvvmCross.ViewModels;

using TestProject.Core.Enums;
using TestProject.Core.ViewModelResults;
using TestProject.Entities;
using TestProject.Services.Helpers.Interfaces;

namespace TestProject.Core.ViewModels
{
    public abstract class BaseEntityViewModel : BaseViewModel, IMvxViewModelResult<ViewModelResult<BaseEntity>>
    {        
        protected readonly IDialogsHelper _dialogsHelper;

        public BaseEntityViewModel(IMvxNavigationService navigationService,
            IUserStorageHelper storage, IDialogsHelper dialogsHelper)
            : base(navigationService, storage)
        {
            _dialogsHelper = dialogsHelper;
        }
        
        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        protected bool IsStateChanged { get; set; }

        protected async Task HandleDialogResult(DialogResult result)
        {
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (result == DialogResult.No)
            {
                await _navigationService.Close(this, result: null);
                return;
            }
        }

        // TODO: Think about better name.
        protected abstract Task HandleEntity();

        protected async override Task GoBack()
        {
            if (!IsStateChanged)
            {
                await _navigationService.Close(this, result: null);
                return;
            }

            DialogResult result = await _navigationService
                .Navigate<CancelDialogViewModel, DialogResult>();
            // TODO: Replace magic number 600 with the constant?
            await Task.Delay(600);

            if (result == DialogResult.Yes)
            {
                await HandleEntity();
                return;
            }

            await HandleDialogResult(result);
        }


        protected virtual CreationResult<TEntity> GetCreationResult<TEntity>(TEntity entity)
        {
            var creationResult = new CreationResult<TEntity>
            {
                Entity = entity,
                IsSucceded = true
            };

            return creationResult;
        }

        protected virtual UpdateResult<TEntity> GetUpdateResult<TEntity>(TEntity entity)
        {
            var updateResult = new UpdateResult<TEntity>
            {
                Entity = entity,
                IsSucceded = true
            };

            return updateResult;
        }

        protected virtual DeletionResult<TEntity> GetDeletionResult<TEntity>(TEntity entity)
        {
            var deletionResult = new DeletionResult<TEntity>
            {
                Entity = entity,
                IsSucceded = true
            };

            return deletionResult;
        }
    }
}
