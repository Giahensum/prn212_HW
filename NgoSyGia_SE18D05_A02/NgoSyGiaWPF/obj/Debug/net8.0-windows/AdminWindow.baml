   M S B A M L   `   `   `  ����  NgoSyGiaWPF    NgoSyGiaWPF.AdminWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$,  &Admin Dashboard - FU Mini Hotel System��5   	   $	��800��5   	   $
��1400��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   ���	#FF1976D2 �� Padding$ 10q�65   ._�5      ]� .+�5      �� $,��&FU Mini Hotel System - Admin Dashboard��6   $��18(�5      $
��Bold"�6*   
�������$��Center=�5   /   $
��Left=�5      �� 5      -   5        $��	btnLogout��5      $��Logout��6*   $��Right=�5      $��80��5      $��30��6$   ���	#FFE53935
�������$��0q�5      $
��Bold"�6-   $��12(�6?   $��Center=�5      $��10,0,0,0q�64   5      5      �� 5!   
   -   5        $��1��5!      $��10q�6"   $��14(�6.   .@�5#      �� $��👥 Customer Management��6   $��16(�66   .��5$       � -   5        $��CustomerFrame��5$        � NavigationUIVisibility$ Hidden=�6-   5%      �� 5&      $��🏨 Room Management��6   $��16(�62   .��5'       � -   5        $��	RoomFrame��5'      $ Hidden=�6)   5(      �� 5)      $��📋 Booking Management��6   $��16(�65   .��5*       � -   5        $��BookingFrame��5*      $ Hidden=�6,   5+      �� 5,      $��📊 Reports��6   $��16(�6*   .��5-       � -   5        $��ReportFrame��5-      $ Hidden=�6+   5.      5/      �� 53   
   $��2��6   ���	#FFF5F5F5.@�54      �� .��55      �� -   5        $��	txtStatus��55   )   $��Ready��6   $��12(�6:   56      57      58      59      