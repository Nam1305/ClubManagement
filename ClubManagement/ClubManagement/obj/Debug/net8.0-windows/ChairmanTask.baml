   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   !    ClubManagement.ChairmanTask   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  ChairmanTask��5   	   $	��450��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6     � RowDefinitions 5   
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
��Auto �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgTask��5      $��2��6#   $��8��63      AutoGenerateColumns$ False��6D      
IsReadOnly$
 True��6`      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Task ID��6/   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6@   �� *TaskId+  5!      $ * 6%   $ 	Task Name��6/   	 6B   �� *
TaskName+  5"      $ * 6%   $ Description��6/   	 6D   �� *Description+  5#      $ * 6%   $ 	Assign to��6/   	 6B   �� *
AssignedTo+  5$      $ * 6%   $ Assigned by��6/   	 6D   �� *
AssignedBy+  5%      $ * 6%   $ Club Id��6/   	 6@   �� *ClubId+  5&      $ * 6%   $ Status��6/   	 6?   �� *Status+  5'      $ * 6%   $ Due Date��6/   	 6A   �� *	DueDate+5*      �� 5,   
   $��0��6   $��1��6   $��Assign Task��6-   
���  ��$��Center=�6T   $��25(�6q   �� 5-   
   -   5        $��	txtTaskId��5-   a   $��1��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   
 �� 
IsReadOnly$

 True��6r   $y�	Collapsed=�6�   6�   �� 5.   
   $��2��6   $��0��6   $��Task Title:��6-   �� 5/   
   $��3��6   $��0��6   $��Description:��6-   �� 50   
   $��4��6   $��0��6   $��
Assign to:��6-   �� 51   
   $��7��6   $��0��6   $��Status:��6-   �� 52   
   $��8��6   $��0��6   $��	Due date:��6-   �� 53   
   -   5        $��txtTaskName��53   a   $��2��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   6v   �� 54   
   -   5        $��txtDescription��54   a   $��3��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $	��100��6w    �� AcceptsReturn$
 True��6�    �� TextWrapping$
 Wrap=�6�   �� 55   
   -   5        $��txtAssignedTo��55   a   $��4��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $

 True��6v   6�   �� 56   
   $��7��6   $��1��6"   $��3q�62   $
��Left=�6=   .+�57      �� -   5         ��Name$ 	cbPending��57      .��6*   	Pending63   �� 58      -   5        $ cbInprocess��58      .��6-   
In Process69   �� 59      -   5        $ cbCompleted��59      .��6-   	Completed68   5:      (  "System.Windows.Controls.DatePicker  5;   
   -	   5        $��	dpDueDate��5;   d   $��8��6   $��1��6"   $��3q�62   $	��300��6=   $
��Left=�6I   6w   �� 5<   
    �� Orientation$ 
Horizontal=�6   $��9��6.   $��1��6;   .+�5=      �� -
   5        $��btnAdd��5=   K   $��80��6   $��30��6#   $��3q�6/   $��Create��6:   6Y   �� 5>      -   5         ��Name$ 	btnUpdate��5>      $��80��6)   $��30��67   $��3q�6C   $��Update��6N   6_   �� 5?      -   5        $ 	btnDelete��5?      $��80��6(   $��30��66   $��3q�6B   $��Delete��6M   6^   5@      5A      5B      