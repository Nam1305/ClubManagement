   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   !    ClubManagement.Chairmanhome   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  Chairmanhome��5   	   $	��450��6   $	��800��6+   .��5	      � 
����ح� � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��	FullName:��6-   �� 5   
   $��1��6   $��0��6   $��Email:��6-   �� 5   
   $��2��6   $��0��6   $��Role :��6-   �� 5   
   $��3��6   $��0��6   $��Student number:��6-   �� 5   
   $��4��6   $��0��6   $��	UserName:��6-   �� 5   
   -   5        $��txtFullname��5   a   $��0��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   6v   �� 5    
   -   5        $��txtEmail��5    a   $��1��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   6s   �� 5!   
   -   5        $��cbRole��5!   b   $��2��6   $��1��6    $��3q�60   $	��300��6;   $
��Left=�6G   6r   �� 5#   
   -   5        $��txtStudentNumber��5#   a   $��3��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   6{   �� 5$   
   -   5        $��txtUsername��5$   a   $��4��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   6v   �� 5&   
   $��5��6   $��2��6"   $��3q�62   $	��300��6=    �� Orientation$ 
Horizontal=�6I   $
��Left=�6b   .+�5'      �� -   5        $��btnAdd��5'   <   $��3q�6   $��80��6    $	��Add��6.   6J   �� 5(      -   5        $��	btnUpdate��5(   ?   $��3q�6   $��80��6    $��Update��6.   6?   �� 5)      -   5        $��	btnDelete��5)   ?   $��3q�6   $��80��6    $��Delete��6.   6?   5*      &   System.Windows.Controls.DataGrid  5,   
   -	   5        $��	dgMembers��5,   4   $��8��6   $��2��6       AutoGenerateColumns$ False��6E      
IsReadOnly$
 True��6a      Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Fullname��6/   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6A   �� *
FullName+  5/      $ * 6%   $ Email��6/   	 6>   �� *Email+  50      $ * 6%   $
 Role��6/   	 6=   �� *Role.RoleName+  51      $ * 6%   $ StudentNumber��6/   	 6F   �� *StudentNumber+  52      $ * 6%   $ Username��6/   	 6A   �� *
Username+  53      $ * 6%   $ 	Club Name��6/   	 6B   �� *
ClubName+  54      $ * 6%   $ 
Applied At��6/   	 6C   �� *	AppliedAt+
 �� StringFormat$
 {0:dd/MM/yyyy}��  55      $ * 6%   $ Approved At��6/   	 6D   �� *
ApprovedAt+$
 {0:dd/MM/yyyy}��58      59      5:      