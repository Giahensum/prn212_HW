   M S B A M L   `   `   `  ����
  GiaWPF$    GiaWPF.Views.CustomerDashboard   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$,  &FU Mini Hotel System - Customer Portal��5   	   $	��600��5   	   $
��1000��6    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         ModernButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value��%  &	        �� 5	   
   " ��6%   .�5
      ��  � �� �#007ACC6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$
 12,6q�6(   �� 5       � ��$ 5q�6'   �� 5       � ��$ 12(�6)   �� 5       � ��$ SemiBold"�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 3��5   !   #��z��5   !   #��z��5   !   ._�5      �� $��Center=�6/   $��Center=�5   -   5       5      P� 5      	 �@J�IsMouseOver$

 True��6=   . �5   "   ��  � �� �#005A9E6?   5      P� 5       	 � ��$

 True��6;   . �5!   "   ��  � �� �#0045786?   5"      5$      5&      5'      5(      .��5*      �  � RowDefinitions 5+   
   �� 5,      $
��Auto �6   �� 5-      $
��Auto �6   �� 5.      $��* �6   �� 5/      $
��Auto �6   .+�53   
   �� $��0��6   ���#007ACC �� Padding$ 15,10q�63   ._�54      �  � ColumnDefinitions 55      �� 56      $��* �6'   �� 57      $
��Auto �6'   .+�5:      �� $��0��6    �� Orientation$ 
Horizontal=�6-   .+�5;      �� $
��🏨��6    $��24(�6*   
�������$��Center=�6K   �� 5<      $,��&FU Mini Hotel System - Customer Portal��6    $��18(�5=      $
��Bold"�6-   
�������$��Center=�5>      $��10,0,0,0q�6:   5?      �� 5A      $��1��6   $ 
Horizontal=�6-   .+�5B      �� $��👤 My Profile��6   #��[  5D      ���#28A745��5C      �� *ViewProfileCommand+5E      �� 5F      $��🚪 Logout��6   #��[  5H      ���#DC3545��5G      �� *LogoutCommand+5I      5J      5K      5L      �� 5O   
   $��1��6   ���#F8F9FA$ 20q�63   ._�5P      �� $��Center=�6   .+�5Q      �� $��20(�5R      $
��Bold"�6)   ���#007ACC$��Center=�5T      ��5Q      �� *WelcomeMessage+5T      �� 5U      $:��4Browse our available rooms and make your reservation��6   $��14(�5V      ���#6C757D$��Center=�5W      $��0,5,0,0q�68   5X      5Y      �� 5\   
   $��2��6   $��10q�6"   .@�5^      �� $��🏨 Available Rooms��6   .��5_      � $��10q�6    5`      �� 5a      $
��Auto �6(   �� 5b      $��* �6(   .+�5f      �� $��0��6   ���#F8F9FA$ 15q�6?   $��0,0,0,10q�6L   $ 5��6^   ._�5g      �� .+�5h      �� $!��🔍 Find Your Perfect Room��6(   $��16(�6I   $
��Bold"�6W   $��0,0,0,10q�6i   � 5i       5j   "   �� 5k   &   $
��Auto �67   �� 5l   &   $��* �67   �� 5m   &   $
��Auto �67   �� 5n   &   $��* �67   �� 5o   &   $
��Auto �67   .+�5r   "   �� $��0��6,   $��	Check-in:��6<   $��Center=�6M   $��0,0,10,0q�6h   (  "System.Windows.Controls.DatePicker  5s   "   $��1��6-   $	��150��6=   $��0,0,20,0q�6I   �� 5u   "   $��2��6,   $��
Check-out:��6<   $��Center=�6N   $��0,0,10,0q�6i     5v   "   $��3��6-   $	��150��6=   $��0,0,20,0q�6I   �� 5x   "   $��4��6)   $��🔍 Search��69   #��[  6M   5y      5z      5{      &   System.Windows.Controls.DataGrid  5~      $��1��6      AutoGenerateColumns$ False��5�         CanUserAddRows$ False��5�         CanUserDeleteRows$ False��5�         
IsReadOnly$
 True��5�         GridLinesVisibility$ 
Horizontal=�5�         HeadersVisibility$ Column=�5�         SelectionMode$ Single=�5�      ��5      �� *AvailableRooms+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$
 Room��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *
RoomNumber+6^     5�      $
 Type��61   $	 120 6`    6?   �� *RoomTypeName+6`     5�      $ Description��61   $	 300 6j    6F   �� *RoomDescription+6j     5�      $ Capacity��61   $ 80 6g    6C   �� *RoomMaxCapacity+6g     5�      $ Price/Night��61   $	 120 6i    6F   �� *FormattedPrice+6i   4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ Action��65   $	 100 6E      CellTemplate 5�   "   �� 5�   &   .R�5�   *   �� $��Book Now��61   #��[  5�   0   ���#28A745$��10(�5�   0   $	��8,4q�5�   0   5�   '   5�      5�      5�      5�      �� 5�      $��📅 My Bookings��6   .��5�      � $��20q�6   .+�5�      �� $N��HBooking history will be implemented when booking functionality is added.��6    $��16(�5�      $��Center=�5�      $��Center=�5�      ���#6C757D5�      5�      5�      5�      �� 5�   
   $��3��6   ���#F8F9FA$��0,1,0,0q�66   ���#DEE2E6.@�5�      �� .��5�      �� 
���  ����6   �� *ErrorMessage+y�5�      �� *ErrorMessage+  StringToVisibilityConverter �� 	Converter# [ 5�      �� 5�      $��Right=�6   .��5�      �� $��Customer Portal - Ready��6   ���#6C757D6;   5�      5�      5�      5�      