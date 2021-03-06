﻿using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;

using TestProject.Core.ViewModels;
using TestProject.Droid.Activities;
using TestProject.Resources;

namespace TestProject.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("testProject.droid.fragments.CreateTodoItemFragment")]
    public class CreateTodoItemFragment : BaseFragment<CreateTodoItemViewModel>
    {
        protected override int FragmentId => Resource.Layout.CreateTodoItemFragment;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = base.OnCreateView(inflater, container, savedInstanceState);

            TextView tvTodoItemName = view.FindViewById<TextView>(Resource.Id.tvTodoItemName);
            TextView tvDescription = view.FindViewById<TextView>(Resource.Id.tvDescription);
            TextView tvDone = view.FindViewById<TextView>(Resource.Id.tvDone);
            Button btCreate = view.FindViewById<Button>(Resource.Id.btCreate);

            tvTodoItemName.Text = Strings.TodoItemNameTextViewLabel;
            tvDescription.Text = Strings.TodoItemDescriptionTextViewLabel;
            tvDone.Text = Strings.TodoItemIsDoneTextViewLabel;
            btCreate.Text = Strings.SaveButtonLabel;

            ((MainActivity)Activity).DrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);

            return view;
        }
    }
}