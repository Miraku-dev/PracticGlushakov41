   M S B A M L   `   `   `  ����M  IHotelBookingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+    %HotelBookingSystem.Views.BookingsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��5q�6;   .+�5      �� $��Load Bookings��6   $��5q�6U   $��10q�6`   ��6-   �� *LoadBookingsCommand+6`   �� 5      $��Load Available Rooms��6   $��5q�6b   $��10q�6m   ��64   �� *LoadAvailableRoomsCommand+6m   �� 5      $��Cancel Booking��6   $��5q�6W   $��10q�6b   ��6.   �� *CancelBookingCommand+6b   5      �� 5   
   $��New Booking��6   $��1��6(   $��5q�65   .��5      �� $ 
Horizontal=�6   .+�5      ��  �� DisplayMemberPath$ Number��5      $	��120��66   $��5q�6B   ��5      �� *AvailableRooms+ �� SelectedItem 6B   �� *SelectedRoom+5   B   �� 5      $	��200��65   $��5q�6A   $��5q�6L   ��6   �� *	GuestName+6L   (  "System.Windows.Controls.DatePicker  5      $	��150��6B   $��5q�6N      SelectedDate 6   �� *CheckInDate+6N     5      $	��150��6C   $��5q�6O    6   �� *CheckOutDate+6O   �� 5      $��	Book Room��6   $��5q�6Q   $��10q�6\   ��6-   �� *BookRoomCommand+6\   5      5      &   System.Windows.Controls.DataGrid  5    
   $��2��6]   $��5q�6j      AutoGenerateColumns$ False��5!         CanUserAddRows$ False��6/   ��5       �� *
Bookings+ 64   �� *SelectedBooking+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$
 Room��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6S   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *Room.Number+6S     5$      $ Guest��6%   $		 200 6R   
 64   �� *	GuestName+6R     5%      $ Check-In��6%   $		 120 6g   
 67   �� *CheckInDate+ �� StringFormat$ d��6g     5&      $ 	Check-Out��6%   $		 120 6i   
 68   �� *CheckOutDate+$ d��6i     5'      $ Booking Date��6%   $		 120 6k   
 6;   �� *BookingDate+$ d��6k   5)      5*      5+      