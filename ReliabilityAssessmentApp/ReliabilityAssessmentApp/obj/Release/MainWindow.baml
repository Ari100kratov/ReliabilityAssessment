   M S B A M L   `   `   `  ���� S  OReliabilityAssessmentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ReliabilityAssessmentAppReliabilityAssessmentApp  h dDevExpress.Xpf.ThemeEditor.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49awUclr-namespace:DevExpress.Xpf.ThemeEditor.UI;assembly=DevExpress.Xpf.ThemeEditor.v17.1DevExpress.Xpf.ThemeEditor.UI )    #ReliabilityAssessmentApp.MainWindow   f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   c _DevExpress.Xpf.Charts.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  a ]DevExpress.Xpf.Core.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  c _DevExpress.Xpf.Ribbon.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W	 SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    	 R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 
   	 @d2http://schemas.microsoft.com/expression/blend/2008 
   	 Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006 
   	 8local&clr-namespace:ReliabilityAssessmentApp 
   	 <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  ^UIUclr-namespace:DevExpress.Xpf.ThemeEditor.UI;assembly=DevExpress.Xpf.ThemeEditor.v17.1    � Title$T  NСтатическая обработка данных о надежности��$
��1000��$
��1400��.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ���  � ColumnDefinitions �� $
��Auto ��� �� �� �� $
��auto �.+��� $��0��$��3��$��1�� �� Orientation$ 
Horizontal=�.+��� $8��2Кол-во знаков после запятой��$��16(�$��0,5,5,5q�%  DevExpress.Xpf.Editors.SpinEdit  -     Name$ seRound��&   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$
 none  � ToolTip$� �Используется для отображения результатов. Проводимые рассчеты проводятся без округления��%  DevExpress.Xpf.Editors.BaseEdit   AllowNullInput .     Value$ 2~�$��60��$��16(�$��5,5,10,5q�	   IsFloatValue	 .  
   MaxValue$	
 100X�   MinValue$ 0X��� $��Разделитель��$��16(�$��5,5,5,5q�%  DevExpress.Xpf.Editors.TextEdit  -     Name$ teSeparator��$
 none $s mРазделитель между введенными числами. По умолчанию 'Пробел'��$��50��$��5q�&   DevExpress.Xpf.Core.SimpleButton  -     Name$ sbLoadFromFile��$5��/Загрузить данные из файла��$��5q�$
 None $��14(�  -   $ teInput��$
 none $��1��$��5��$��1��$��40�� �� 
LineHeight$ 6��$��14(�  -   $ sbStart��$��1��$
 None $��Запуск��$��6�� �� 	ClickMode$ Press=�
���   �#��� ��$��14(�$
��Bold"��� -    ��Name$ lblLess��$	��K-1��$��Center=�$��Center=�$��2��$��1��$��20(�$
��Bold"��� -   $ lblMain��$��K��$��Center=�$��Center=�$��2��$��2��$��20(�$
��Bold"��� -   $ lblMore��$	��K+1��$��Center=�$��Center=�$��2��$��3��$��20(�$
��Bold"�� -	    �Name$ 	pbLoading��$��1��$��4�� � Value$ 70Q�$y�	Collapsed=� � IsIndeterminate .   � Maximum$
 1000Q��� -
    ��Name$ 	tbLoading��$
��100%��$��20(�$��1��$��4��$y�	Collapsed=�$��Center=�$��Center=��� $%��Вариационный ряд��$��3��$��2�� J� RenderTransformOrigin$ 0.5,0.5&�$��5q�$��Center=�$��Center=�$
��Bold"�$��18(� � LayoutTransform ��  �� Angle$	 -90Q��� $+��%Гистограмма выборки��$��5��$ 0.5,0.5&�$��5q�$��Center=�$��Center=�$
��Bold"�$��18(� �� $	 -90Q��� $+��%Гистограмма функции��$��6��$ 0.5,0.5&�$��5q�$��Center=�$��Center=�$
��Bold"�$��18(� �� $	 -90Q�%  DevExpress.Xpf.Grid.GridControl  -     Name$ gcSeriesLess��$��1��$��4��)  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�$	��150��$ Office2019Black    View #	  DevExpress.Xpf.Grid.TableView	  &
   DevExpress.Xpf.Grid.DataViewBase 
  AllowEditing .  &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .   	  	AutoWidth .    Columns. $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase    	FieldName$  Number��$  DevExpress.Xpf.Grid.BaseColumn!   Header)  #DevExpress.Xpf.Core.ObjectConverter$	! № "   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$" 40   $  Bounds��$! Интервал   $  MidIntervalR��$)! #Середина интервала   $  HitCount��$! Частота $" 60   $  CumulativeFrequanceR��$+! %Накопленная частота #   Visible# .    $  RelativeFrequanceR��$/! )Относительная частота   $  XMinusXMultiplyFR��$! |x - xср| * fi # .    $  XMinusXMultiplyFSquareR��$! (x-xср)^2·fi # .    $  XMinusXMultiplyCubeR��$! (x-xср)^3·fi # .    $  XMinusXMultiplyFourR��$! (x-xср)^4·fi # .    $  XMultiplyFR��$! xi * fi # .    -   $ gcSeriesMain��$��2��$��4��$	 Row=�$	��150��$
 none  	   .   .   . .   $  Number��$	! № $" 40   $  Bounds��$! Интервал   $  MidIntervalR��$)! #Середина интервала   $  HitCount��$! Частота $" 60   $  CumulativeFrequanceR��$+! %Накопленная частота # .    $  RelativeFrequanceR��$/! )Относительная частота   $  XMinusXMultiplyFR��$! |x - xср| * fi # .    $  XMinusXMultiplyFSquareR��$! (x-xср)^2·fi # .    $  XMinusXMultiplyCubeR��$! (x-xср)^3·fi # .    $  XMinusXMultiplyFourR��$! (x-xср)^4·fi # .    $  XMultiplyFR��$! xi * fi # .    -   $ gcSeriesMore��$��3��$��4��$	 Row=�$	��150��$
 none  	   .   .   . .   $  Number��$	! № $" 40   $  Bounds��$! Интервал   $  MidIntervalR��$)! #Середина интервала   $  HitCount��$! Частота $" 60   $  CumulativeFrequanceR��$+! %Накопленная частота # .    $  RelativeFrequanceR��$/! )Относительная частота   $  XMinusXMultiplyFR��$! |x - xср| * fi # .    $  XMinusXMultiplyFSquareR��$! (x-xср)^2·fi # .    $  XMinusXMultiplyCubeR��$! (x-xср)^3·fi # .    $  XMinusXMultiplyFourR��$! (x-xср)^4·fi # .    $  XMultiplyFR��$! xi * fi # .  �� $��3��$��1��$ 
Horizontal=�.+��� $ Vertical=�$��5q�$��Center=�.+��� $%��Ширина интервала��$��16(��� $/��)Количество интервалов��$��16(��� $+��%Количество инверсий��$��16(��� $ Vertical=�$��5q�$��Center=�.+��� -   $ lblIntervalSizeLess��$��00��$��16(�#��� ��$
��Bold"��� -   $ lblIntervalCountLess��$��00��$��16(�#��� ��$
��Bold"��� -   $ lblInversionCountLess��$��00��$��16(�#��� ��$
��Bold"��� $��3��$��2��$ 
Horizontal=�.+��� $ Vertical=�$��5q�$��Center=�.+��� $%��Ширина интервала��$��16(��� $/��)Количество интервалов��$��16(��� $+��%Количество инверсий��$��16(��� $ Vertical=�$��5q�$��Center=�.+��� -   $ lblIntervalSizeMain��$��00��$��16(�#��� ��$
��Bold"��� -   $ lblIntervalCountMain��$��00��$��16(�#��� ��$
��Bold"��� -   $ lblInversionCountMain��$��00��$��16(�#��� ��$
��Bold"��� $��3��$��3��$ 
Horizontal=�.+��� $ Vertical=�$��5q�$��Center=�.+��� $%��Ширина интервала��$��16(��� $/��)Количество интервалов��$��16(��� $+��%Количество инверсий��$��16(��� $ Vertical=�$��5q�$��Center=�.+��� -   $ lblIntervalSizeMore��$��00��$��16(�#��� ��$
��Bold"��� -   $ lblIntervalCountMore��$��00��$��16(�#��� ��$
��Bold"��� -   $ lblInversionCountMore��$��00��$��16(�#��� ��$
��Bold"�(  "DevExpress.Xpf.Charts.ChartControl  -   $  Name$$ chartSampleLess��$
 none $��5��$��1��%   AnimationMode$% OnDataChanged=�$��Visible=�&   Annotations& &   DevExpress.Xpf.Charts.Annotation  -   '  Name$' chartLessAnnotation��$y�	Collapsed=�(  "DevExpress.Xpf.Charts.ChartElement(   Width$	( 350Q�)   	LabelMode) . *   RuntimeMoving* . +   RuntimeResizing+ . ,   RuntimeRotation, . -   RuntimeAnchoring- . .   ContentTemplate. �� .R��� .+��� $ tbShowResultLess��$
��Wrap=�$����Данный вариационный ряд считаем лучшим, т.к. количество инверсий минимально, а количество интервалов наибольшее���� $J��D*Двойной щелчок - показать результаты��$��Italic$�/   ShapePosition/ ,  &DevExpress.Xpf.Charts.RelativePosition  0   ConnectorLength$	0 250Q�1   Angle$1 0Q�2   Diagram.2 '  !DevExpress.Xpf.Charts.XYDiagram2D  #  DevExpress.Xpf.Charts.Diagram3   Series.3 1  +DevExpress.Xpf.Charts.BarSideBySideSeries2D  "  DevExpress.Xpf.Charts.Series4   ArgumentDataMember$4 Argument��5   ValueDataMember$5 Value��+  %DevExpress.Xpf.Charts.BarSeries2DBase6   BarWidth$	6 0.9Q�&   DevExpress.Xpf.Charts.XYSeries2D7   CrosshairLabelPattern$7 
{V:#.0000}��(  "DevExpress.Xpf.Charts.LineSeries2D  $4 Argument��$5 Value��$7 
{V:#.0000}��  -   $$ chartSampleMain��$
 none $��5��$��2��$% OnDataChanged=�$��Visible=�&   -   $' chartMainAnnotation��$y�	Collapsed=�$	( 350Q�) . * . + . , . - . . �� .R��� .+��� $ tbShowResultMain��$
��Wrap=�$����Данный вариационный ряд считаем лучшим, т.к. количество инверсий минимально, а количество интервалов наибольшее���� $J��D*Двойной щелчок - показать результаты��$��Italic$�/   $	0 250Q�$1 0Q�.2   .3   $4 Argument��$5 Value��$	6 0.9Q�  $4 Argument��$5 Value��  -   $$ chartSampleMore��$
 none $��5��$��3��$% OnDataChanged=�$��Visible=�&   -   $' chartMoreAnnotation��$y�	Collapsed=�$	( 350Q�) . * . + . , . - . . �� .R��� .+��� $ tbShowResultMore��$
��Wrap=�$����Данный вариационный ряд считаем лучшим, т.к. количество инверсий минимально, а количество интервалов наибольшее���� $J��D*Двойной щелчок - показать результаты��$��Italic$�/   $	0 250Q�$1 0Q�.2   .3   $4 Argument��$5 Value��$	6 0.9Q�  $4 Argument��$5 Value��  -   $$ chartFunctionLess��$
 none $��6��$��1��$% OnDataChanged=�$��Visible=�.2   .3   $4 Argument��8   LabelsVisibility8 . $5 Value��$	6 0.9Q�  -   $$ chartFunctionMain��$
 none $��6��$��2��$% OnDataChanged=�$��Visible=�.2   .3   $4 Argument��$5 Value��8 . $	6 0.9Q�  -   $$ chartFunctionMore��$
 none $��6��$��3��$% OnDataChanged=�$��Visible=�.2   .3   $4 Argument��$5 Value��8 . $	6 0.9Q�