   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   !    ClubManagement.Chairmanhome   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  Chairmanhome��5   	   $	��450��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��User Id:��6-   �� 5   
   $��1��6   $��0��6   $��	FullName:��6-   �� 5   
   $��2��6   $��0��6   $��Email:��6-   �� 5   
   $��3��6   $��0��6   $��Role :��6-   �� 5   
   $��4��6   $��0��6   $��Student number:��6-   �� 5    
   $��5��6   $��0��6   $��	UserName:��6-   �� 5"   
   -   5        $��	txtUserId��5"   a   $��0��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F    �� 
IsReadOnly$
 True��6r   6�   �� 5$   
   -   5        $��txtFullname��5$   a   $��1��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 True��6t   6�   �� 5%   
   -   5        $��txtEmail��5%   a   $��2��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 True��6q   6�   �� 5&   
   -   5        $��cbRole��5&   b   $��3��6   $��1��6    $��3q�60   $	��300��6;   $
��Left=�6G   6r   �� 5(   
   -   5        $��txtStudentNumber��5(   a   $��4��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 True��6y   6�   �� 5)   
   -   5        $��txtUsername��5)   a   $��5��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 True��6t   6�   �� 5+   
   $��6��6   $��2��6"   $��3q�62   $	��300��6=    �� Orientation$ 
Horizontal=�6I   $
��Left=�6b   .+�5,      �� -   5        $��	btnUpdate��5,   ?   $��3q�6   $��80��6    $��Update��6.   6P   �� 5-      -   5        $��	btnDelete��5-   ?   $��3q�6   $��80��6    $��Delete��6.   6P   5.      �� 5/   
   $��7��6   $��0��6   $�� ��6-   �� 50   
   $��8��6   $��0��6   $��Search:��6-   �� 51   
   -	   5        $��	txtSearch��51   a   $��8��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   6�   &   System.Windows.Controls.DataGrid  53   
   -
   5        $��	dgMembers��53   5   $��10��6   $��2��6!      AutoGenerateColumns$ False��6F      
IsReadOnly$
 True��6b      Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%   	   Header$	 User Id��6/   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6@   �� *UserId+  56      $ * 6%   $	 Fullname��6/   
 6A   �� *
FullName+  57      $ * 6%   $	 Email��6/   
 6>   �� *Email+  58      $ * 6%   $
	 Role��6/   
 6=   �� *
RoleName+  59      $ * 6%   $	 StudentNumber��6/   
 6F   �� *StudentNumber+  5:      $ * 6%   $	 Username��6/   
 6A   �� *
Username+  5;      $ * 6%   $	 	Club Name��6/   
 6B   �� *
ClubName+  5<      $ * 6%   $	 
Applied At��6/   
 6C   �� *	AppliedAt+ �� StringFormat$ {0:dd/MM/yyyy}��  5=      $ * 6%   $	 Approved At��6/   
 6D   �� *
ApprovedAt+$ {0:dd/MM/yyyy}��5@      5A      5B      