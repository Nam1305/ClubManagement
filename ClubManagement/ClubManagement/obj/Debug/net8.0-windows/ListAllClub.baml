   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	        ClubManagement.ListAllClub   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  ListAllClub��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��JOIN A CLUB��6-   
���  ��$��20(�6T   �� 5   
   $��1��6   $��0��6   $��Club ID:��6-   �� 5   
   $��2��6   $��0��6   $��
Club Name:��6-   �� 5   
   $��3��6   $��0��6   $��Description:��6-   �� 5    
   $��4��6   $��0��6   $��Establish Date:��6-   �� 5"   
   -   5        $��	txtClubId��5"   a   $��1��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F    �� 
IsReadOnly$
 True��6r   .��6�   5$      �� 5'   
   -   5        $��txtClubName��5'   a   $��2��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 True��6t   .��6�   5)      �� 5+   
   -   5        $��txtDescription��5+   a   $��3��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 True��6w   .��6�   5-      (  "System.Windows.Controls.DatePicker  5/   
   -   5        $��dpEstablishDate��5/   d   $��4��6   $��1��6"   $��3q�62   $	��300��6=   $
��Left=�6I   ${�False��6{   6�   �� 50   
   $��5��6   $��0��6   $��Search CLub By Name:��6-   �� 51   
   -   5        $��	txtSearch��51   a   $��5��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   6�   �� 53   
   -   5         ��Name$ btnJoin��53      $	��200��6"   $��3q�6.   $��Center=�69   $��7��6V   $��1��6c   $��	Join Club��6s   6�   �� 56   
   $��8��6   $��0��6   $��List All Club:��6-   
���  ��$��12(�6W   &   System.Windows.Controls.DataGrid  57   
   -   5        $��
dgDataClub��57   4   $��9��6   $��2��6       AutoGenerateColumns$ False��6F      
IsReadOnly$
 True��6b      Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%   	   Header$	 ClubId��6/   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6?   �� *ClubId+  5:      $ * 6%   $	 	Club Name��6/   
 6B   �� *
ClubName+  5;      $ * 6%   $	 Description��6/   
 6D   �� *Description+  5<      $ * 6%   $	 Establish Date��6/   
 6G   �� *EstablishedDate+ �� StringFormat$ {0:dd-MM-yyyy}��  5=      $ * 6%   $	 Status��6/   
 6?   �� *Status+5?      5@      5A      