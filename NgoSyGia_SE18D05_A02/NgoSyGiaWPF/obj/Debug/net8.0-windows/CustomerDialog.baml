   M S B A M L   `   `   `  ����  NgoSyGiaWPF     NgoSyGiaWPF.CustomerDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Customer Information��5   	   $	��600��5   	   $	��500��6    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5	      �� $��20q�6   
������� �� CornerRadius$ 10��6,    J� Effect 5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 3Q�6      	Direction$	 315Q�6/      Color$
 Gray��5         Opacity$
 0.25Q�6,   	   
BlurRadius$	 8Q�6;   ._�5   
   � $��25q�6   
 � RowDefinitions
 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� -   5         ��Name$ lblTitle��5      $��Add Customer��6*   $��20(�5      $
��Bold"�6&   ���#1976D2$��0,0,0,15q�5   -   �� 5      $��1��6   $
��Auto=�6(   .��5      �� $��0,0,0,15q�6   .+�5      �� $��
Full Name:��6    $��SemiBold"�62   $��0,0,0,5q�6H   �� 5       -   5         ��Name$ txtFullName��5       $��35��63   $��13(�6?   $
��10,8q�5!      ���#CCCCCC$��1q�6C   $��0,0,0,12q�5"      �� 5%      $��Email Address:��6    $��SemiBold"�66   $��0,0,0,5q�6L   �� 5&      -   5        $ txtEmail��5&      $��35��60   $��13(�6<   $
��10,8q�5'      ���#CCCCCC$��1q�6C   $��0,0,0,12q�5(      �� 5+      $��Phone Number:��6    $��SemiBold"�65   $��0,0,0,5q�6K   �� 5,      -   5        $ txtPhone��5,      $��35��60   $��13(�6<   $
��10,8q�5-      ���#CCCCCC$��1q�6C   $��0,0,0,12q�5.      �� 51      $��	Birthday:��6    $��SemiBold"�61   $��0,0,0,5q�6G   (  "System.Windows.Controls.DatePicker  52      -   5          Name$ 
dpBirthday��52   !   $��35��65   $��13(�6A   $��0,0,0,12q�53   !   �� 56      $��	Password:��6    $��SemiBold"�61   $��0,0,0,5q�6G   G� 57      -   5         G�Name$ txtPassword��57   "   $��35��67   $��13(�6C   $
��10,8q�58   "   ���#CCCCCC$��1q�6G   $��0,0,0,12q�59   "   �� 5<      $��Status:��6    $��SemiBold"�6/   $��0,0,0,5q�6E   �� 5=      -   5         ��Name$ 	chkStatus��5=      $��Active��62    d� 	IsChecked$
 TrueY�6C   $��0,0,0,0q�5>      5?      5@      �� 5C      $��2��6    �� Orientation$ 
Horizontal=�6&   $��Right=�6?   .+�5D      �� -   5         ��Name$ btnSave��5D      $
��Save��6*   $	��100��69   $��35��6E   $��0,0,10,0q�5E      ���#4CAF50
�������$��0q�5F      $
��Bold"�6-   5G      �� 5H      -	   5        $ 	btnCancel��5H      $��Cancel��6,   $	��100��6=   $��35��6I   ���#9E9E9E
�������$��0q�5I   A   $
��Bold"�5J      6+   5K      5L      5M      5N      