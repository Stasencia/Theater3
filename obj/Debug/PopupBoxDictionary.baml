   M S B A M L   `   `   `  ����B  >Theater, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TheaterTheater  5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null{Sclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf#MaterialDesignThemes.Wpf.Converters 5      I:clr-namespace:ControlzEx;assembly=MaterialDesignThemes.Wpf
ControlzEx 5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source �� 
TargetType    MaterialDesignPopupBoxButton �� Property �� Value  MaterialDesignBody �� 
TargetType'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   Name   Transitions%  System.Windows.VisualTransition	   GeneratedDuration	
   To   GeneratedEasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode   States   System.Windows.VisualState   Name   
Storyboard �� 
TargetName �� TargetProperty	 W� To g� Duration ��Name J� Opacity  BrushRoundConverter �� 	Converter%  MaterialDesignThemes.Wpf.Ripple J� SnapsToDevicePixels   Feedback   BooleanToVisibilityConverterG  AMaterialDesignThemes.Wpf.Converters.NullableToVisibilityConverter  NullVisibilityConverter # InvertedNullVisibilityConverter   	NullValue   NotNullValue=  7MaterialDesignThemes.Wpf.Converters.BrushRoundConverter'	  !MaterialDesignThemes.Wpf.PackIcon�
  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 
  Kind ' #MaterialDesignPopupBoxToggleContent �� RelativeSource �� AncestorType �� Path'  !MaterialDesignThemes.Wpf.PopupBox  MaterialDesignPopupBox+  %MaterialDesignThemes.Wpf.RippleAssist " MaterialDesignFlatButtonRipple+  %MaterialDesignThemes.Wpf.ShadowAssist � 	Resources 	 MaterialDesignSeparator  �� BasedOn 
 Key!   
IsCentered" d�Name  ToggleButtonStyle#   ToggleContent$   ToggleContentTemplate% � Cursor& d� 	IsChecked' �� Mode  ControlzEx.PopupEx(  Name) � HorizontalOffset* � VerticalOffset+ � AllowsTransparency#, � CustomPopupPlacementCallback- � PlacementTarget. �� ElementName#  MaterialDesignThemes.Wpf.Card/   PopupContent0   PopupContentTemplate1 �� ClearTypeHint2 � 	Resources3 �� Triggers4 P� Property5 P� Value  MaterialDesignToolPopupBox   MaterialDesignToolForeground ( $MaterialDesignToolForegroundPopupBox 1 -MaterialDesignMultiFloatingActionPopupBoxIcon - )MaterialDesignMultiFloatingActionPopupBox  PrimaryHueMidBrush   PrimaryHueMidForegroundBrush  MaterialDesignToolTip6 �Name7   From8   
Storyboard9 W� EasingFunction2  ,System.Windows.Media.Animation.QuadraticEase: J� 	CacheMode; A�Name< J� Effect9  3MaterialDesignThemes.Wpf.Converters.ShadowConverter=   Instance> �� 	Converter? J� Clip@ J� RenderTransformOriginA �� AngleB �� 
TargetName0  *MaterialDesignThemes.Wpf.PopupBoxPopupModeC   	MouseOverD �� ValueE �� BindingF   MouseOverEager-  'System.Windows.Media.Animation.SineEaseG � ToolTipH ^� 	PlacementI ��NameJ   ToggleCheckedContent#K   ToggleCheckedContentTemplate / +MaterialDesignFloatingActionMiniLightButtonL N� EnterActions  OpenM N� ExitActions 	 CloseN ]� 
ConditionsO �� PropertyP �� ValueQ �� Triggers 2 .MaterialDesignMultiFloatingActionLightPopupBox  PrimaryHueLightBrush " PrimaryHueLightForegroundBrush 1 -MaterialDesignMultiFloatingActionDarkPopupBox  PrimaryHueDarkBrush ! PrimaryHueDarkForegroundBrush 3 /MaterialDesignMultiFloatingActionAccentPopupBox  SecondaryAccentBrush " SecondaryAccentForegroundBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      localclr-namespace:Theater  5      ;wpf1http://materialdesigninxaml.net/winfx/xaml/themes  5      b
convertersSclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf  5      I
controlzEx:clr-namespace:ControlzEx;assembly=MaterialDesignThemes.Wpf  5        5	      �� 5
   
   $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6   �� 5   
   $d ^pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Menu.xaml?�6   �� 5   
   $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ToolTip.xaml?�6   %4)  &	        7  7  &	 E    &	 X    &	 k    &	 �    &	 �   &	 Y    7  7 	 7  7   &	 �    7  &	 6    7  &	 �   &	 :    7  7  7  7  7  7  7  7  7  7  7  &	 �&    7  &	 2'    7  &	 �'    7  �� 5      " ��6   .�5   
   ��  � ��$ Bottom=�65   �� 5   
    � ��$
 Left=�67   �� 5   
    � ��$ 
16 0 16 16q�6$   �� 5   
    � ��# �  6'   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �  5        5      $ CommonStates��6/    5   "     5   &   $	 0:0:0.3D�67   $
 Normal��6S    5   *     5   .   $ EaseOut=�69   5   '   . 5!   "     $ Normal��6.     5"   "   $ 	MouseOver��6.   . 5#   &   �� .��5$   *   W� $ MouseOverBorder��6:   $ Opacity�6b   $	 0.1X�6�   $ 0D�6�   5%   '   5&   #     5'   "   $ Disabled��6.   . 5(   &   �� .��5)   *   W� $ Opacity�6:   $
 0.48X�6^   $ 0D�6h   5*   '   5+   #   5,      .+�5.      �� $ MouseOverBorder��6!   $ 0Q�6:   ��6F   �� *
Foreground+8     5/      |�.  $��48��51   %   #��z��52   %   #��z��53   %   #��z��54   %   # z 55   %   #��z��56   %   #��z��57   %   #��z��58   %    5/   %   �� *
Foreground+8  58   %   59      5:      5<      5=      �� 5?      6#     5@      6/     5A      $ Visible=�6W   $ 	Collapsed=�6k     5B      6%   	  5D      $ DotsVertical=�6   $��4 0 4 0q�6d   $��24��6u   $��24��6�   ��5E      ��  �� *FindAncestor+$ wpf:PopupBoxL�$ 
Foreground��� 5G      "  6   .�5H   
   ��  �@ ToggleContent8   6*   �� 5I   
    �@ Feedback# �  66   �� 5J   
    � ��$
 Left=�60   �� 5K   
    �@ ShadowDepth$ Depth3=�69   �� 5L   
    � ��$ Normal"�63   �� 5M   
    � ��$ 0 8 0 8q�6$   �� 5N   
    � |� . 6&   �� 5O   
    � �� 5P      �� 5Q      "  6"    5R      ���� 5S      '��       " ��6    8   67   �� 5T      'd�       " d�6    ToggleButtonStyle
 .�5U      ��  � �� 5V   "   �� 5W   &   " d�66   .R�5X   *     #��z��65   #��z��6Y   |�.  }�.  ! . #��z��5[   5   #��z��5\   5   #��z��5]   5   # z 5^   5   5_   '   5a      5b      5c      .R�5d      � .+�5e      d� $" PART_Toggle��6'   8�� #��z# 5f   '   #��z$ 6Q   $
% Hand��5g   '   #��z��65   $��Center=�6[   #��z��6v   & 5e   g   ��  �� *TemplatedParent+$ IsPopupOpen�$' TwoWay=�5g   v     5i      $( 
PART_Popup��6-   $) 5��5l   -   $* 5��5m   -   $��Custom=�5o   -   $
��Fade=�5p   -   + . ��5j   -   ��  �� *TemplatedParent+$ IsPopupOpen�$' TwoWay=�, 5k   -   ��  �� *TemplatedParent+$ PopupPlacementMethod�- 5n   -   �� $. PART_Toggle��.��5r        #��z/ 6'   #��z0 6P   #���  5s   '   $��15(�5t   '   $��Regular"�5u   '   #��z��5v   '   $1 Enabled=�5w   '   $��5q�5x   '   2 5y   "   ���� 5z   &   '��       " ��6,   8   6@   5{   #   5|      5}      5~      3 5      P� 5�      4 � {�5 .  . �5�      ��  �@J�Opacity$
 0.23Q�68   5�      5�      5�      5�      �� 5�      8    "  6a   .�5�   
   ��  � ��# �  6'   �� 5�   
    � ��$ 4q�6$   5�      �� 5�      8    "  6o   .�5�   
   ��  � �� 6'   ��  �� " �$ (TextElement.Foreground)�5�      	  5�      $
 User=�5�      $��24��6   $��24��6*   ��66   ��  �� *FindAncestor+$ wpf:PopupBoxL�$ 
Foreground��� 5�      "  6   .�5�   
   ��  � ��# �  6'   �� 5�   
    � ��# �  6(   �� 5�   
    � ��# �  6'   �� 5�   
    �@ Feedback
 �����66   �� 5�   
    �@ PlacementMode$ TopAndAlignCentres=�6*   �� 5�   
    �@ 	PopupMode$ MouseOverEager=�6&   �� 5�   
    �@^�	Placement$
 Left=�65   �� 5�   
    �@^�	IsEnabled .  65   �� 5�   
    � ��$
 Left=�60   �� 5�   
    � ��$ 1q�6,   �� 5�   
    �@�Cursor$
 Hand��6#   �� 5�   
    �@ ShadowDepth$ Depth2=�69   �� 5�   
    � |� .  6&   �� 5�   
    � �� 5�      �� 5�      "  6"    5�      ���� 5�      '_�       " _�6    8    �5�      �� 5�   "    � ��$ 	8 10 8 10q�6;   5�      �� 5�      'd�       " d�6    ToggleButtonStyle
 .�5�      ��  � �� 5�   "   �� 5�   &   " d�66   .R�5�   *   � $6 RootGrid��6/   ��6A   Z�  5�   .     5�   2   $ CheckedStates��6C    5�   6     5�   :   $7 *��6K   $
 Checked��6T   .8 5�   >   �� .��5�   B   W� $ ContentRotateTransform��6R   $ Angle�5�   R   $ 45X�5�   R   $ 0:0:0.1D�5�   R   9 5�   F     5�   J   $ 	EaseInOut=�6X   5�   C   5�   ?   5�   ;     5�   :   $7 Checked��6K   $
 	Unchecked��6Z   .8 5�   >   �� .��5�   B   W� $ ContentRotateTransform��6R   $ Angle�5�   R   $ 0X�5�   R   $ 0:0:0.1D�5�   R   9 5�   F     5�   J   $ 	EaseInOut=�6X   5�   C   5�   ?   5�   ;   . 5�   6     Checked��. 5�   :   �� .��5�   >   W� $ ContentRotateTransform��6N   $ Angle�5�   N   $ 45X�5�   N   $ 0D�5�   N   5�   ;   5�   7     5�   6   	Unchecked��. 5�   :   �� .��5�   >   W� $ ContentRotateTransform��6N   $ Angle�5�   N   $ 0X�5�   N   $ 0D�5�   N   5�   ;   5�   7   5�   3   .+�5�   .   �� : 6?   ��  �� *Self+$" (wpf:ShadowAssist.CacheMode)�.u�5�   2   A� $; border��5�   :   #��z��5�   :   #��z��6^   #��z��6�   < 5�   :   ��  �� *FindAncestor+$ wpf:PopupBoxL�$$ (wpf:ShadowAssist.ShadowDepth)�#> Z= 5�   3   5�   /     5�   .   |�.  }�. ! . #��z��5�   9   #��z��5�   9   #��z��5�   9   # z 5�   9   ? 5�   9   �� $. GeometryEllipse��$ RenderedGeometry�.��5�   2   �� #��z��6A   #��z��6e   $@ .5,.5&�5�   A   |�.  z�5�   6   �� 5�   :   ContentRotateTransform��$A 0Q�6j   5�   3   5�   /   5�   +   3 5�   *   P� 5�   .   4 � {�5 .  . �5�   2   ��  �@J�Opacity$
 0.23Q�6L   5�   /   P� 5�   .   4 �@J�IsMouseOver5 . . �5�   2   �� $B border��69    �@ Darken . 6p   5�   /   �� 5�   .   #D ZC 5�   :   E 5�   :   ��  �� *FindAncestor+$ wpf:PopupBoxL�$ 	PopupMode�.a�5�   2   �� $B RootGrid��69    � ��
 ���� 6e   5   /   �� 5  .   #D ZF 5  :   E 5  :   ��  �� *FindAncestor+$ wpf:PopupBoxL�$ 	PopupMode�.a�5  2   �� $B RootGrid��69    � ��
 ���� 6e   5  /   5  '   5     5	     �� 5
     Open
 .��5     W� $ PART_PopupContentControl��6.   $ Opacity�6_   $ 1X�5  .   $ 0:0:0.1D�65   9 5  "     5  &   $ 	EaseInOut=�6/   5     W� 5     $ ExplicitToggleContent��6.   $ Opacity�6\   $ 0X�5  .   $ 0:0:0.1D�65   9 5  "     5  &   $ 	EaseInOut=�6/   5     W� 5     $" ExplicitToggleCheckedContent��6.   $ Opacity�6c   $ 1X�5  .   $ 0:0:0.1D�65   9 5  "     5  &   $ 	EaseInOut=�6/   5     5     �� 5     	Close
 .��5     W� $ PART_PopupContentControl��6.   $ Opacity�6_   $ 0:0:0.8D�5   .   9 5!  "     5"  &   $ 	EaseInOut=�6/   5$     W� 5%     $ ExplicitToggleContent��6.   $ Opacity�6\   $ 1X�5&  .   $ 0:0:0.1D�65   9 5'  "     5(  &   $ 	EaseInOut=�6/   5*     W� 5+     $" ExplicitToggleCheckedContent��6.   $ Opacity�6c   $ 0X�5,  .   $ 0:0:0.1D�65   9 5-  "     5.  &   $ 	EaseInOut=�6/   50     51     52     .R�53     � .+�54     d� $" PART_Toggle��6'   8�� $
% Hand��56  '   #��z��57  '   #��z��58  '   #��z��59  '   #��z��5:  '   $��Stretch=�5;  '   $��Stretch=�5<  '   #G zG 5=  '   & 55  '   ��  �� *TemplatedParent+$ IsPopupOpen�$' TwoWay=�H 5>  '   ��  �� *FindAncestor+$ wpf:PopupBoxL�$  (ToolTipService.Placement)�.��5?     � .+�5@  "   �� $I StandardToggleContent��61   #��z# 6P   #��z$ 6z   |�.  y�5A  1   �� *ToggleCheckedContent+8  6�   �� 5B  "   $I ExplicitToggleContent��61   #��z# 6P   #��z$ 6z   |�.  y�5C  1   �� *ToggleCheckedContent+8  6�   �� 5D  "   $"I ExplicitToggleCheckedContent��61   #��zJ 6W   #��zK 6�   $ 0Q�5F  1   $@ .5,.5&�5G  1   |�.  y�5E  1   �� *ToggleCheckedContent+8  z�5I  &   �� 5J  *   $	A -45Q�6:   5L  #   5M     5N       5O     $( 
PART_Popup��6-   ��.  $��Custom=�5S  +   $
��None=�5T  +   + . , 5Q  +   ��  �� *TemplatedParent+$ PopupPlacementMethod�- 5R  +   �� $. PART_Toggle��.��5V     � .+�5[  "   �� 
�������$ 0.002Q�6<   �� 5\  "   $I PART_PopupContentControl��5_  =   #��z/ 5\  1   #��z0 6Z   $��5q�5^  1   $��8q�6<   $ 0Q�5_  1   y�5]  1   �� *	IsEnabled+8  2 5`  &   �� 5a  *   �� 5b  .   '_�       " _�64   8   �5c  2   �� 5d  6    � ��$ 	16 4 16 4q�6O   5f  /   �� 5g  .   '��       " ��64   8   �5h  2   �� 5i  6    �@^�	Placement 6a   ��  �� *FindAncestor+$ wpf:PopupBoxL�$  (ToolTipService.Placement)��� 5j  6    �@^�InitialShowDelay$ 0��6h   �� 5k  6    � ��$ 4q�6O   5m  /   5n  +   5p  #   5q     5r     5s     3 5t     P� 5u     4 �@ IsPopupOpen5 . . �5v     �� $B 
PART_Popup��6%    � �� . 6O   L 5w     �� 5x  "   8�� 62   M 5z     �� 5{  "   8��	 62   5}     ]� 5~     N 5     �� 5�  "   O �@ 	PopupMode$P MouseOverEager=�6A   �� 5�  "   O �@J�	IsVisibleP . 6A   ./�5�     �� $B 
PART_Popup��6%    � �� . 6O   5�     5�     5�     �� 5�  
    �@ ToggleContent8 
 6*   Q 5�  
   P� 5�     4 �@ UnfurlOrientation$5 
Horizontal=�63   . �5�     ��  �@^�	Placement$ Custom=�6=   5�     5�     �� 5�     "  6   8    .�5�  
   ��  � ��# �  6'   �� 5�  
    � ��# �  6(   �� 5�  
    � ��# �  6'   5�     �� 5�     "  6   8    .�5�  
   ��  � ��# �  6'   �� 5�  
    � ��# �  6(   �� 5�  
    � ��# �  6'   5�     �� 5�     "  6   8    .�5�  
   ��  � ��# �  6'   �� 5�  
    � ��# �  6(   �� 5�  
    � ��# �  6'   5�     5�     