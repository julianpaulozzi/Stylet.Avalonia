﻿using Stylet.Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stylet.Samples.HelloDialog;
public class ShellViewModel : Screen
{
    private IWindowManager windowManager;
    private IDialogFactory dialogFactory;

    private string _nameString;
    public string NameString
    {
        get { return this._nameString; }
        set { SetAndNotify(ref _nameString, value); }
    }

    public ShellViewModel(IWindowManager windowManager, IDialogFactory dialogFactory)
    {
        this.DisplayName = "Hello Dialog";

        this.windowManager = windowManager;
        this.dialogFactory = dialogFactory;

        this.NameString = "Click the button to show the dialog";
    }

    public async System.Threading.Tasks.Task ShowDialog()
    {
        //throw new Exception("KABLAMMO");
        var dialogVm = this.dialogFactory.CreateDialog1();
        var result = await this.windowManager.ShowDialog<bool>(dialogVm);
        if (result)
            this.NameString = String.Format("Your name is {0}", dialogVm.Name);
        else
            this.NameString = "Dialog cancelled";
    }
}

public interface IDialogFactory
{
    Dialog1ViewModel CreateDialog1();
}
