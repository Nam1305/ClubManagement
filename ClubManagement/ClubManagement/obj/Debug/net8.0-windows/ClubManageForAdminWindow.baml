   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   -    'ClubManagement.ClubManageForAdminWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  ClubManageForAdminWindow��5   	   $	��450��6*   $	��800��67   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��ClubId:��6-   �� 5   
   -   5        $��	txtClubId��5   a   $��0��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F    �� 
IsReadOnly$
 True��6r   .��6�   5      �� 5!   
   $��1��6   $��0��6   $��
Club Name:��6-   �� 5"   
   $��2��6   $��0��6   $��Description:��6-   �� 5#   
   $��3��6   $��0��6   $��Establish Date:��6-   �� 5$   
   $��4��6   $��0��6   $��Status:��6-   �� 5&   
   -   5        $��txtClubName��5&   a   $��1��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   .��6t   5(      �� 5*   
   -   5        $��txtDescription��5*   a   $��2��6   $��1��6   $��3q�6/   $	��500��6:   $
��Left=�6F   .��6w   5,      (  "System.Windows.Controls.DatePicker  5.   
   -   5        $��dpEstablishDate��5.   d   $��3��6   $��1��6"   $��3q�62   $	��300��6=   $
��Left=�6I   6d   �� 50   
   $��4��6   $��1��6#    �� Orientation$ 
Horizontal=�63   .+�51      	� -   5         	�Name$ rbActive��51      .��6,   Active64   	� 52      -   5        $ 
rbInactive��52      .��6.   
Inactive68   53      �� 55   
   $��5��6   $��1��6"   $ 
Horizontal=�62   .+�56      �� -   5         ��Name$ btnAdd��56      $��80��6%   $��3q�63   $	��Add��6>   6L   �� 57      -   5        $ 	btnUpdate��57      $��80��6(   $��3q�66   $��Update��6A   6R   58      �� 5:   
   $��6��6   $��0��6   $��Search By Club Name:��6-   �� 5;   
   -	   5        $��txtClubNameSearch��5;   a   $��6��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   .��6�   5=      �� 5>   
   -
   5        $ btnReset��5>      $��7��6#   $��1��60   $��3q�6@   $��Center=�6K   $��80��6h   $��Reset��6v   6�   &   System.Windows.Controls.DataGrid  5@   
   -   5        $��
dgDataClub��5@   4   $��8��6   $��3��6       AutoGenerateColumns$ False��6F      
IsReadOnly$
 True��6b   	   Columns	 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6%      Header$ ClubId��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *ClubId+  5C      $
 * 6%   $ 	Club Name��6/    6B   �� *
ClubName+  5D      $
 * 6%   $ Description��6/    6D   �� *Description+  5E      $
 * 6%   $ Establish Date��6/    6G   �� *EstablishedDate+ �� StringFormat$ {0:dd-MM-yyyy}��  5F      $
 * 6%   $ Status��6/    6?   �� *Status+5H      5J      5K      