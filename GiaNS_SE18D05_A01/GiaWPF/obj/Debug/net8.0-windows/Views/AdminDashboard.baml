   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   
 GiaWPF!   GiaWPF.Views.AdminDashboard   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$,  &FU Mini Hotel System - Admin Dashboard��5   	   $	��700��5   	   $
��1200��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � 	Resources 5
         ModernButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value  DangerButton �� BasedOn �� Triggers  SuccessButton  ModernTextBox ��Name��%@  &	        &	 �    7   &	 �    7   &	 �    �� 5   
   " ��6%   .�5      ��  � �� �#007ACC6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$
 12,6q�6(   �� 5       � ��$ 5q�6'   �� 5       � ��$ 12(�6)   �� 5       � ��$ SemiBold"�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 3��5   !   #��z��5   !   #��z��5   !   ._�5      �� $��Center=�6/   $��Center=�5   -   5      	 5      P� 5       
 �@J�IsMouseOver$
 True��6=   . �5!   "   ��  � �� �#005A9E6?   5"      P� 5#      
 � ��$
 True��6;   . �5$   "   ��  � �� �#0045786?   5%      P� 5&      
 � {�$ False��6;   . �5'   "   ��  � �� �#CCCCCC6?   �� 5(   "    �@�Cursor$ Arrow��6;   5)      5+      5-      5.      �� 51   
   8   " ��6M   .�52      ��  � �� �#DC35456+    53      P� 54      
 �@J�IsMouseOver$
 True��61   . �55      ��  � �� �#C8233363   56      P� 57      
 � ��$
 True��6/   . �58      ��  � �� �#BD213063   59      5;      �� 5>   
   8   " ��6N   .�5?      ��  � �� �#28A7456+    5@      P� 5A      
 �@J�IsMouseOver$
 True��61   . �5B      ��  � �� �#21883863   5C      P� 5D      
 � ��$
 True��6/   . �5E      ��  � �� �#1E7E3463   5F      5H      �� 5K   
   " ��6&   .�5L      ��  � ��$	 8,6q�6(   �� 5M       � ��$ 12(�6)   �� 5N       � ��$ 1q�60   �� 5O       � �� �#CCCCCC6,   �� 5P       � ��
 �����6+   �� 5Q       � �� 5R      �� 5S      " ��6&   .R�5T      �� #��z��6!   #��z��5U   !   #��z��5V   !   $ 3��5W   !   ._�5X      �� $ PART_ContentHost��6+   #��z��5Y   )   5Z      	 5[      P� 5\      
 �@J�	IsFocused$
 True��6;   . �5]   "   ��  � �� �#007ACC6@   5^      5`      5b      5c      5d      .��5f      �  � RowDefinitions 5g   
   �� 5h      $
��Auto �6   �� 5i      $
��Auto �6   �� 5j      $��* �6   �� 5k      $
��Auto �6   .+�5o   
   �� $��0��6   ���#007ACC �� Padding$ 15,10q�63   ._�5p      �  � ColumnDefinitions 5q      �� 5r      $��* �6'   �� 5s      $
��Auto �6'   .+�5v      �� $��0��6    �� Orientation$ 
Horizontal=�6-   .+�5w      �� $
��🏨��6    $��24(�6*   
�������$��Center=�6K   �� 5x      $,��&FU Mini Hotel System - Admin Dashboard��6    $��18(�5y      $
��Bold"�6-   
�������$��Center=�5z      $��10,0,0,0q�6:   5{      �� 5}      $��1��6   $ 
Horizontal=�6-   .+�5~      �� $��🔄 Refresh��6   #��[  5�      ���#28A745��5      �� *RefreshCommand+5�      �� 5�      $��🚪 Logout��6   #��[ 5�      ��5�      �� *LogoutCommand+5�      5�      5�      5�      �� 5�   
   $��1��6   ���#F8F9FA$ 15,10q�63   $��0,0,0,1q�6C   ���#DEE2E6._�5�      �� $ 
Horizontal=�6   $��Center=�62   .+�5�      �� 
�������$ 15,10q�6,   $
��10,0q�6<   $ 5��6J   $��1q�5�      ���#DEE2E6._�5�      �� $��Center=�6!   .+�5�      �� $��24(�6D   $
��Bold"�6R   ���#007ACC$��Center=�5�   8   ��5�   $   �� *TotalCustomers+5�   8   �� 5�      $��Total Customers��6$   $��12(�6;   ���#6C757D$��Center=�5�   #   5�      5�      �� 5�      
�������$ 15,10q�6,   $
��10,0q�6<   $ 5��6J   $��1q�5�      ���#DEE2E6._�5�      �� $��Center=�6!   .+�5�      �� $��24(�6@   $
��Bold"�6N   ���#28A745$��Center=�5�   8   ��5�   $   �� *
TotalRooms+5�   8   �� 5�      $��Total Rooms��6$   $��12(�67   ���#6C757D$��Center=�5�   #   5�      5�      �� 5�      
�������$ 15,10q�6,   $
��10,0q�6<   $ 5��6J   $��1q�5�      ���#DEE2E6._�5�      �� $��Center=�6!   .+�5�      �� $��24(�6D   $
��Bold"�6R   ���#FFC107$��Center=�5�   8   ��5�   $   �� *TotalRoomTypes+5�   8   �� 5�      $��
Room Types��6$   $��12(�66   ���#6C757D$��Center=�5�   #   5�      5�      5�      5�      �� 5�   
   $��2��6   $��10q�6"   .@�5�      �� $��👥 Customer Management��6   .��5�      � $��10q�6    5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   .+�5�      � $��0��6   $��0,0,0,10q�6(    5�      �� 5�      $��* �6/   �� 5�      $
��Auto �6/   .+�5�      �� $��0��6%   $ 
Horizontal=�65   .+�5�      �� $��Search:��6(   $��Center=�67   $��0,0,10,0q�6R   �� 5�      #��[ 5�      $	��300��5�      ��5�   &   �� *CustomerSearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5�      5�      �� 5�      $��1��6%   $ 
Horizontal=�65   .+�5�      �� $��➕ Add Customer��6%   #��[ 5�      ��5�      �� *AddCustomerCommand+5�      �� 5�      $��✏️ Edit��6%   #��[  5�      ��5�      �� *EditCustomerCommand+5�      �� 5�      $��🗑️ Delete��6%   #��[ 5�      ��5�      �� *DeleteCustomerCommand+5�      5�      5�      &   System.Windows.Controls.DataGrid  5�      $��1��6      AutoGenerateColumns$ False��5�         CanUserAddRows$ False��5�         CanUserDeleteRows$ False��5�         
IsReadOnly$
 True��5�         GridLinesVisibility$ 
Horizontal=�5�         HeadersVisibility$ Column=�5�         SelectionMode$ Single=�5�      ��5�      �� *	Customers+ �� SelectedItem 5�      �� *SelectedCustomer+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *
CustomerID+6\     5�      $ 	Full Name��61   $	 200 6i    6D   �� *CustomerFullName+6i     5�      $ Email��61   $	 250 6a    6@   �� *EmailAddress+6a     5�      $ Phone��61   $	 120 6^    6@   �� *	Telephone+6^     5�      $ Birthday��61   $	 100 6�    6C   �� *CustomerBirthday+  �� StringFormat$  
dd/MM/yyyy��6�     5�      $	 Age��61   $ 60 6V    6>   �� *Age+6V     5�      $ Status��61   $ 80 6`    6A   �� *
StatusText+6`   5�      5�      5�      �� 5�      $��🏨 Room Management��6   .��5�      � $��10q�6    5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   .+�5�      � $��0��6   $��0,0,0,10q�6(    5�      �� 5�      $��* �6/   �� 5�      $
��Auto �6/   .+�5�      �� $��0��6%   $ 
Horizontal=�65   .+�5�      �� $��Search Room:��6(   $��Center=�6<   $��0,0,10,0q�6W   �� 5�      $	��300��6&   #��[ 62   5�      �� 5     $��1��6%   $ 
Horizontal=�65   .+�5     �� $��➕ Add Room��6%   #��[ 6:   �� 5     $��✏️ Edit��6%   #��[  67   �� 5     $��🗑️ Delete��6%   #��[ 6:   5     5       5
     $��1��6   $ False��5     $ False��5     $ False��5     $
 True��5     $ 
Horizontal=�5     $ Column=�5     $ Single=�5     ��5     �� *Rooms+ 5       5     $ ID��61   $ 60 6X    6=   �� *RoomID+6X     5     $ Room Number��61   $	 120 6e    6F   �� *
RoomNumber+6e     5     $ Description��61   $	 250 6j    6F   �� *RoomDescription+6j     5     $
 Type��61   $	 120 6`    6?   �� *RoomTypeName+6`     5     $ Capacity��61   $ 80 6g    6C   �� *RoomMaxCapacity+6g     5     $ Price/Night��61   $	 120 6i    6F   �� *FormattedPrice+6i     5     $ Status��61   $ 80 6`    6A   �� *
StatusText+6`   5     5     5     �� 5!     $��📊 Reports��6   .��5"     � $��10q�6    5#     �� 5$     $
��Auto �6(   �� 5%     $��* �6(   .+�5)     �� $��0��6   ���#F8F9FA$ 15q�6?   $��0,0,0,10q�6L   $ 5��6^   ._�5*     �� .+�5+     �� $"��📈 Hotel Statistics Report��6(   $��16(�6J   $
��Bold"�6X   $��0,0,0,10q�6j   � 5,      5-  "   �� 5.  &   $
��Auto �67   �� 5/  &   $��* �67   �� 50  &   $
��Auto �67   .+�53  "   �� $��0��6,   $��Report Period:��6<   $��Center=�6R   $��0,0,10,0q�6m   �� 54  "   $��1��6-   $ 
Horizontal=�6=   .+�55  &   (  "System.Windows.Controls.DatePicker  $	��150��61   $��0,0,10,0q�6=   �� 56  &   $��to��60   $��Center=�6:   $��0,0,10,0q�6U     57  &   $	��150��61   58  #   �� 59  "   $��2��6)   $��📊 Generate Report��69   #��[  6V   5:     5;     5<     �� 5?     $��1��6#   .��5@     �� .+�5B     A� ! A� Columns$! 4��6*   $��0,0,0,20q�66   .+�5C  "   �� 
�������$ 15q�6<   $��5q�6I   $ 5��6T   $��1q�6e   ���#DEE2E6._�5D  &   �� $��Center=�61   .+�5E  *   �� $��28(�6T   $
��Bold"�6b   ���#007ACC$��Center=�6�   ��64   �� *TotalCustomers+6�   �� 5F  *   $��Total Customers��64   $��12(�6K   ���#6C757D$��Center=�6n   5G  '   5H  #   �� 5J  "   
�������$ 15q�6<   $��5q�6I   $ 5��6T   $��1q�6e   ���#DEE2E6._�5K  &   �� $��Center=�61   .+�5L  *   �� $��28(�6P   $
��Bold"�6^   ���#28A745$��Center=�6�   ��64   �� *
TotalRooms+6�   �� 5M  *   $��Total Rooms��64   $��12(�6G   ���#6C757D$��Center=�6j   5N  '   5O  #   �� 5Q  "   
�������$ 15q�6<   $��5q�6I   $ 5��6T   $��1q�6e   ���#DEE2E6._�5R  &   �� $��Center=�61   .+�5S  *   �� $��28(�6T   $
��Bold"�6b   ���#FFC107$��Center=�6�   ��64   �� *TotalRoomTypes+6�   �� 5T  *   $��
Room Types��64   $��12(�6F   ���#6C757D$��Center=�6i   5U  '   5V  #   �� 5X  "   
�������$ 15q�6<   $��5q�6I   $ 5��6T   $��1q�6e   ���#DEE2E6._�5Y  &   �� $��Center=�61   .+�5Z  *   �� $
��100%��64   $��28(�6@   $
��Bold"�6N   ���#DC3545$��Center=�6u   �� 5[  *   $��Occupancy Rate��64   $��12(�6J   ���#6C757D$��Center=�6m   5\  '   5]  #   5^     �� 5a     
�������$ 15q�68   $��0,0,0,15q�6E   $ 5��6W   $��1q�6h   ���#DEE2E6._�5b  "   �� .+�5c  &   �� $��🏨 Room Types Overview��60   $��14(�6N   $
��Bold"�6\   $��0,0,0,10q�6n     5d  &   $ False��5e  &   $ False��5f  &   $ False��5g  &   $
 True��5h  &   $ 
Horizontal=�5i  &   $ Column=�5j  &   ��5d  /   �� *	RoomTypes+ 5k  *     5l  .   $ Type ID��6A   $ 80 6q    6R   �� *
RoomTypeID+6q     5m  .   $ 	Type Name��6A   $	 150 6u    6T   �� *RoomTypeName+6u     5n  .   $ Description��6A   $	 300 6z    6V   �� *TypeDescription+6z     5o  .   $ 
Room Count��6A   $	 100 6s    6U   �� *	RoomCount+6s     5p  .   $ Notes��6A   $	 200 6m    6P   �� *
TypeNote+6m   5r  '   5s  #   5t     �� 5w     
�������$ 15q�68   $ 5��6E   $��1q�6V   ���#DEE2E6._�5x  "   �� .+�5y  &   �� $��💰 Revenue Report��60   $��14(�6I   $
��Bold"�6W   $��0,0,0,10q�6i   �� 5z  &   $O��IRevenue tracking will be implemented when booking functionality is added.��60   $��Italic$�5{  '   ���#6C757D6:   5|  #   5}     5~     5     5�     5�     5�     �� 5�  
   $��3��6   ���#F8F9FA$��0,1,0,0q�66   ���#DEE2E6.@�5�     �� .��5�     �� 
���  ����6   �� *ErrorMessage+y�5�     �� *ErrorMessage+  StringToVisibilityConverter" �� 	Converter#" [ 5�     �� 5�     $��Right=�6   .��5�     �� $��Admin Dashboard - Ready��6   ���#6C757D6;   5�     5�     5�     5�     