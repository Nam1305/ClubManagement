   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   %    ClubManagement.MemberManagement   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  	Adminhome��5   	   $	��450��6   $	��800��6(   .��5	      �  � RowDefinitions 5
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
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5    
   �� $��0��6   $��0��6   $��Student Number:��6-   �� 5!   
   $��1��6   $��0��6   $��
Full Name:��6-   �� 5"   
   $��2��6   $��0��6   $��Email:��6-   �� 5#   
   $��3��6   $��0��6   $��
User Name:��6-   �� 5$   
   $��4��6   $��0��6   $��Status:��6-   �� 5%   
   $��5��6   $��0��6   $��Role:��6-   �� 5&   
   $��7��6   $��0��6   $��Search by Student Number:��6-   �� 5'   
   $��8��6   $��0��6   $��Search by Full Name:��6-   �� 5(   
   $��9��6   $��0��6   $��Search by Email:��6-   �� 5)   
   $��10��6   $��0��6   $��Search by User Name:��6.   �� 5,   
   -   5        $��txtStudentNumber��5,   a   $��0��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F    �� 
IsReadOnly$
 True��6y   .��6�   5.      �� 50   
   -   5        $��txtFullName��50   a   $��1��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 True��6t   .��6�   52      �� 54   
   -   5        $��txtEmail��54   a   $��2��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 True��6q   .��6�   56      �� 58   
   -   5        $��txtUserName��58   a   $��3��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 True��6t   .��6�   5:      �� 5<   
   $��4��6   $��1��6#    �� Orientation$ 
Horizontal=�63   .+�5=      	� -   5         	�Name$ rbActive��5=       d� 	IsChecked$
 TrueY�6,   .��6=   Active6E   	� 5>      -   5        $ 
rbInactive��5>      .��6.   
Inactive68   5?      �� 5A   
   -   5        $��cbRole��5A   b   $��5��6   $��1��6    $��3q�60   $	��300��6;   $
��Left=�6G   5C      �� 5D   
   $��6��6   $��1��6"   $ 
Horizontal=�62   .+�5E      �� -   5         ��Name$ 	btnUpdate��5E      $��80��6(   $��3q�66   $��Update��6A   6R   �� 5F      -	   5        $ 	btnFilter��5F      $��80��6)   $��3q�67   $��Filter by role��6B   6[   5G      �� 5H   
   -
   5        $��txtStudentNumberSearch��5H   a   $��7��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   .��6�   5J      �� 5L   
   -   5        $��txtFullNameSearch��5L   a   $��8��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   .��6�   5N      �� 5Q   
   -   5        $��txtEmailSearch��5Q   a   $��9��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   .��6�   5S      �� 5T   
   -   5        $��txtUserNameSearch��5T   b   $��10��6   $��1��6    $��3q�60   $	��300��6;   $
��Left=�6G   .��6�   5V      �� 5Y   
   -   5        $ btnReset��5Y      $	��160��6#   $��3q�6/   $��Center=�6:   $��11��6W   $��1��6e   $��Reset��6u   6�   &   System.Windows.Controls.DataGrid  5[   
   -   5        $��
dgDataUser��5[   5   $��12��6   $��3��6!      AutoGenerateColumns$ False��6G   	   
IsReadOnly$
	 True��6c   
   Columns
 5\      0  *System.Windows.Controls.DataGridTextColumn  5]      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Student Number��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *StudentNumber+  5^      $ * 6%   $ 	Full Name��6/    6B   �� *
FullName+  5_      $ * 6%   $ Email��6/    6>   �� *Email+  5`      $ * 6%   $
 Role��6/    6=   �� *Role.RoleName+  5a      $ * 6%   $ 	User Name��6/    6B   �� *
Username+  5b      $ * 6%   $ Status��6/    6?   �� *Status+5d      5i      5j      