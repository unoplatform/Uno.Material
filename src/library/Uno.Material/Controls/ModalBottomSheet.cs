using Uno.UI.Toolkit;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Uno.Material.Controls
{
	[TemplateVisualState(GroupName = __sheetStateGroup, Name = __closedState)]
	[TemplateVisualState(GroupName = __sheetStateGroup, Name = __openedState)]
	[TemplatePart(Name = BackdropGrid, Type = typeof(Grid))]
	public partial class ModalBottomSheet : Control
	{
		private const string __sheetStateGroup = "SheetStates";
		private const string __closedState = "Closed";
		private const string __openedState = "Opened";
		public const string BackdropGrid = "Part_Backdrop";
		private Grid _backdrop;

		public ModalBottomSheet()
		{
			DefaultStyleKey = typeof(ModalBottomSheet);
		}

		protected override void OnApplyTemplate()
		{
			if (IsEnabled)
			{
				VisualStateManager.GoToState(this, "Normal", true);
			}
			else
			{
				VisualStateManager.GoToState(this, "Disabled", true);
			}

			_backdrop = (Grid)GetTemplateChild(BackdropGrid);
			_backdrop.PointerPressed += ToggleSheet;

			base.OnApplyTemplate();
		}

		private void UpdateVisualStates(bool useTransitions)
		{
			if (IsOpened)
			{
				VisualStateManager.GoToState(this, __openedState, useTransitions);
			}
			else
			{
				VisualStateManager.GoToState(this, __closedState, useTransitions);
			}
		}

		private void ToggleSheet(object d, RoutedEventArgs e)
		{
			IsOpened = !IsOpened;
		}

		#region IsOpened
		public bool IsOpened
		{
			get { return (bool)GetValue(IsOpenedProperty); }
			set { SetValue(IsOpenedProperty, value); }
		}

		public static readonly DependencyProperty IsOpenedProperty =
			DependencyProperty.Register("IsOpened", typeof(bool), typeof(ModalBottomSheet), new PropertyMetadata(false, OnIsOpenedChanged));

		private static void OnIsOpenedChanged(object d, DependencyPropertyChangedEventArgs e)
		{
			var sheet = d as ModalBottomSheet;
			sheet?.UpdateVisualStates(true);
		}
		#endregion

		#region Content, ContentTemplate
		public object Content
		{
			get { return (object)GetValue(ContentProperty); }
			set { SetValue(ContentProperty, value); }
		}

		public static readonly DependencyProperty ContentProperty =
			DependencyProperty.Register("Content", typeof(object), typeof(ModalBottomSheet), new PropertyMetadata(null));

		public DataTemplate ContentTemplate
		{
			get { return (DataTemplate)GetValue(ContentTemplateProperty); }
			set { SetValue(ContentTemplateProperty, value); }
		}

		public static readonly DependencyProperty ContentTemplateProperty =
			DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(ModalBottomSheet), new PropertyMetadata(null));
		#endregion
	}
}
