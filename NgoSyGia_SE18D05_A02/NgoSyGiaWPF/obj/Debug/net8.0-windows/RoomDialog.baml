   M S B A M L   `   `   `  ����  NgoSyGiaWPF    NgoSyGiaWPF.RoomDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Room Information��5   	   $	��600��5   	   $	��500��6    � WindowStartupLocation$ CenterOwner=�5   	    � 
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
��Auto �6    .+�5      �� -   5         ��Name$ lblTitle��5      $��Add Room��6*   $��20(�5      $
��Bold"�6&   ���#1976D2$��0,0,0,15q�5   -   �� 5      $��1��6   $
��Auto=�6(   .��5      �� $��0,0,0,15q�6   .+�5      �� $��Room Number:��6    $��SemiBold"�64   $��0,0,0,5q�6J   �� 5       -   5         ��Name$ txtRoomNumber��5       $��35��65   $��13(�6A   $
��10,8q�5!      ���#CCCCCC$��1q�6C   $��0,0,0,12q�5"      �� 5%      $��
Room Type:��6    $��SemiBold"�62   $��0,0,0,5q�6H   �� 5&      -   5         ��Name$ cboRoomType��5&      $��35��64   $��13(�6@    �� DisplayMemberPath$ RoomTypeName��5'       �� SelectedValuePath$ 
RoomTypeID��6@   $��0,0,0,12q�5(      �� 5+      $��Max Capacity:��6    $��SemiBold"�65   $��0,0,0,5q�6K   �� 5,      -   5        $ txtMaxCapacity��5,      $��35��66   $��13(�6B   $
��10,8q�5-      ���#CCCCCC$��1q�6C   $��0,0,0,12q�5.      �� 51      $��Price Per Day:��6    $��SemiBold"�66   $��0,0,0,5q�6L   �� 52      -   5        $ txtPricePerDay��52      $��35��66   $��13(�6B   $
��10,8q�53      ���#CCCCCC$��1q�6C   $��0,0,0,12q�54      �� 57      $��Description:��6    $��SemiBold"�64   $��0,0,0,5q�6J   �� 58      -   5        $ txtDescription��58      $��80��66   $��13(�6B   $
��10,8q�59      ���#CCCCCC$��1q�6C    �� TextWrapping$
 Wrap=�5:       �� AcceptsReturn$
 True��62   $��0,0,0,12q�5;      �� 5>      $��Status:��6    $��SemiBold"�6/   $��0,0,0,5q�6E   �� 5?      -   5         ��Name$ 	chkStatus��5?      $��	Available��62    d� 	IsChecked$
 TrueY�6F   $��0,0,0,0q�5@      5A      5B      �� 5E      $��2��6    �� Orientation$ 
Horizontal=�6&   $��Right=�6?   .+�5F      �� -   5         ��Name$ btnSave��5F      $
��Save��6*   $	��100��69   $��35��6E   $��0,0,10,0q�5G      ���#4CAF50
�������$��0q�5H      $
��Bold"�6-   5I      �� 5J      -	   5        $ 	btnCancel��5J      $��Cancel��6,   $	��100��6=   $��35��6I   ���#9E9E9E
�������$��0q�5K   A   $
��Bold"�5L      6+   5M      5N      5O      5P      