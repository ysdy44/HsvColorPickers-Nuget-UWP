﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace HSVColorPickers
{
    /// <summary>
    /// TouchSlider: 
    ///    Touch slider, It has three events : Started, Delta and Completed.
    /// </summary>
    public sealed partial class TouchSlider : UserControl
    {
        //Delegate
        public delegate void TouchValueChangeHandler(object sender, double value);
        public event TouchValueChangeHandler ValueChangeStarted;
        public event TouchValueChangeHandler ValueChangeDelta;
        public event TouchValueChangeHandler ValueChangeCompleted;

        #region DependencyProperty


        private double value;
        private double _Value
        {
            get
            {
                double scale = this.offset / (this.Border.ActualWidth - this.Ellipse.ActualWidth);
                double value = scale * (this.Maximum - this.Minimum) + this.Minimum;
                if (value < this.Minimum) return this.Minimum;
                if (value > this.Maximum) return this.Maximum;
                return value;
            }
            set => this.value = value;
        }
        public double Value
        {
            get => this.value;
            set
            {
                double scale = (value - this.Minimum) / (this.Maximum - this.Minimum);
                double width = scale * (this.Border.ActualWidth - this.Ellipse.ActualWidth);
                if (width < 0) width = 0;
                Canvas.SetLeft(this.Ellipse, width);

                this.value = value;
            }
        }


        private double offset;
        public double Offset
        {
            set
            {
                double width = this.offset;
                if (this.offset < 0) width = 0;
                if (this.offset > (this.Border.ActualWidth - this.Ellipse.ActualWidth)) width = (this.Border.ActualWidth - this.Ellipse.ActualWidth);
                Canvas.SetLeft(this.Ellipse, width);
            }
        }


        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(nameof(Minimum), typeof(double), typeof(NumberPicker), new PropertyMetadata(0.0));

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(nameof(Maximum), typeof(double), typeof(NumberPicker), new PropertyMetadata(100.0));


        public UIElement SliderBackground { get => this.Border.Child; set => this.Border.Child = value; }
        public Brush SliderBrush { get => this.UserControl.Background; set => this.UserControl.Background = value; }


        #endregion


        public TouchSlider()
        {
            this.InitializeComponent();
            this.Loaded += (s, e) => this.Value = this.value;
            this.SizeChanged += (s, e) => this.Value = this.value;

            this.Value = this.value;

            this.Thumb.CanDrag = true;
            this.Thumb.DragStarted += (sender, e) =>
            {
                this.Offset = this.offset = e.HorizontalOffset - this.Ellipse.ActualWidth / 2;
                this.value = this._Value;
                this.ValueChangeStarted?.Invoke(this, this.value);//Delegate
            };
            this.Thumb.DragDelta += (sender, e) =>
            {
                this.Offset = this.offset += e.HorizontalChange;
                this.value = this._Value;
                this.ValueChangeDelta?.Invoke(this, this.value);//Delegate
            };
            this.Thumb.DragCompleted += (sender, e) =>
            {
                this.value = this._Value;
                this.ValueChangeCompleted?.Invoke(this, this.value);//Delegate
            };
        }
    }
}
