   M S B A M L   `   `   `  ����B  >Theater, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TheaterTheater  5   	       Theater.Afisha   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Theater     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Afisha��5	   	   $	��550��6   $	��800��6%   $��Century Gothic)�61    � 	Resources 5
         
MonthStyle �� 
TargetType # MaterialDesignRaisedLightButton �� BasedOn+  %MaterialDesignThemes.Wpf.RippleAssist �� Property �� Value ��Name �� TextAlignment��%�  &	        7  �� 5   
   " ��6#   8   .�5      ��  �@ Feedback �	#DD0000006Y   �� 5       � ��
 �����6;   �� 5       � ��
 �   �6;   �� 5       � ��
 �����6A   �� 5       � ��$ 0,0,10,0q�6'   6:   �� 5       � ��$ 95��6&   63   �� 5       � ��$ 45��6'   64   �� 5       � �� 5      �� 5      .R�5      �� $ Description��6$   $ Center=�6J   ��69   �� 6c   5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5       $
��183* �6   .+�5"   
   �� $��0��6   
���Gc��6   �� 5#   
   
�������$��Century)�6#   $��30(�68   $��Center=�6F   $��Center=�6c   .��6~   
Афиша6�   �� 5$   
   $��1��6   
�������$��0 1 0 1q�61   ._�5%      �� -   5        	 ��Name$	 month_panel��5%      
 �� Orientation$
 
Horizontal=�6.   $��Center=�6G   5&      5'      �� 5(   
   $��2��6   .��5)      �� -   5        $	 performancelist_panel��5)      .+�5*      � ��6   �� *ActualHeight+ �� ElementName$ performancelist_panel��.+�5+      �� $��Center=�6   $��Center=�69   $��16(�6T   .��6b   mkВыберите месяц, пъесы по которому вы хотели бы просмотреть6�   5,      5-      5.      5/      50      