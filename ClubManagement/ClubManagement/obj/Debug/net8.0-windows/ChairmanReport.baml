   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   #    ClubManagement.ChairmanReport   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  ChairmanReport��5   	   $	��450��6    $	��800��6-   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6     � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgReports��5      $��2��6&   $��8��66      AutoGenerateColumns$ False��6G      
IsReadOnly$
 True��6c      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Created Date��6/   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6E   �� *CreatedDate+  5      $ * 6%   $ 	Report Id��6/   	 6B   �� *
ReportId+  5      $ * 6%   $ Semester��6/   	 6A   �� *
Semester+  5       $ * 6%   $ Member Changes��6/   	 6G   �� *MemberChanges+  5!      $ * 6%   $ Event Summary��6/   	 6F   �� *EventSummary+  5"      $ * 6%   $ Participation status��6/   	 6M   �� *ParticipationStatus+  5#      $ * 6%   $ ClubId��6/   	 6?   �� *ClubId+5%      �� 5(   
   $��0��6   $��1��6   $��View Reports��6-   
���  ��$��Center=�6U   $��25(�6r   �� 5)   
   $��1��6   $��0��6   $��
Report Id:��6-   �� 5*   
   -   5        $��txtReportId��5*   a   $��1��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   
 �� 
IsReadOnly$

 True��6t   6�   �� 5+   
   $��2��6   $��0��6   $��Create Date:��6-   �� 5,   
   $��3��6   $��0��6   $��	Semester:��6-   �� 5-   
   $��4��6   $��0��6   $��Member changes:��6-   �� 5.   
   $��5��6   $��0��6   $��Event summary:��6-   �� 5/   
   $��6��6   $��0��6   $��Participation status:��6-   �� 50   
   $��7��6   $��0��6   $��Club Id:��6-   �� 51   
   -   5        $��txtCreateDate��51   a   $��2��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $

 True��6v   6�   �� 52   
   -   5        $��txtSemester��52   a   $��3��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $

 True��6t   6�   �� 53   
   -   5        $��txtMemberChanges��53   a   $��4��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $

 True��6y   6�   �� 54   
   -   5        $��txtEventSummary��54   a   $��5��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $

 True��6x   6�   �� 55   
   -   5        $��txtParticipationStatus��55   a   $��6��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $

 True��6   6�   �� 56   
   -   5        $��	txtClubId��56   a   $��7��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $

 True��6r   6�   58      59      