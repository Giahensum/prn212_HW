   M S B A M L   `   `   `  ����  NgoSyGiaWPF'    !NgoSyGiaWPF.BookingManagementPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Booking Management��5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6   $��Booking Management��6!   $��24(�5      $
��Bold"�6"   ���	#FF1976D2$��0,0,0,20q�5   +   � 5   
   $��1��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6)   .+�5      �� $��Date Range:��6   $��Center=�6/   $��0,0,10,0q�6J   $��SemiBold"�6\   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpStartDate��5      $	��120��60   $��35��6<   $��0,0,10,0q�6H   �� 5      $��to��6   $��Center=�6&   $��0,0,10,0q�6A     5      -   5        $��	dpEndDate��5      $	��120��6.   $��35��6:   $��0,0,10,0q�6F   �� 5      -   5        $��	btnFilter��5      $��🔍 Filter��6*   $��35��5       $
��15,8q�6%   $��10,0,0,0q�64   ���	#FF2196F3
�������$��0q�5"      $
��Bold"�6-   5#      5$      �� 5&      -   5        $��btnAdd��5&      $��➕ New Booking��6#   $��1��5'      $��35��6%   $
��15,8q�61   $��10,0,0,0q�6@   ���	#FF4CAF50
�������$��0q�5)      $
��Bold"�6)   5*      �� 5,      -   5        $��	btnUpdate��5,      $��✏️ Update��6&   $��2��5-      $��35��6%   $
��15,8q�61   $��10,0,0,0q�6@   ���	#FFFF9800
�������$��0q�5/      $
��Bold"�6)   50      �� 52      -   5        $��	btnCancel��52      $��🗑️ Cancel Booking��6&   $��3��53      $��35��6%   $
��15,8q�61   $��10,0,0,0q�6@   ���	#FFE53935
�������$��0q�55      $
��Bold"�6)   56      57      &   System.Windows.Controls.DataGrid  5:   
   -   5        $��
dgBookings��5:       $��2��6      AutoGenerateColumns$ False��5;         
IsReadOnly$
 True��5<         SelectionMode$ Single=�5=         GridLinesVisibility$ 
Horizontal=�5>         HeadersVisibility$ Column=�5?      	   AlternatingRowBackground	 �	#FFF9F9F9
   Columns
 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Booking ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *BookingReservationID+6b     5C      $ Customer��6%   $	 180 6e    67   �� *Customer.CustomerFullName+6e     5D      $ Booking Date��6%   $	 120 6t    6;   �� *BookingDate+ �� StringFormat$ 
dd/MM/yyyy��6t     5E      $ Total Price��6%   $	 120 6i    6:   �� *
TotalPrice+$ C��6i     5F      $ Status��6%   $ 80 6W    65   �� *BookingStatus+6W   4  .System.Windows.Controls.DataGridTemplateColumn  5G      $ Actions��6)   $	 150 6:      CellTemplate 5H      �� 5I      .R�5J      �� $ 
Horizontal=�6)   .+�5K   "   �� -   5        $��Details��5K   )   $	��5,2q�6;   $��10(�6I   $��0,0,5,0q�6W   ���	#FF607D8B
�������$��0q�5L   S   
 � Tag 5M   F   �� �� 5N   "   -	   5        $��Rooms��5N   )   $	��5,2q�69   $��10(�6G   ���	#FF9C27B0
�������$��0q�5O   S    5P   D   �� 5Q      5R      5T      5V      5W      5X      