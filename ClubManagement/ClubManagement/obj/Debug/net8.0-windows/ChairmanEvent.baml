   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   "    ClubManagement.ChairmanEvent   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  ChairmanEvent��5   	   $	��450��6   $	��800��6,   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6     � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5    
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgEvents��5       $��2��6%   $��2��65   $��9��6B   $��2��6S      AutoGenerateColumns$ False��6g      
IsReadOnly$
 True��6�      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ 
EventId ID��6/   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6C   �� *	EventId+  5#      $ * 6%   $ 
Event Name��6/   	 6C   �� *	EventName+  5$      $ * 6%   $ Status��6/   	 6?   �� *Status+  5%      $ * 6%   $ Description��6/   	 6D   �� *Description+  5&      $ * 6%   $ 
Event Date��6/   	 6C   �� *	EventDate+  5'      $ * 6%   $ Location��6/   	 6A   �� *
Location+  5(      $ * 6%   $ ClubId��6/   	 6?   �� *ClubId+5*      �� 5,   
   -   5        $��txtSearchEvent��5,   a   $��0��6   $��2��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $��30��6w   6�   �� 5.   
   $��0��6   $��1��6   $��Manage Event��6-   
���  ��$��Center=�6U   $��25(�6r   �� 5/   
   -   5        $��
txtEventId��5/   a   $��1��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   
 �� 
IsReadOnly$

 True��6s   $y�	Collapsed=�6�   6�   �� 50   
   $��2��6   $��0��6   $��Event Name:��6-   �� 51   
   $��3��6   $��0��6   $��Status:��6-   �� 52   
   $��4��6   $��0��6   $��Description:��6-   �� 53   
   $��5��6   $��0��6   $��Event Date:��6-   �� 54   
   $��6��6   $��0��6   $��	Location:��6-   �� 55   
   -   5        $��txtEventName��55   a   $��2��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   6w   �� 56   
   -   5        $��cbStatus��57   &   $��3��56      $��1��6    $��3q�60   $	��300��6;   $
��Left=�57       �� SelectedIndex$ 0��66   .@�58      �� $��Coming soon��6   �� 59      $��taking place��6   �� 5:      $��Ended��6   5;      �� 5=   
   -   5        $��txtDescription��5=   a   $��4��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $	��100��6w    �� AcceptsReturn$
 True��6�    �� TextWrapping$
 Wrap=�6�   (  "System.Windows.Controls.DatePicker  5>   
   -   5        $��dpdate��5>   d   $��5��6   $��1��6"   $��3q�62   $	��300��6=   $
��Left=�6I   6t   �� 5?   
   -   5        $��txtLocation��5?   a   $��6��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   6v   �� 5@   
   -	   5        $��	txtClubId��5@   a   $��7��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $y�	Collapsed=�6r   6�   �� 5B   
    �� Orientation$ 
Horizontal=�6   $��8��6.   $��1��6;   .+�5C      �� -
   5        $��btnAdd��5C   K   $��80��6   $��30��6#   $��3q�6/   $��Create��6:   6Y   �� 5D      -   5         ��Name$ 	btnUpdate��5D      $��80��6)   $��30��67   $��3q�6C   $��Update��6N   6_   �� 5E      -   5        $ 	btnDelete��5E      $��80��6(   $��30��66   $��3q�6B   $��Delete��6M   6^   5F      5H      5I      