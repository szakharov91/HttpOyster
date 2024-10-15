using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HttpOyster.UI.Utils.Wpf;

/// <summary> Abstract class for extension UserControl, implements INotifyPropertyChanged </summary>
public abstract class UserControlNotified : UserControl, INotifyPropertyChanged
{
    public string? ControlName { get; set; }

    /// <summary> Raise when property will changed </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary> Raise event PropertyChanged </summary>
    /// <param name="propertyName">Name of your property</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary> Method wrapper for invoking OnPropertyChanged</summary>
    /// <typeparam name="T">type of your parameter</typeparam>
    /// <param name="field">private field</param>
    /// <param name="value">value</param>
    /// <param name="propertyName">Property Name (not needed by default)</param>
    /// <returns>true - changed, false - not changed</returns>
    protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);

        return true;
    }
}
