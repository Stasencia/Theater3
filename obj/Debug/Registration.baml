   M S B A M L   `   `   `  ����B  >Theater, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TheaterTheater  5   	       Theater.Registration   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Theater     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  Регистрация��5	   	   $	��350��6   $	��300��6*   $��Century Gothic)�66    � WindowStartupLocation$ CenterScreen=�6R    � 	Resources 5
       �� 
TargetType   FlatButtonStyle �� Property �� Value �� 
TargetType �� Padding �� CornerRadius	 �� Triggers
 P� Property P� Value��%�  &	        �� 5   
   " ��6   .�5      ��  � ��
 ���H�6+   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   �� 5       � ��
 ���H�6F   �� 5       � ��$ 5q�6(   64   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      # z��5      $ 0��5      ._�5      �� #��z��6-   $��Center=�6Q   5      5      5      	 5      P� 5      
 �@J�IsMouseOver . . �5       ��  � ��
 ����63   �� 5!       � ��
 ����64   5"      P� 5#      
 � �� . . �5$      ��  � ��
 ��� �63   5%      5'      5(      .��5)      )  #MaterialDesignThemes.Wpf.DialogHost     DialogContentTemplate 5*   
   �� 5+       �� DataType$ local: TextBlock��6   .R�5,      � ��6   �� *ActualWidth+ �� ElementName$ MainGrid��.+�5-      � $��20q�6    � RowDefinitions 5.      �� 5/      $��* �6,   69   �� 50      $��* �6,   69   .+�52      �� $
��Wrap=�6$   $��0��6N   $��0,0,0,10q�6[   ��68   �� *Text+6[   �� 53      -   5        $��1��53   !   .��6B   Закрыть6K   54      55      56      .��58   
   �  � ColumnDefinitions 59      �� 5:      $	��25* �6#   �� 5;      $
��168* �6#   �� 5<      $	��25* �6#    5>      �� 5?      $	��25* �6    �� 5@      $
��295* �6    �� 5A      $	��25* �6    .+�5C      �� $��1��6   $��1��6&   $��Center=�66   .+�5D      �� $��Регистрация��6   $��Center=�6.   $��Center=�6K   $��16(�6f   �� 5E      $��
Логин��6   $��14(�6(   �� 5F      -   5         ��Name$ LoginBox��5F      $��14(�6,   �� 5G      $��Пароль��6   $��14(�6)   G� 5H      -   5         G�Name$ PasswordBox��5H      $��14(�63   �� 5I      $)��#Подтвердите пароль��6   $��14(�65   G� 5J      -   5        $ ConfirmPasswordBox��5J      $��0,0,0,20q�6:   $��14(�6L   �� 5K      -   5         ��Name$ RegistrateBtn��5K      $,��&Зарегистрироаваться��60   6N   5L      5M      5N      5O      