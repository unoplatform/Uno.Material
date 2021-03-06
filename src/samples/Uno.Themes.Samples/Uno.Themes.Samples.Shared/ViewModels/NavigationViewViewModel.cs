﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Uno.Themes.Samples.ViewModels
{
	public class NavigationViewViewModel : ViewModelBase
	{
		public string CodeBehindSource { get => GetProperty<string>(); set => SetProperty(value); }
		public NavigationViewViewModel()
		{
			this.CodeBehindSource = GetCodeBehindSource().Replace("\t", "    ");
		}

		private string GetCodeBehindSource()
		{
			// source taken from SamplePages.xaml.cs
			return
@"private void NavView_Loaded(object sender, RoutedEventArgs e)
{
	if (NavView.MenuItems.Any())
	{
		// on android, this can also fire when the app is resumed from background (""alt-tabbed back"")
		return;
	}

#if WINDOWS_UWP
	NavView.IsSettingsVisible = true;
	// Change the settings text to toggle the theme
	var settingsItem = (NavigationViewItem)NavView.SettingsItem;
	settingsItem.Content = ""Toggle Light/Dark theme"";
#else
	NavView.IsSettingsVisible = false;
#endif

	// Adding NavigationView items in code behind
	InitializeNavigationViewItems();

	// Set the starting page
	var type = typeof(ColorsSamplePage);
	var item = NavView.MenuItems
		.OfType<NavigationViewItem>()
		.FirstOrDefault(x => (Type)x.Tag == type)
		?? throw new Exception($""Navigation item for {type} was not found."");

	NavView.SelectedItem = item;
	NavView.Header = item.Content;
	ContentFrame.Navigate((Type)item.Tag);
}

private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
{
	if (args.IsSettingsInvoked)
	{
		ToggleTheme();
	}
	else if (args.InvokedItemContainer is NavigationViewItem item)
	{
		NavView.Header = item.Content;
		ContentNavigation((Type)item.Tag);
	}
}

private async void ContentNavigation(Type page)
{
#if __ANDROID__
	// By closing the navigation pane with a delay, prior to navigation, we avoid flickers from too much work being done on the UI Thread.
	NavView.IsPaneOpen = false;
	await Task.Delay(TimeSpan.FromSeconds(.25));
#endif

	ContentFrame.Navigate(page);
}

private void InitializeNavigationViewItems()
{
	// Styles
	using (AddMenuHeader(""Styles""))
	{
		AddMenuItem<ColorsSamplePage>();
		NavView.MenuItems.Add(new NavigationViewItemSeparator());
	}

	// Controls
	using (AddMenuHeader(""Controls""))
	{
		AddMenuItem<BottomNavigationBarSamplePage>(content: ""BottomBarNavigation"");
		AddMenuItem<ButtonSamplePage>();
		AddMenuItem<CardSamplePage>();
		AddMenuItem<CheckBoxSamplePage>();
		AddMenuItem<ComboBoxSamplePage>();
		AddMenuItem<FabSamplePage>(content: ""FAB"");
		AddMenuItem<HyperlinkButtonSamplePage>();
		AddMenuItem<NavigationViewSamplePage>();
		AddMenuItem<PasswordBoxSamplePage>();
		AddMenuItem<RadioButtonSamplePage>();
		AddMenuItem<SnackBarSamplePage>();
		AddMenuItem<SliderSamplePage>();
		AddMenuItem<TextBlockSamplePage>();
		AddMenuItem<TextBoxSamplePage>();
		AddMenuItem<ToggleSwitchSamplePage>();
	}

	IDisposable AddMenuHeader(string content)
	{
		NavView.MenuItems.Add(new NavigationViewItemHeader()
		{
			Content = content,
		});
		return Disposable.Empty;
	}
	void AddMenuItem<TSamplePage>(string content = null, Symbol iconSymbol = Symbol.Next)
		where TSamplePage : Page
	{
		NavView.MenuItems.Add(new NavigationViewItem()
		{
			Content = content ?? Regex.Replace(typeof(TSamplePage).Name, @""SamplePage$"", string.Empty),
			Icon = new SymbolIcon(iconSymbol),
			Tag = typeof(TSamplePage),
		});
	}
}";
		}
	}
}
