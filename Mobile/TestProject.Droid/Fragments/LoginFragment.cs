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
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, AddToBackStack = false)]
    [Register("testProject.droid.fragments.LoginFragment")]
    public class LoginFragment : BaseFragment<LoginViewModel>
    {
        protected override int FragmentId => Resource.Layout.LoginFragment;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = base.OnCreateView(inflater, container, savedInstanceState);

            InitializeAllControls(view);

            return view;
        }

        protected override void InitializeAllControls(View view)
        {
            TextView tvUsername = view.FindViewById<TextView>(Resource.Id.tvUsername);
            TextView tvPassword = view.FindViewById<TextView>(Resource.Id.tvPassword);
            TextView tvWithoutAccount = view.FindViewById<TextView>(Resource.Id.tvWithoutAccount);
            Button btLogin = view.FindViewById<Button>(Resource.Id.btLogin);
            Button btGoToRegistration = view.FindViewById<Button>(Resource.Id.btGoToRegistration);

            ((MainActivity)Activity).DrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);

            _controlSigningHelper.SignControl(tvUsername, Strings.UsernameTextViewLabel);
            _controlSigningHelper.SignControl(tvPassword, Strings.PasswordTextViewLabel);
            _controlSigningHelper.SignControl(tvWithoutAccount, Strings.WithoutAccountPrompt);
            _controlSigningHelper.SignControl(btLogin, Strings.LoginButtonLabel);
            _controlSigningHelper.SignControl(btGoToRegistration, Strings.RegistrationButtonLabel);
        }
    }
}