﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using TestProject.Core.ViewModels;

namespace TestProject.Droid.Views
{
    [Register("testProject.droid.views.CancelDialogFragment")]
    public class CancelDialogFragment : MvxDialogFragment<CancelDialogViewModel>
    {
        protected int FragmentId => Resource.Layout.CancelDialogFragment;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(FragmentId, null);
            Cancelable = false;

            return view;
        }
    }
}