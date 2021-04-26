using Uno.UI.Toolkit;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Uno.Material.Controls
{
	[TemplateVisualState(GroupName = __sheetStateGroup, Name = __collapsedState)]
	[TemplateVisualState(GroupName = __sheetStateGroup, Name = __expandedState)]
	[TemplateVisualState(GroupName = __collapsedStateGroup, Name = __collapsedState)]
	[TemplateVisualState(GroupName = __collapsedStateGroup, Name = __collapsedContentState)]
	[TemplateVisualState(GroupName = __collapsedStateGroup, Name = __minimalContentState)]
	[TemplatePart(Name = CollapsedContentButtonName, Type = typeof(Button))]
	[TemplatePart(Name = ExpandedContentButtonName, Type = typeof(Button))]
	[TemplatePart(Name = MinimalCollapsedContentButtonName, Type = typeof(Button))]
	[TemplatePart(Name = CollapsedContentPresenterName, Type = typeof(ElevatedView))]
	[TemplatePart(Name = MinimalCollapsedContentPresenterName, Type = typeof(ElevatedView))]
	public partial class ExpandingBottomSheet : Control
	{
		private const string CollapsedContentButtonName = "Part_CollapsedContentButton";
		private const string ExpandedContentButtonName = "Part_ExpandedContentButton";
		private const string MinimalCollapsedContentButtonName = "Part_MinimalCollapsedContentButton";
		private const string CollapsedContentPresenterName = "Part_CollapsedContentPresenter";
		private const string MinimalCollapsedContentPresenterName = "Part_MinimalCollapsedContentPresenter";

		private const string __sheetStateGroup = "SheetStates";
		private const string __collapsedState = "Collapsed";
		private const string __expandedState = "Expanded";

		private const string __collapsedStateGroup = "CollapsedStates";
		private const string __collapsedContentState = "CollapsedContent";
		private const string __minimalContentState = "MinimalContent";

		private Button _collapsedContentButton;
		private Button _expandedContentButton;
		private Button _minimalCollapsedContentButton;
		private ElevatedView _collapsedContentPresenter;
		private ElevatedView _minimalCollapsedContentPresenter;

		private bool _loaded = false;
		private bool _templateApplied = false;

		public ExpandingBottomSheet()
		{
			DefaultStyleKey = typeof(ExpandingBottomSheet);
			Loaded += OnLoaded;
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			_loaded = true;

			if (_loaded && _templateApplied)
			{
				SetSizeProperties();
			}
		}

		private void SetSizeProperties()
		{
			PresenterHeight = ActualHeight;
			CollapsedPresenterWidth = _collapsedContentPresenter.ActualWidth;
			MinimalCollapsedPresenterWidth = _minimalCollapsedContentPresenter.ActualWidth;
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

			_collapsedContentButton = (Button)GetTemplateChild(CollapsedContentButtonName);
			_expandedContentButton = (Button)GetTemplateChild(ExpandedContentButtonName);
			_minimalCollapsedContentButton = (Button)GetTemplateChild(MinimalCollapsedContentButtonName);
			_collapsedContentPresenter = (ElevatedView)GetTemplateChild(CollapsedContentPresenterName);
			_minimalCollapsedContentPresenter = (ElevatedView)GetTemplateChild(MinimalCollapsedContentPresenterName);

			if (_collapsedContentButton != null)
			{
				_collapsedContentButton.Click += ToggleSheet;
			}

			if (_expandedContentButton != null)
			{
				_expandedContentButton.Click += ToggleSheet;
			}

			if (_minimalCollapsedContentButton != null)
			{
				_minimalCollapsedContentButton.Click += ToggleSheet;
			}		

			base.OnApplyTemplate();

			_templateApplied = true;

			if (_loaded && _templateApplied)
			{
				SetSizeProperties();
			}
		}

		private void UpdateSheetVisualStates(bool useTransitions)
		{
			if (IsExpanded)
			{
				VisualStateManager.GoToState(this, __expandedState, useTransitions);
			}
			else
			{
				VisualStateManager.GoToState(this, __collapsedState, useTransitions);
			}
		}

		private void UpdateCollapsedVisualStates(bool useTransitions)
		{
			if (IsMinimalSheet)
			{
				VisualStateManager.GoToState(this, __minimalContentState, useTransitions);
			}
			else
			{
				VisualStateManager.GoToState(this, __collapsedContentState, useTransitions);
			}
		}

		private void ToggleSheet(object d, RoutedEventArgs e)
		{
			IsExpanded = !IsExpanded;
		}

		#region IsExpanded
		public bool IsExpanded
		{
			get { return (bool)GetValue(IsExpandedProperty); }
			set { SetValue(IsExpandedProperty, value); }
		}

		public static readonly DependencyProperty IsExpandedProperty =
			DependencyProperty.Register("IsExpanded", typeof(bool), typeof(ExpandingBottomSheet), new PropertyMetadata(false, OnIsExpandedChanged));

		private static void OnIsExpandedChanged(object d, DependencyPropertyChangedEventArgs e)
		{
			var sheet = d as ExpandingBottomSheet;
			sheet?.UpdateSheetVisualStates(true);
		}
		#endregion

		#region CollapsedContent, CollapsedContentTemplate and MinimalCollapsedContentTemplate
		public object CollapsedContent
		{
			get { return (object)GetValue(CollapsedContentProperty); }
			set { SetValue(CollapsedContentProperty, value); }
		}

		public static readonly DependencyProperty CollapsedContentProperty =
			DependencyProperty.Register("CollapsedContent", typeof(object), typeof(ExpandingBottomSheet), new PropertyMetadata(null));

		public DataTemplate CollapsedContentTemplate
		{
			get { return (DataTemplate)GetValue(CollapsedTemplateContentProperty); }
			set { SetValue(CollapsedTemplateContentProperty, value); }
		}

		public static readonly DependencyProperty CollapsedTemplateContentProperty =
			DependencyProperty.Register("CollapsedContentTemplate", typeof(DataTemplate), typeof(ExpandingBottomSheet), new PropertyMetadata(null));

		public DataTemplate MinimalCollapsedContentTemplate
		{
			get { return (DataTemplate)GetValue(MinimalCollapsedContentTemplateProperty); }
			set { SetValue(MinimalCollapsedContentTemplateProperty, value); }
		}

		public static readonly DependencyProperty MinimalCollapsedContentTemplateProperty =
			DependencyProperty.Register("MinimalCollapsedContentTemplate", typeof(DataTemplate), typeof(ExpandingBottomSheet), new PropertyMetadata(null));
		#endregion

		#region ExpandedContent, ExpandedContentTemplate and ExpandedHeaderContentTemplate
		public object ExpandedContent
		{
			get { return (object)GetValue(ExpandedContentProperty); }
			set { SetValue(ExpandedContentProperty, value); }
		}

		public static readonly DependencyProperty ExpandedContentProperty =
			DependencyProperty.Register("ExpandedContent", typeof(object), typeof(ExpandingBottomSheet), new PropertyMetadata(null));

		public DataTemplate ExpandedContentTemplate
		{
			get { return (DataTemplate)GetValue(ExpandedContentTemplateProperty); }
			set { SetValue(ExpandedContentTemplateProperty, value); }
		}

		public static readonly DependencyProperty ExpandedContentTemplateProperty =
			DependencyProperty.Register("ExpandedContentTemplate", typeof(DataTemplate), typeof(ExpandingBottomSheet), new PropertyMetadata(null));

		public DataTemplate ExpandedHeaderContentTemplate
		{
			get { return (DataTemplate)GetValue(ExpandedHeaderContentTemplateProperty); }
			set { SetValue(ExpandedHeaderContentTemplateProperty, value); }
		}

		public static readonly DependencyProperty ExpandedHeaderContentTemplateProperty =
			DependencyProperty.Register("ExpandedHeaderContentTemplate", typeof(DataTemplate), typeof(ExpandingBottomSheet), new PropertyMetadata(null));
		#endregion

		#region PresenterHeight, CollapsedPresenterWidth  and MinimalCollapsedPresenterWidth
		public double PresenterHeight
		{
			get { return (double)GetValue(PresenterHeightProperty); }
			set { SetValue(PresenterHeightProperty, value); }
		}

		public static readonly DependencyProperty PresenterHeightProperty =
			DependencyProperty.Register("PresenterHeight", typeof(double), typeof(ExpandingBottomSheet), new PropertyMetadata(0d, null));

		public double CollapsedPresenterWidth
		{
			get { return (double)GetValue(CollapsedPresenterWidthProperty); }
			set { SetValue(CollapsedPresenterWidthProperty, value); }
		}

		public static readonly DependencyProperty CollapsedPresenterWidthProperty =
			DependencyProperty.Register("CollapsedPresenterWidth", typeof(double), typeof(ExpandingBottomSheet), new PropertyMetadata(0d, null));

		public double MinimalCollapsedPresenterWidth
		{
			get { return (double)GetValue(MinimalCollapsedPresenterWidthProperty); }
			set { SetValue(MinimalCollapsedPresenterWidthProperty, value); }
		}

		public static readonly DependencyProperty MinimalCollapsedPresenterWidthProperty =
			DependencyProperty.Register("MinimalCollapsedPresenterWidth", typeof(double), typeof(ExpandingBottomSheet), new PropertyMetadata(0d, null));
		#endregion

		#region FullScreenPresenterHeight, CollapsedPresenterWidth  and MinimalCollapsedPresenterWidth
		public double FullScreenPresenterHeight
		{
			get { return (double)GetValue(FullScreenPresenterHeightProperty); }
			set { SetValue(FullScreenPresenterHeightProperty, value); }
		}

		public static readonly DependencyProperty FullScreenPresenterHeightProperty =
			DependencyProperty.Register("FullScreenPresenterHeight", typeof(double), typeof(ExpandingBottomSheet), new PropertyMetadata(400d, null));

		public double FullScreenPresenterWidth
		{
			get { return (double)GetValue(FullScreenPresenterWidthProperty); }
			set { SetValue(FullScreenPresenterWidthProperty, value); }
		}

		public static readonly DependencyProperty FullScreenPresenterWidthProperty =
			DependencyProperty.Register("FullScreenPresenterWidth", typeof(double), typeof(ExpandingBottomSheet), new PropertyMetadata(400d, null));
		#endregion

		#region IsMinimalSheet
		public bool IsMinimalSheet
		{
			get { return (bool)GetValue(IsMinimalSheetProperty); }
			set { SetValue(IsMinimalSheetProperty, value); }
		}

		public static readonly DependencyProperty IsMinimalSheetProperty =
			DependencyProperty.Register("IsMinimalSheet", typeof(bool), typeof(ExpandingBottomSheet), new PropertyMetadata(false, OnIsMinimalChanged));

		private static void OnIsMinimalChanged(object d, DependencyPropertyChangedEventArgs e)
		{
			var sheet = d as ExpandingBottomSheet;
			sheet?.UpdateCollapsedVisualStates(true);
		}
		#endregion
	}
}
