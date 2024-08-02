﻿using Stylet.Avalonia;
using System;

namespace Stylet.Samples.NavigationController.Pages;

public class Page2ViewModel : Screen
{
    private readonly INavigationController navigationController;

    private string _initiator;
    public string Initiator
    {
        get => this._initiator;
        set => this.SetAndNotify(ref this._initiator, value);
    }

    public Page2ViewModel(INavigationController navigationController)
    {
        this.navigationController = navigationController ?? throw new ArgumentNullException(nameof(navigationController));
    }

    public void NavigateToPage1() => this.navigationController.NavigateToPage1();
}