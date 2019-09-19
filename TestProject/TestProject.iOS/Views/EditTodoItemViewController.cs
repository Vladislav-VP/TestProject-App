﻿using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

using TestProject.Core.ViewModels;
using TestProject.iOS.Helpers.Interfaces;
using TestProject.Resources;
using MvvmCross.Platforms.Ios.Presenters.Attributes;

namespace TestProject.iOS.Views
{
    [MvxChildPresentation]
    public partial class EditTodoItemViewController : MvxViewController<EditTodoItemViewModel>, IControlsSettingHelper
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeAllControls();

            CreateBindings();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            ParentViewController.TabBarItem.Enabled = false;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            ParentViewController.TabBarItem.Enabled = true;
        }

        public void InitializeAllControls()
        {
            Title = ViewModel.Name;

            NavigationItem.LeftBarButtonItem = new UIBarButtonItem();
            NavigationItem.LeftBarButtonItem.Title = Strings.TaskListLabel;
            NavigationItem.LeftBarButtonItem.TintColor = UIColor.White;
            NavigationItem.LeftBarButtonItem.Clicked += CancelClicked;

            lbTaskName.Text = Strings.TodoItemNameTextViewLabel;
            lbDescription.Text = Strings.TodoItemDescriptionTextViewLabel;
            lbDone.Text = Strings.TodoItemIsDoneTextViewLabel;

            btSave.SetTitle(Strings.SaveButtonLabel, UIControlState.Normal);
            btDelete.SetTitle(Strings.DeleteTodoItemButtonLabel, UIControlState.Normal);
        }

        public void CreateBindings()
        {
            var set = this.CreateBindingSet<EditTodoItemViewController, EditTodoItemViewModel>();

            set.Bind(tfTaskName).To(vm => vm.Name);
            set.Bind(tfDescription).To(vm => vm.Description);
            set.Bind(swDone).To(vm => vm.IsDone);
            set.Bind(btSave).To(vm => vm.UpdateTodoItemCommand);
            set.Bind(btDelete).To(vm => vm.DeleteTodoItemCommand);

            set.Apply();
        }

        private void CancelClicked(object sender, System.EventArgs e)
        {
            if (ViewModel.GoBackCommand != null)
            {
                ViewModel.GoBackCommand.Execute(null);
            }
        }
    }
}