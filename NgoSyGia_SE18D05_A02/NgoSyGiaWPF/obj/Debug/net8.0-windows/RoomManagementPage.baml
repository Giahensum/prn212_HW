   M S B A M L   `   `   `  ����  NgoSyGiaWPF$    NgoSyGiaWPF.RoomManagementPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Room Management��5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6   $��Room Management��6!   $��24(�5      $
��Bold"�6"   ���	#FF1976D2$��0,0,0,20q�5   +   � 5   
   $��1��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6)   .+�5      �� -   5        $��	txtSearch��5      $	��300��6+   $��35��67   $��14(�5      $
��10,8q�6(   ���	#FFCCCCCC$��1q�5   2   $��Center=�5      $4��.Search by room number, type, or description...��5      �� 5       -   5        $��	btnSearch��5       $��🔍 Search��6*   $��35��5!      $
��15,8q�6%   $��10,0,0,0q�64   ���	#FF2196F3
�������$��0q�5#      $
��Bold"�6-   5$      5%      �� 5'      -   5        $��btnAdd��5'      $��➕ Add Room��6#   $��1��5(      $��35��6%   $
��15,8q�61   $��10,0,0,0q�6@   ���	#FF4CAF50
�������$��0q�5*      $
��Bold"�6)   5+      �� 5-      -   5        $��	btnUpdate��5-      $��✏️ Update��6&   $��2��5.      $��35��6%   $
��15,8q�61   $��10,0,0,0q�6@   ���	#FFFF9800
�������$��0q�50      $
��Bold"�6)   51      �� 53      -   5        $��	btnDelete��53      $��🗑️ Delete��6&   $��3��54      $��35��6%   $
��15,8q�61   $��10,0,0,0q�6@   ���	#FFE53935
�������$��0q�56      $
��Bold"�6)   57      58      &   System.Windows.Controls.DataGrid  5;   
   -   5        $��dgRooms��5;       $��2��6      AutoGenerateColumns$ False��5<         
IsReadOnly$
 True��5=         SelectionMode$ Single=�5>         GridLinesVisibility$ 
Horizontal=�5?         HeadersVisibility$ Column=�5@      	   AlternatingRowBackground	 �	#FFF9F9F9
   Columns
 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *RoomID+6L     5D      $ Room Number��6%   $	 120 6Y    6:   �� *
RoomNumber+6Y     5E      $ 	Room Type��6%   $	 150 6b    68   �� *RoomType.RoomTypeName+6b     5F      $ Max Capacity��6%   $	 100 6_    6;   �� *RoomMaxCapacity+6_     5G      $ 	Price/Day��6%   $	 120 6l    68   �� *RoomPricePerDay+ �� StringFormat$ C��6l     5H      $ Description��6%   $	 300 6d    6:   �� *RoomDetailDescription+6d     5J      $ Status��6%   $	 100 65    5K      �� 5L       �� Path$ 
RoomStatus�6"   $	 {0}��5M   M   5N      5P      5R      5S      5T      