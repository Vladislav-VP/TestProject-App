﻿using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;

using TestProject.Core.ViewModels;
using TestProject.Droid.Activities;

namespace TestProject.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("testProject.droid.views.CreateTodoItemFragment")]
    public class CreateTodoItemFragment : BaseFragment<CreateTodoItemViewModel>
    {
        protected override int FragmentId => Resource.Layout.CreateTodoItemFragment;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = base.OnCreateView(inflater, container, savedInstanceState);

            ((MainActivity)Activity).DrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);

            return view;
        }
    }
}