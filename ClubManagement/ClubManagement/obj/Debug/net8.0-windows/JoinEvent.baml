   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	       ClubManagement.JoinEvent   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  	JoinEvent��5   	   $	��450��6   $	��800��6(   .��5	      �  � RowDefinitions 5
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
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��EVENT DETAIL:��6-   
���  ��$��20(�6V   �� 5   
   $��1��6   $��0��6   $��	Event ID:��6-   �� 5   
   $��2��6   $��0��6   $��Event Name:��6-   �� 5   
   $��3��6   $��0��6   $��Event Date:��6-   �� 5    
   $��4��6   $��0��6   $��Event Description:��6-   �� 5!   
   $��5��6   $��0��6   $��Event Location:��6-   �� 5"   
   $��6��6   $��0��6   $��
Club Host:��6-   �� 5$   
   -   5        $��
txtEventId��5$   `   $��1��6   $��1��6   $��3q�6/   $��50��6:   $
��Left=�6E    �� 
IsReadOnly$
 True��6r   .��6�   5%      �� 5'   
   -   5        $��txtEventName��5'   a   $��2��6   $��1��6   $��3q�6/   $	��200��6:   $
��Left=�6F   $
 True��6u   .��6�   5(      �� 5*   
   -   5        $��txtDate��5*   a   $��3��6   $��1��6   $��3q�6/   $	��200��6:   $
��Left=�6F   $
 True��6p   .��6�   5+      �� 5-   
   -   5        $��txtDescription��5-   a   $��4��6   $��1��6   $��3q�6/   $	��200��6:   $
��Left=�6F   $
 True��6w   .��6�   5.      �� 50   
   -   5        $��txtLocation��50   a   $��5��6   $��1��6   $��3q�6/   $	��200��6:   $
��Left=�6F   $
 True��6t   .��6�   51      �� 53   
   -   5        $��txtClubHost��53   a   $��6��6   $��1��6   $��3q�6/   $	��200��6:   $
��Left=�6F   $
 True��6t   .��6�   54      �� 56   
   -   5         ��Name$ btnJoinEvent��56      $��7 ��6'   $��1��65   $��3q�6E   $��80��6P   $��Center=�6[   $��20��6x   $��Join this event��6�   6�   &   System.Windows.Controls.DataGrid  58   
   -   5        $��dgData��58   4   $��8��6   $��3��6       AutoGenerateColumns$ False��6B      
IsReadOnly$
 True��6^      Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%   	   Header$	 Event ID��6/   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6A   �� *	EventId+  5;      $ * 6%   $	 
Event Name��6/   
 6C   �� *	EventName+  5<      $ * 6%   $	 Description��6/   
 6D   �� *Description+  5=      $ * 6%   $
	 Date��6/   
 6=   �� *	EventDate+  5>      $ * 6%   $	 Location��6/   
 6A   �� *
Location+  5?      $ * 6%   $	 	Club Host��6/   
 6B   �� *Club.ClubName+5A      5F      5G      