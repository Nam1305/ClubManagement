   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   *    $ClubManagement.ListEventsParticipant   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  ListEventsParticipant��5   	   $	��450��6'   $	��800��64   .��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��LIST EVENTS PARTICIPANTS��6-   
���  ��$��20(�6a   �� 5   
   $��1��6   $��0��6   $��	Event ID:��6-   �� 5   
   -   5        $��
txtEventId��5   `   $��1��6   $��1��6   $��3q�6/   $��50��6:   $
��Left=�6E    �� 
IsReadOnly$
 True��6r   .��6�   5       �� 5!   
   $��2��6   $��0��6   $��Event Name:��6-   �� 5"   
   -   5        $��txtEventName��5"   a   $��2��6   $��1��6   $��3q�6/   $	��200��6:   $
��Left=�6F   $
 True��6u   .��6�   5$      �� 5%   
   $��3��6   $��0��6   $��Event Status:��6-   �� 5&   
   -   5        $��	txtStatus��5&   a   $��3��6   $��1��6   $��3q�6/   $	��200��6:   $
��Left=�6F   $
 True��6r   .��6�   5(      �� 5)   
   $��4��6   $��0��6   $��Event Description:��6-   �� 5*   
   -   5        $��txtDescription��5*   a   $��4��6   $��1��6   $��3q�6/   $	��200��6:   $
��Left=�6F   $
 True��6w   .��6�   5,      �� 5-   
   $��5��6   $��0��6   $��Event Date:��6-   �� 5.   
   -   5        $��txtDate��5.   a   $��5��6   $��1��6   $��3q�6/   $	��200��6:   $
��Left=�6F   $
 True��6p   .��6�   50      �� 51   
   $��6��6   $��0��6   $��Event Location:��6-   �� 52   
   -   5        $��txtLocation��52   a   $��6��6   $��1��6   $��3q�6/   $	��200��6:   $
��Left=�6F   $
 True��6t   .��6�   53      �� 54   
   $��7��6   $��0��6   $��
Club Host:��6-   �� 55   
   -   5        $��txtHost��55   a   $��7��6   $��1��6   $��3q�6/   $	��200��6:   $
��Left=�6F   $
 True��6p   .��6�   56      &   System.Windows.Controls.DataGrid  58   
   -   5        $��dgData��58   4   $��8��6   $��3��6       AutoGenerateColumns$ False��6B      
IsReadOnly$
 True��6^      Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Event ID��6/   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6A   �� *	EventId+  5;      $ * 6%   $ 
Event Name��6/   	 6C   �� *Event.EventName+  5<      $ * 6%   $ Status��6/   	 6?   �� *Status+  5=      $ * 6%   $ Description��6/   	 6D   �� *Event.Description+  5>      $ * 6%   $
 Date��6/   	 6=   �� *Event.EventDate+  5?      $ * 6%   $ Location��6/   	 6A   �� *Event.Location+  5@      $ * 6%   $ 	Club Host��6/   	 6B   �� *Event.Club.ClubName+5B      5G      5H      