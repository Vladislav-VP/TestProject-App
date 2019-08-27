﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MvvmCross.Platforms.Ios.Views;
using TestProject.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace TestProject.iOS.Views
{
    public class EditPasswordViewController : MvxViewController<EditPasswordViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<EditPasswordViewController, EditPasswordViewModel>();

            set.Apply();
        }
    }
}