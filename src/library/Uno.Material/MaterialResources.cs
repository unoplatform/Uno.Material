using System;
using Windows.UI.Xaml;

namespace Uno.Material
{
	/// <summary>
	/// Material resources including colors, layout values and styles
	/// </summary>
	public sealed class MaterialResources : ResourceDictionary
	{
		public MaterialResources()
		{
			// Add all ResourceDictionaries for Variables here in alphabetical order
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Application/AnimationConstants.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Application/Colors.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Application/Converters.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Application/TextBoxVariables.xaml") });

			// Add all ResourceDictionaries for Controls here in alphabetical order
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/BottomNavigationBar.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/BottomNavigationBarItem.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/Button.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/Card.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/CheckBox.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ComboBox.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/CommandBar.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/FloatingActionButton.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/NavigationView.xaml") }); // NavigationView merges it's related dictionaries already
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/PasswordBox.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ProgressBar.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ProgressRing.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/RadioButton.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/Ripple.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/SnackBar.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/TextBox.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/TextBlock.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/TimePicker.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ToggleButton.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ToggleSwitch.xaml") });
		}
	}
}
