﻿using Stylet.Avalonia;
using System;

namespace Stylet.Samples.TabNavigation;
public class Page1ViewModel : Screen, IDisposable
{
    public Page1ViewModel()
    {
        this.DisplayName = "Page 1";
    }

    protected override void OnClose()
    {
        base.OnClose();
    }

    public void Dispose()
    {

    }
}