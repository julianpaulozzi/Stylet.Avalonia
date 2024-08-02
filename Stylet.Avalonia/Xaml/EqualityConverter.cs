﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data.Converters;

namespace Stylet.Avalonia.Xaml;

/// <summary>
/// Converter to compare a number of values, and return true (or false if Invert is true) if they are all equal
/// </summary>
[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Don't agree with prefixing static method calls with the class name")]
public class EqualityConverter : AvaloniaObject, IMultiValueConverter
{
    /// <summary>
    /// Singleton instance of this converter. Usage: Converter="{x:Static s:EqualityConverter.Instance}"
    /// </summary>
    public static readonly EqualityConverter Instance = new EqualityConverter();

    /// <summary>
    /// Gets or sets a value indicating whether to return false, instead of true, if call values are equal
    /// </summary>
    public bool Invert
    {
        get { return (bool)GetValue(InvertProperty); }
        set { SetValue(InvertProperty, value); }
    }

    /// <summary>
    /// Property specifying whether the output should be inverted
    /// </summary>
    public static readonly AvaloniaProperty InvertProperty =
        AvaloniaProperty.Register<EqualityConverter, bool>("Invert", false);

    /// <summary>
    /// Perform the conversion
    /// </summary>
    /// <param name="values">
    ///     Array of values, as produced by source bindings.
    ///     System.Windows.DependencyProperty.UnsetValue may be passed to indicate that
    ///     the source binding has no value to provide for conversion.
    /// </param>
    /// <param name="targetType">target type</param>
    /// <param name="parameter">converter parameter</param>
    /// <param name="culture">culture information</param>
    /// <returns>Converted values</returns>
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values == null || values.Count == 0)
            return null;
        var first = values.FirstOrDefault();
        var result = values.Skip(1).All(x => x.Equals(first));
        return Invert ? !result : result;
    }
}
