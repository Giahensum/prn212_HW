   M S B A M L   `   `   `  ����  NgoSyGiaWPF    NgoSyGiaWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$"  FU Mini Hotel System - Login��5   	   $	��600��5   	   $	��650��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � ��5	   
   �� 5
       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF2196F3��6    � Offset$ 0Q�61   � 5      $ 	#FF1976D2��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��20,20,20,15q�6"   .+�5      �� $��FU Mini Hotel System��6   $��28(�5      $
��Bold"�6&   $��Center=�5      
�������5      �� 5      $��Hotel Management System��6   $��14(�5      $��Center=�5      
������� J� Opacity$	 0.8Q�5   +   $��0,5,0,0q�5       5!      �� 5$   
   $��1��6   
�������	 �� CornerRadius$	 15��5%      $��60,10,60,10q�6#   
 J� Effect
 5&      3  -System.Windows.Media.Effects.DropShadowEffect  5'         ShadowDepth$ 3Q�6#      	Direction$	 315Q�63      Color$
 Gray��5(   #      Opacity$	 0.3Q�60      
BlurRadius$ 10Q�6>   ._�5+      �� $��30,25,30,25q�6   .+�5,      �� $��Login��6   $��22(�6)   $
��Bold"�67   $��Center=�5-      ���	#FF1976D2$��0,0,0,20q�5.   3   �� 50      $��Email Address:��6   $��13(�51      $��SemiBold"�6*   ���	#FF424242$��0,0,0,5q�52   3   �� 53      -   5        $��txtEmail��53      $��35��6*   $��13(�66   $
��12,8q�54      ���	#FFCCCCCC$��1q�56      $!��admin@FUMiniHotelSystem.com��57      �� 59      $��	Password:��6   $��13(�5:      $��SemiBold"�6*   ���	#FF424242$��0,15,0,5q�5;   3   G� 5<      -   5        $��txtPassword��5<      $��35��61   $��13(�6=   $
��12,8q�5=      ���	#FFCCCCCC$��1q�5?       G� Password$ 
@@abc123@@��5@      �� 5C      -   5        $��btnLogin��5C      $��LOGIN��6)   $��40��69   $��0,20,0,0q�5D      $��14(�6+   $
��Bold"�69   ���	#FF2196F3
�������$��0q�5F       � Cursor$
 Hand��6-   ��5H      �� 5I       �� 
TargetType" ��6    .�5J      ��  �� Property � �� �� Value 5K   "   �� 5L   &    �� 
TargetType" ��66   .R�5M   *   �� #��z��61   $	 6��5N   1   #��z��5O   1   #��z��5P   1   ._�5Q   .   �� $��Center=�6?   $��Center=�5R   =   5S   +   5T   '   5V       �� Triggers 5W      P� 5X   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5Y   &   ��  � �� �	#FF1976D26C   5Z   #   P� 5[   "    � ��$
 True��6?   . �5\   &   ��  � �� �	#FF1565C06C   5]   #   5_      5a      5b      5c      �� 5f   
   $��2��6   $��
20,5,20,15q�6"   .+�5g      �� $��Test Accounts:��6   $
��Bold"�6.   $��Center=�5h      
�������$��11(�5i   +   �� 5j      $5��/Admin: admin@FUMiniHotelSystem.com | @@abc123@@��6   $��Center=�5k      
�������$��10(�5l   +   $	 0.8Q�69   �� 5m      $9��3Customer: WilliamShakespeare@FUMiniHotel.org | 123@��6   $��Center=�5n      
�������$��10(�5o   +   $	 0.8Q�69   5p      5q      5r      