   M S B A M L   `   `   `  ����  NgoSyGiaWPF    NgoSyGiaWPF.ReportsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Reports��5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6   $!��Revenue and Booking Reports��6!   $��24(�5      $
��Bold"�6"   ���	#FF1976D2$��0,0,0,20q�5   +   �� 5   
   $��1��6   ���	#FFF5F5F5 �� Padding$ 15q�65    �� CornerRadius$ 5��6B   $��0,0,0,20q�6S   ._�5      �� .+�5      �� $8��2Select Report Period (sorted in descending order):��6   $
��Bold"�6V   $��16(�6h   $��0,0,0,10q�6v   � 5       � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $	��150 �6+   �� 5      $
��Auto �6+   �� 5      $	��150 �6+   �� 5      $
��Auto �6+   .+�5      �� $��0��6    $��From:��60   $��Center=�6=   $��0,0,10,0q�6X   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpStartDate��5   1   $��1��6!   $��30��6D   $��0,0,20,0q�6P   �� 5       $��2��6    $	��To:��60   $��Center=�6;   $��0,0,10,0q�6V     5!      -   5        $��	dpEndDate��5!   1   $��3��6!   $��30��6B   $��0,0,20,0q�6N   �� 5"      -   5        $��btnGenerateReport��5"   -   $��4��6   $��Generate Report��6F   $��30��5#      $
��15,5q�6)   ���	#FF4CAF50
�������$��0q�5$      $
��Bold"�61   6C   5%      5&      5'      �� 5*   
   $��2��6   $��14(�6"   .@�5+      �� $��Revenue Report��6   $��14(�6.   .��5,      � $��10q�6    5-      �� 5.      $
��Auto �6(   �� 5/      $��* �6(   .+�53      � $��0��6   $��0,0,0,20q�6(    54      �� 55      $��* �6/   �� 56      $��* �6/   �� 57      $��* �6/   .+�5:      �� $��0��6!   ���	#FF2196F3$ 5��6H   $ 15q�6Y   $��0,0,5,0q�6f   ._�5;      �� $��Center=�6)   .+�5<   "   �� $��Total Revenue��6,   
�������$��12(�6T   $��Center=�6b   �� 5=   "   -   5        $��lblTotalRevenue��5=   ,   $��$0.00��6C   
�������$��18(�6c   $
��Bold"�6q   $��Center=�6�   5>      5?      �� 5A      $��1��6!   ���	#FF4CAF50$ 5��6H   $ 15q�6Y   $	��5,0q�6f   ._�5B      �� $��Center=�6)   .+�5C   "   �� $��Total Bookings��6,   
�������$��12(�6U   $��Center=�6c   �� 5D   "   -   5        $��lblTotalBookings��5D   ,   $��0��6D   
�������$��18(�6`   $
��Bold"�6n   $��Center=�6�   5E      5F      �� 5H      $��2��6!   ���	#FFFF9800$ 5��6H   $ 15q�6Y   $��5,0,0,0q�6f   ._�5I      �� $��Center=�6)   .+�5J   "   �� $��Average Booking Value��6,   
�������$��12(�6\   $��Center=�6j   �� 5K   "   -   5        $��lblAverageBooking��5K   ,   $��$0.00��6E   
�������$��18(�6e   $
��Bold"�6s   $��Center=�6�   5L      5M      5N      &   System.Windows.Controls.DataGrid  5Q      -   5        $��dgRevenueReport��5Q   ,   $��1��6      AutoGenerateColumns$ False��6C      
IsReadOnly$
 True��5R         GridLinesVisibility$ 
Horizontal=�61      HeadersVisibility$ Column=�6R   	   AlternatingRowBackground	 �	#FFF9F9F9
   Columns
 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$ Booking Date��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *BookingDate+ �� StringFormat$ 
dd/MM/yyyy��6�     5V      $ 
Booking ID��61   $	 100 6n    6E   �� *BookingReservationID+6n     5W      $ Customer��61   $	 180 6q    6C   �� *Customer.CustomerFullName+6q     5X      $ Total Amount��61   $	 120 6v    6G   �� *
TotalPrice+$ C��6v     5Y      $ Status��61   $ 80 6c    6A   �� *BookingStatus+6c   5[      5\      5]      �� 5_      $��Booking Statistics��6   $��14(�62   .��5`        -   5        $��dgBookingStats��5`      $ False��61   $
 True��6M   $��10q�6_   $ 
Horizontal=�5a      $ Column=�6<   	 �	#FFF9F9F9
 5b        5c      $ Room Number��6-   $	 120 6a    6B   �� *
RoomNumber+6a     5d      $ 	Room Type��6-   $	 150 6a    6@   �� *RoomTypeName+6a     5e      $ Total Bookings��6-   $	 120 6g    6E   �� *TotalBookings+6g     5f      $ Total Revenue��6-   $	 150 6u    6D   �� *TotalRevenue+$ C��6u     5g      $ Occupancy Rate��6-   $	 120 6x    6E   �� *OccupancyRate+$ P1��6x   5i      5j      5k      5l      5m      