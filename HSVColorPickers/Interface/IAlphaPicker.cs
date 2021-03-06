﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HSVColorPickers
{
    /// <summary>
    /// Represents a basic Interface of alpha picker.
    /// </summary>
    public interface IAlphaPicker
    {
        /// <summary> Gets picker's type name. </summary>
        string Type { get; }

        /// <summary> Gets picker self. </summary>
        Control Self { get; }

        /// <summary> Gets or sets picker's alpha. </summary>
        byte Alpha { get; set; }

        /// <summary> Occurs when the alpha value changed. </summary>
        event AlphaChangedHandler AlphaChanged;
        /// <summary> Occurs when the alpha changed starts. </summary>
        event AlphaChangedHandler AlphaChangeStarted;
        /// <summary> Occurs when alpha changed. </summary>
        event AlphaChangedHandler AlphaChangeDelta;
        /// <summary> Occurs when the alpha changed is complete. </summary>
        event AlphaChangedHandler AlphaChangeCompleted;
    }
}