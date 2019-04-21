# HSV Color Pickers

ColorPicker, RGBPicker, HSVPicker, WheelPicker, PalettePicker, StrawPicker, HexPicker, SwatchesPicker.

![](https://github.com/ysdy44/HsvColorPickers-Nuget-UWP/blob/master/ScreenShot/ScreenShot001.png)
![](https://github.com/ysdy44/HsvColorPickers-Nuget-UWP/blob/master/ScreenShot/ScreenShot003.png)


## Getting Started
  ![](https://github.com/ysdy44/HsvColorPickers-Nuget-UWP/blob/master/ScreenShot/logo.jpg)


Search 'HsvColorPickers' in Nuget and download it.


### Example

```xaml


xmlns:pickers="using:HsvColorPickers"


<pickers:ColorPicker/>

<pickers:RGBPicker/>
<pickers:HSVPicker/>
<pickers:WheelPicker/>

<pickers:SwatchesPicker/>
<pickers:HexPicker/>
<pickers:AlphaPicker/>
 

```
or 

```csharp


using HsvColorPickers;


 new ColorPicker();

 new RGBPicker();
 new HSVPicker();
 new WheelPicker();

 new SwatchesPicker();
 new HexPicker();
 new AlphaPicker();

PalettePicker.CreateFormHue();
PalettePicker.CreateFormSaturation();
PalettePicker.CreateFormValue();,


```


You can learn more from the demo application:
https://www.microsoft.com/store/productId/9PD2JJZQF524



Enjoy it..