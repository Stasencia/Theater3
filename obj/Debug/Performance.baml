   M S B A M L   `   `   `  ����B  >Theater, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TheaterTheater  5   	       Theater.Performance   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Theater     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$   Представление��5	   	   $	��900��6   $	��800��6,   $��Century Gothic)�68    � 	Resources 5
         
MonthStyle �� 
TargetType # MaterialDesignRaisedLightButton �� BasedOn+  %MaterialDesignThemes.Wpf.RippleAssist �� Property �� Value ��Name �� TextAlignment  	DateStyle �� 
TargetType	 �� Path
 �� RelativeSource �� AncestorType J� Opacity��%�  &	        7  &	 �    7  �� 5   
   " ��6#   8   .�5      ��  �@ Feedback �	#DD0000006Y   �� 5       � ��
 �����6;   �� 5       � ��
 �   �6;   �� 5       � ��
 �����6A   �� 5       � ��$ 0,0,10,0q�6'   6:   �� 5       � ��$ 95��6&   63   �� 5       � ��$ 45��6'   64   �� 5       � �� 5      �� 5      .R�5      �� $ Description��6$   $ Center=�6J   ��69   �� 6c   5      5      5      �� 5   
   " ��6"   8   .�5      ��  �@ Feedback 6E   Z� 6X   �� 5       � ��
 �����6;   �� 5       � ��
 �   �6;   �� 5       � ��
 �   �6<   �� 5        � ��$
 Auto��6'   66   �� 5!       � �� 5"      �� 5#      " ��6&   .R�5$      �� 
�������$��1q�64   ._�5%      � .+�5&   "   �� ��6(   �� $'	 !(local:DayButtonProperties.Image)�
 �� *FindAncestor+" ��6�   �� 5'   "   
������� 68   �� $.	 ((local:DayButtonProperties.ImageOpacity)�
 �� *FindAncestor+" ��6�   �� 5(   "   ��6(   �� $%	 (local:DayButtonProperties.Day)�
 �� *FindAncestor+" ��6�   �� 5)   "   $��Bottom=�6�   
���������6(   �� $&	  (local:DayButtonProperties.Time)�
 �� *FindAncestor+" �� 6�   �� $-	 '(local:DayButtonProperties.TextOpacity)�
 �� *FindAncestor+" ��6l  5*      5+      5,      5.      5/      50      .��52      )  #MaterialDesignThemes.Wpf.DialogHost     DialogContentTemplate 53   
   �� 54       �� DataType$ local: TextBlock��6   .R�55      � ��6   �� *ActualWidth+ �� ElementName$ MainGrid��.+�56      � $��20q�6    � RowDefinitions 57      �� 58      $��* �6,   69   �� 59      $��* �6,   69   .+�5;      �� $
��Wrap=�6$   $��0��6N   $��0,0,0,10q�6[   ��68   �� *Text+6[   �� 5<      -   5        $��1��5<   !   .��6B   Закрыть6K   5=      5>      5?      .��5A   
   �� .��5B      �� .+�5C      �� -   5         ��Name$ Banner��5C      $.��(bin/Debug/images_afisha/reverse-full.jpg��6(   $��UniformToFill=�6Z   6t   �� 5D      -   5         ��Name$ PerfAltName��5D      $��18(�6-   $
��Bold"�6;   .��6M   ��По книгам Льюиса Кэрролла «Алиса в Стране чудес» и «Алиса в Зазеркалье»6�   �� 5E      .��5F      �� -   5        $ 	Smallinfo��5F       -+музыка: Владимир Баскин�� 6K   JHлибретто: Николай Голь, Софья Журавлева�� 6~   FDрежиссер-постановщик: Марина Швыдкая6�   5G      �� 5H      -   5        $ Duration��5H      $
��Bold"�6*   $��Italic$�6<   .��6O   0.Продолжительность: 2 часа6j   �� 5I      -   5        $ AgeRestr��5I      $
��Bold"�6*   $��Italic$�6<   .��6O   1/Возрастное ограничение: 6+6k   �� 5J      .��5K      �� -   5        $ Decsription��5K       $
��Wrap=�65   ��Эта постановка — настоящее буйство фантазии, где драматургическая основа сюжета получила пластическое воплощение, а великолепную музыку дополняют зрелищные декорации. В спектакле много чудес и превращений — ведь это же сказка. Постановка изобилует причудливой игрой света, видеоэффектами и иллюзиями и передает настроение оригинального произведения Кэрролла и его своеобразную логику. Или её отсутствие — кому как нравится.5M      5N      �� 5O      -   5         ��Name$ month_panel��5O      $��20q�62    �� Orientation$ 
Horizontal=�6>   $��Center=�6W   5P      A� 5Q      -	   5         A�Name$ Dates_panel1��5Q       A� Columns$ 7��64    A� Rows$ 6��6@   $��
20,0,20,20q�6I   $	��750��6]   5S      5T      5U      5V      5W      