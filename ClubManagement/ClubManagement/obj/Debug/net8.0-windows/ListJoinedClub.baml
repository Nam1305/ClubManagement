   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   #    ClubManagement.ListJoinedClub   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  ListJoinedClub��5   	   $	��800��6    $	��800��6-   .��5	      �  � RowDefinitions 5
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
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    �� 5      $
��auto �6    �� 5      $��* �6    .+�5!   
   �� $��0��6   $��0��6   $��Member information:��6-   
���  ��$��15(�6\   �� 5"   
   $��1��6   $��0��6   $��Student Number��6-   �� 5#   
   -   5        $��txtStudentNumber��5#   a   $��1��6   $��1��6   $��3q�6/   $	��150��6:   $
��Left=�6F    �� 
IsReadOnly$
 True��6y   �� 5$   
   $��2��6   $��0��6   $��Student Name��6-   �� 5%   
   -   5        $��txtStudentName��5%   a   $��2��6   $��1��6   $��3q�6/   $	��150��6:   $
��Left=�6F   $
 True��6x   �� 5&   
   $��3��6   $��0��6   $��Email��6-   �� 5'   
   -   5        $��txtEmail��5'   a   $��3��6   $��1��6   $��3q�6/   $	��150��6:   $
��Left=�6F   $
 True��6r   �� 5(   
   $��4��6   $��0��6   $��List club joined:��6-   
���  ��$��13(�6Z   �� 5)   
   $��5��6   $��0��6   $��Search��6-   �� 5+   
   -   5        $��	txtSearch��5+   a   $��5��6   $��1��6   $��3q�6/   $	��100��6:   $
��Left=�6F   6r   &   System.Windows.Controls.DataGrid  5-   
   -   5        $��dgClubJoined��5-      $��3q�6'   $��6��62   $��2��6?      AutoGenerateColumns$ False��6S      
IsReadOnly$
 True��6o      Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ 	Club Name��6/   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6B   �� *Club.ClubName+  50      $ * 6%   $ Description��6/   	 6D   �� *Club.Description+  51      $ * 6%   $ Establish Date��6/   	 6G   �� *Club.EstablishedDate+  52      $ * 6%   $ Status��6/   	 6?   �� *Club.Status+54      �� 56   
   $��1��6   $��3��6   $��Club information:��6-   
���  ��$��15(�6Z   �� 57   
   $��2��6   $��2��6   $��
Club Name:��6-   �� 58   
   $��3��6   $��2��6   $��Description:��6-   �� 59   
   $��4��6   $��2��6   $��Establish Date:��6-   �� 5:   
   -   5        $��txtClubName��5:   a   $��2��6   $��3��6   $��3q�6/   $	��100��6:   $
��Left=�6F   $
 True��6u   �� 5;   
   -   5        $��txtDescription��5;   a   $��3��6   $��3��6   $��3q�6/   $	��230��6:   $
��Left=�6F   $
 True��6x   �� 5<   
   -   5        $��txtEstablishDate��5<   a   $��4��6   $��3��6   $��3q�6/   $	��100��6:   $
��Left=�6F   $
 True��6z   �� 5=   
   $��5��6   $��2��6   $!��List club wait for approve:��6-   
���  ��$��15(�6d     5?   
   -	   5        $��dgClubApproving��5?      $��3q�6*   $��6��65   $��2��6B   $��2��6R   $ False��6f   $
 True��6�    5@        5A      $ * 6%   $ 	Club Name��6/   	 6B   �� *Club.ClubName+  5B      $ * 6%   $ Description��6/   	 6D   �� *Club.Description+  5C      $ * 6%   $ Establish Date��6/   	 6G   �� *Club.EstablishedDate+  5D      $ * 6%   $ Status��6/   	 6?   �� *Club.Status+5F      5T      5U      