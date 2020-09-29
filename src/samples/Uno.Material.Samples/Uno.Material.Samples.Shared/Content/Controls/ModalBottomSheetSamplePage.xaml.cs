using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Uno.Material.Samples.Content.Controls
{
	public sealed partial class ModalBottomSheetSamplePage : Page
	{
		public ModalBottomSheetSamplePage()
		{
			this.InitializeComponent();
			this.SeeCodeBehindButton.Content = GetCodeBehindSource().Replace("\t", "    ");
			this.SeeDataTemplateCodeButton.Content = GetDataTemplateCodeSource().Replace("\t", "    ");
		}

		private string GetCodeBehindSource()
		{
			return
@"private void Button_Clicked(object sender, RoutedEventArgs e)
{
		ModalBottomSheet.IsOpened = true;
}";
		}

		private string GetDataTemplateCodeSource()
		{
			return
@"<Page.Resources>
	<!-- Sample Content Template -->
	<DataTemplate x:Key'ContentTemplate'>
		<StackPanel Background='{ThemeResource MaterialBackgroundColor}'
					HorizontalAlignment='Stretch'
					VerticalAlignment='Stretch'>

			<TextBlock Style='{ThemeResource MaterialHeadline6}'
					   Text'='Sheet Content'
					   Margin='12' />

			<ListView ItemsSource='abcdefg' />
 
		</StackPanel>
	</DataTemplate>
</Page.Resources>";
		}

		private void Button_Clicked(object sender, RoutedEventArgs e)
		{
			ModalBottomSheet.IsOpened = true;
		}
	}
}
