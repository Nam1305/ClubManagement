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
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgTask��5      $��2��6#   $��0��63   $��4��6@      AutoGenerateColumns$ False��6Q      
IsReadOnly$
 True��6m      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Task ID��6/   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6@   �� *TaskId+  5!      $ * 6%   $ 	Task Name��6/   	 6B   �� *
TaskName+  5"      $ * 6%   $ Description��6/   	 6D   �� *Description+  5#      $ * 6%   $ 	Assign to��6/   	 6B   �� *AssignedToNavigation.FullName+  5$      $ * 6%   $ Assigned by��6/   	 6D   �� *AssignedByNavigation.FullName+  5%      $ * 6%   $
 Club��6/   	 6=   �� *Club.ClubName+  5&      $ * 6%   $ Status��6/   	 6?   �� *Status+  5'      $ * 6%   $ Due Date��6/   	 6A   �� *	DueDate+5*        5+   
   -   5        $ dgMember��5+      $��2��6%   $��5��65   $��5��6B   $ False��6S   $
 True��6o    5,        5-      $ * 6%   $ User Id��6/   	 6@   �� *UserId+  5.      $ * 6%   $ Fullname��6/   	 6A   �� *
FullName+  5/      $ * 6%   $ Email��6/   	 6>   �� *Email+  50      $ * 6%   $
 Role��6/   	 6=   �� *
RoleName+  51      $ * 6%   $ StudentNumber��6/   	 6F   �� *StudentNumber+  52      $ * 6%   $ Username��6/   	 6A   �� *
Username+  53      $ * 6%   $ 	Club Name��6/   	 6B   �� *
ClubName+  54      $ * 6%   $ 
Applied At��6/   	 6C   �� *	AppliedAt+
 �� StringFormat$
 {0:dd/MM/yyyy}��  55      $ * 6%   $ Approved At��6/   	 6D   �� *
ApprovedAt+$
 {0:dd/MM/yyyy}��58      �� 59   
   $��0��6   $��1��6   $��Assign Task��6-   
���  ��$��Center=�6T   $��25(�6q   �� 5:   
   -   5        $��	txtTaskId��5:   a   $��1��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F    �� 
IsReadOnly$
 True��6r   $y�	Collapsed=�6�   6�   �� 5;   
   $��2��6   $��0��6   $��Task Title:��6-   �� 5<   
   $��3��6   $��0��6   $��Description:��6-   �� 5=   
   $��4��6   $��0��6   $��
Assign to:��6-   �� 5>   
   $��7��6   $��0��6   $��Status:��6-   �� 5?   
   $��8��6   $��0��6   $��	Due date:��6-   �� 5@   
   -   5        $��txtTaskName��5@   a   $��2��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   6v   �� 5A   
   -   5        $��txtDescription��5A   a   $��3��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $	��100��6w    �� AcceptsReturn$
 True��6�    �� TextWrapping$
 Wrap=�6�   �� 5B   
   -   5        $��txtAssignedTo��5B   a   $��4��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 True��6v   6�   �� 5D   
   $��7��6   $��1��6"   $��3q�62    �� Orientation$ 
Horizontal=�6=   .+�5E      	� -   5         	�Name$ 	rbPending��5E       	� 	GroupName$ gender��6-   .��6@   	Pending6I   	� 5F      -   5        $ rbInprocess��5F      $ gender��6/   .��6B   
In Process6N   	� 5G      -	   5        $ rbCompleted��5G      $ gender��6/   .��6B   	Completed6M   5H      (  "System.Windows.Controls.DatePicker  5I   
   -
   5        $��	dpDueDate��5I   d   $��8��6   $��1��6"   $��3q�62   $	��300��6=   $
��Left=�6I   6w   �� 5J   
   $ 
Horizontal=�6   $��9��6.   $��1��6;   .+�5K      �� -   5        $��btnAdd��5K   K   $��80��6   $��30��6#   $��3q�6/   $��Create��6:   6Y   �� 5L      -   5         ��Name$ 	btnUpdate��5L      $��80��6)   $��30��67   $��3q�6C   $��Update��6N   6_   �� 5M      -   5        $ 	btnDelete��5M      $��80��6(   $��30��66   $��3q�6B   $��Delete��6M   6^   5N      5O      5P      