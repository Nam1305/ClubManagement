   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   $    ClubManagement.ChairmanApprove   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  ChairmanApprove��5   	   $	��450��6!   $	��800��6.   .��5	      � .+�5
   
   ��  �� CornerRadius$ 10��6   $��1q�6#   
������� �� Padding$ 10q�6J   
�������$��0,0,-26,-38q�6j   ._�5      �� .+�5      �� $$��📋 Phê Duyệt Thành Viên��6   $��20(�6;   $
��Bold"�6I   $��0,0,0,10q�6[   �� 5      $	��300��6   .��5      &   System.Windows.Controls.DataGrid  -   5        $��	dgApprove��5         AutoGenerateColumns$ False��60      SelectionMode$ Single=�6L      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *
UserClubId+6\     5      $ 	Full Name��61   $	 100 6f    6D   �� *User.FullName+6f     5      $
 Club��61   $	 100 6a    6?   �� *Club.ClubName+6a     5      $ Status��61   $	 150 6\    6A   �� *Status+6\     5      $ 
Apply Date��61   $	 150 6~    6E   �� *	AppliedAt+	 �� StringFormat$	 
dd/MM/yyyy��6~     5      $ Approve Date��61   $	 150 6�    6G   �� *
ApprovedAt+$	 
dd/MM/yyyy��6�   5      5      �� 5      -   5        $��	txtUserId��5   i   $��0��6   $��2��6'   $��3q�67   $	��300��6B   $
��Left=�6N   $��30��6z   $y�	Collapsed=�6�   6�   �� 5      -   5        $��txtUserClubId��5   i   $��0��6   $��3��6'   $��3q�67   $	��300��6B   $
��Left=�6N   $��30��6~   $y�	Collapsed=�6�   6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpAppliedAt��5   l   $��3��6   $��4��6*   $��3q�6:   $	��300��6E   $
��Left=�6Q   $y�	Collapsed=�6   6�   �� 5"      
 �� Orientation$
 
Horizontal=�6   $��Center=�66   $��0,10,0,0q�6S   .+�5#      �� -   5        $��	btnAccept��5#   �   $��
✔ Accept��6   
��� � �
�������$
��10,5q�6w   $��5q�6�   {�60   �� *
CanApprove+6�   �� 5$      -   5        $��
btnDecline��5$   �   $��❌ Decline��6   
���  ��
�������$
��10,5q�6v   $��5q�6�   {�61   �� *
CanApprove+6�   5%      5(      5)      5*      5+      