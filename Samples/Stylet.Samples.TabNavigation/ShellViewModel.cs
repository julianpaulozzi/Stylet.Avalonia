﻿using Stylet.Avalonia;

namespace Stylet.Samples.TabNavigation;

public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
{
    public ShellViewModel(Page1ViewModel page1, Page2ViewModel page2)
    {
        this.Items.Add(page1);
        this.Items.Add(page2);

        this.ActiveItem = page1;
    }
}