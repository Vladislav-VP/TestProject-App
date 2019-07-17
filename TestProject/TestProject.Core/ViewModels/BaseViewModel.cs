﻿using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        protected readonly IMvxNavigationService _navigationService;

        public BaseViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }

    public abstract class BaseViewModel<TParameter, TResult> : MvxViewModel<TParameter, TResult>
        where TParameter : class
        where TResult : class
    {
        protected readonly IMvxNavigationService _navigationService;

        public BaseViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
