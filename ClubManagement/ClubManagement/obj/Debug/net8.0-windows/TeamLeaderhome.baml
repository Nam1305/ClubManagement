   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   #    ClubManagement.TeamLeaderhome   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  Team Leader Home��5   	   $	��600��6"   $	��900��6/    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $ Styles.xaml?�6%   %    5      .��5      � $��10q�6   .+�5   
   �� -   5         ��Name$ 
TabControl��5      .@�5      �� $��Nhóm của tôi��6   .��5      �  � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $
��Auto �6+   .+�5      �� -   5         ��Name$ GroupsListView��5      $	��450��67   $	��Top=�6D   $
��Auto=�6\    �� View 5      �� 5      .P�5   "   �� $��
Tên nhóm��61    �� Width$	 150��6n   	 �� DisplayMemberBinding	 6C   �� *	GroupName+6n   �� 5   "   $��Sự kiện��61   $	 150��6s   	 6B   �� *Event.EventName+6s   �� 5   "   $��Ngày tạo��61   $	 100��6�   	 6C   �� *	CreatedAt+
 �� StringFormat$
 {0:dd/MM/yyyy}��6�   �� 5    "   $��Trạng thái��61   $	 100��6m   	 6E   �� *Status+6m   �� 5!   "   $��Hành động��61   $	 200��6D    �� CellTemplate 5"   &   �� 5#   *   .R�5$   .   ��  �� Orientation$ 
Horizontal=�69   .+�5%   2   �� -   5        $��Xem thành viên��5%   9   $��0,0,5,0q�6�   
 � Tag 6R   �� *	GroupId+6�   �� 5&   2   -   5        $ ��Cập nhật trạng thái��5&   9    6W   �� *	GroupId+6o   5'   /   5(   +   5*   #   5+      5-      5.      5/      �� 52      $��Nhiệm vụ nhóm��6   .��53      �  54      �� 55      $��* �6+   �� 56      $
��Auto �6+   .+�59      �� -   5        $ TasksListView��59      $	��450��66   $	��Top=�6C   $
��Auto=�6[    5:      �� 5;      .P�5<   "   �� $��Tên nhiệm vụ��61   $	 200��6q   	 6G   �� *
TaskName+6q   �� 5=   "   $��Người giao��61   $	 150��6�   	 6E   �� *AssignedByNavigation.FullName+6�   �� 5>   "   $��Người được giao��61   $	 150��6�   	 6J   �� *AssignedToNavigation.FullName+6�   �� 5?   "   $��Hạn chót��61   $	 100��6�   	 6C   �� *	DueDate+$
 {0:dd/MM/yyyy}��6�   �� 5@   "   $��Trạng thái��61   $	 100��6m   	 6E   �� *Status+6m   �� 5A   "   $��Hành động��61   $	 200��6D    5B   &   �� 5C   *   .R�5D   .   �� $ 
Horizontal=�69   .+�5E   2   �� -   5        $ ��Cập nhật trạng thái��5E   9   $��0,0,5,0q�6�    6W   �� *TaskId+6�   �� 5F   2   -   5        $
��Xóa��5F   9   
���  ��
������� 6G   �� *TaskId+6�   5G   /   5H   +   5J   #   5K      5M      �� 5O      $��1��6!   $��10,0,0,0q�61   $	��Top=�6C   .+�5P      �� -   5         ��Name$ AddTaskButton��5P   !   $��Thêm nhiệm vụ��68   $	��120��6l   $��0,0,0,10q�6x   5Q      5R      5S      �� 5V      $
��Chat��6   .��5W      �  � RowDefinitions 5X      �� 5Y      $��* �6(   �� 5Z      $
��Auto �6(   .+�5^      �� -	   5        $ ChatListView��5^      $��0��65   $��0,0,0,10q�6B   $
��Auto=�6T   ��5_      �� 5`      .R�5a   "   �� $ 
Horizontal=�6-   .+�5b   &   �� $
��Bold"�6L   $��0,0,5,0q�6^   ��60   �� *
SenderName+6^   �� 5c   &   $��0,0,5,0q�6p   ��60   �� *SentAt+$
 {0:dd/MM/yyyy HH:mm:ss}��6p   �� 5d   &   ��60   �� *	Content+5e   #   5f      5h      �� 5k      $��1��6!   $ 
Horizontal=�6.   .+�5l      �� -
   5         ��Name$ MessageTextBox��5l   "   $	��600��6:   $��40��6F   $��0,0,10,0q�6R   $��Nhập tin nhắn...��6d   5m   E   �� 5n      -   5        $ SendMessageButton��5n   !   $��Gửi��6<   $	��100��6J   $��40��6V   6b   5o      5p      5q      5r      5s      5t      