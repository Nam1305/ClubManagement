   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   %    ClubManagement.ViceChairmanhome   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  Vice Chairman Home��5   	   $	��600��6$   $	��900��61    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $ Styles.xaml?�6%   %    5      .��5      � $��10q�6   .+�5   
   �� -   5         ��Name$ 
TabControl��5      .@�5      �� $��Groups��6   .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��0,0,0,10q�6:   .+�5      �� -   5         ��Name$ CreateGroupButton��5   !   $��Create Group��6<   $	��120��6s   $��0,0,10,0q�6   5      �� 5      -   5         ��Name$ GroupsListView��5      $��1��67   $	��450��6D   $	��Top=�6Q   $
��Auto=�6i   	 �� View	 5      �� 5      .P�5    "   �� $��
Group Name��61   
 �� Width$	
 150��6p    �� DisplayMemberBinding 6E   �� *	GroupName+6p   �� 5!   "   $��Event��61   $	
 150��6q    6@   �� *Event.EventName+6q   �� 5"   "   $��Leader��61   $	
 150��6r    6A   �� *Leader.FullName+6r   �� 5#   "   $��
Created At��61   $	
 100��6�    6E   �� *	CreatedAt+ �� StringFormat$ {0:dd/MM/yyyy}��6�   �� 5$   "   $��Status��61   $	
 100��6i    6A   �� *Status+6i   �� 5%   "   $��Actions��61   $	
 200��6B    �� CellTemplate 5&   &   �� 5'   *   .R�5(   .   �� $ 
Horizontal=�69   .+�5)   2   �� -   5        $��View Members��5)   9   $��0,0,5,0q�6�   
 � Tag 6P   �� *	GroupId+6�   �� 5*   2   -   5        $��Assign Leader��5*   9   $��0,0,5,0q�6�    6Q   �� *	GroupId+6�   �� 5+   2   -   5        $��Update Status��5+   9    6Q   �� *	GroupId+6i   5,   /   5-   +   5/   #   50      52      53      54      �� 57      $��Members��6   .��58      �  59      �� 5:      $
��Auto �6(   �� 5;      $��* �6(   .+�5=      �� $ 
Horizontal=�6!   $��0,0,0,10q�6:   .+�5>      �� -   5         ��Name$ TermComboBox��5>   #   $	��150��69   $��0,0,10,0q�6v   �� 5?      -   5         ��Name$ SearchTextBox��5?   "   $	��200��69   $&�� Search by name or student number��6E   $��0,0,10,0q�6�   �� 5@      -	   5        $ ExportToExcelButton��5@   !   $��Export to Excel��6>   $	��120��6z   5A      �� 5B      -
   5        $ MembersListView��5B      $��1��68   $	��450��6E   $	��Top=�6R   $
��Auto=�6j   	 5C      �� 5D      .P�5E   "   �� $��	Full Name��61   $	
 150��6n    6D   �� *
FullName+6n   �� 5F   "   $��Student Number��61   $	
 120��6x    6I   �� *StudentNumber+6x   �� 5G   "   $��Email��61   $	
 200��6g    6@   �� *Email+6g   �� 5H   "   $��Participation (%)��61   $	
 120��6�    6L   �� *ParticipationPercentage+$ {0:F2}%��6�   �� 5I   "   $��Activity Level��61   $	
 120��6x    6I   �� *ActivityLevel+6x   5J      5L      5M      5N      �� 5Q      $��Events��6   .��5R      �  5S      �� 5T      $
��Auto �6(   �� 5U      $��* �6(   .+�5W      �� $ 
Horizontal=�6!   $��0,0,0,10q�6:   .+�5X      �� -   5        $ CreateEventButton��5X   !   $��Create Event��6<   $	��120��6s   $��0,0,10,0q�6   5Y      �� 5Z      -   5        $ EventsListView��5Z      $��1��67   $	��450��6D   $	��Top=�6Q   $
��Auto=�6i   	 5[      �� 5\      .P�5]   "   �� $��
Event Name��61   $	
 150��6p    6E   �� *	EventName+6p   �� 5^   "   $
��Date��61   $	
 100��6�    6?   �� *	EventDate+$ {0:dd/MM/yyyy}��6�   �� 5_   "   $��Location��61   $	
 150��6m    6C   �� *
Location+6m   �� 5`   "   $��Status��61   $	
 100��6i    6A   �� *Status+6i   �� 5a   "   $��Actions��61   $	
 250��6B    5b   &   �� 5c   *   .R�5d   .   �� $ 
Horizontal=�69   .+�5e   2   �� -   5        $
��Edit��5e   9   $��0,0,5,0q�6x    6H   �� *	EventId+6x   �� 5f   2   -   5        $��Delete��5f   9   $��0,0,5,0q�6|    6J   �� *	EventId+6|   �� 5g   2   -   5        $��View Participants��5g   9   $��0,0,5,0q�6�    6U   �� *	EventId+6�   �� 5h   2   -   5        $��Update Status��5h   9    6Q   �� *	EventId+6i   5i   /   5j   +   5l   #   5m      5o      5p      5q      �� 5t      $��Reports��6   .��5u      �  5v      �� 5w      $
��Auto �6(   �� 5x      $��* �6(   .+�5z      �� $ 
Horizontal=�6!   $��0,0,0,10q�6:   .+�5{      �� -   5        $ ReportSemesterComboBox��5{   #   $	��150��6C   $��0,0,10,0q�6�   �� 5|      -   5        $ GenerateReportButton��5|   !   $��Generate Report��6?   $	��120��6|   $��0,0,10,0q�6�   �� 5}      -   5        $ ExportReportToExcelButton��5}   !   $��Export to Excel��6D   $	��120��6�   5~      �� 5      -   5        $ ReportsListView��5      $��1��68   $	��450��6E   $	��Top=�6R   $
��Auto=�6j   	 5�      �� 5�      .P�5�   "   �� $��Created Date��61   $	
 120��6�    6G   �� *CreatedDate+$ {0:dd/MM/yyyy}��6�   �� 5�   "   $��Semester��61   $	
 120��6m    6C   �� *
Semester+6m   �� 5�   "   $��Member Changes��61   $	
 200��6x    6I   �� *MemberChanges+6x   �� 5�   "   $��Event Summary��61   $	
 200��6v    6H   �� *EventSummary+6v   �� 5�   "   $��Participation Status��61   $	
 150��6�    6O   �� *ParticipationStatus+6�   5�      5�      5�      5�      �� 5�      $��Tasks��6   .��5�      �  5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   .+�5�      �� $ 
Horizontal=�6!   $��0,0,0,10q�6:   .+�5�      �� -   5        $ CreateTaskButton��5�   !   $��Create Task��6;   $	��120��6p   $��0,0,10,0q�6|   5�      �� 5�      -   5        $ TasksListView��5�      $��1��66   $	��450��6C   $	��Top=�6P   $
��Auto=�6h   	 5�      �� 5�      .P�5�   "   �� $��	Task Name��61   $	
 150��6n    6D   �� *
TaskName+6n   �� 5�   "   $��Group��61   $	
 150��6q    6@   �� *Group.GroupName+6q   �� 5�   "   $��Assigned To��61   $	
 150��6�    6F   �� *AssignedToNavigation.FullName+6�   �� 5�   "   $��Assigned By��61   $	
 150��6�    6F   �� *AssignedByNavigation.FullName+6�   �� 5�   "   $��Due Date��61   $	
 120��6�    6C   �� *	DueDate+$ {0:dd/MM/yyyy}��6�   �� 5�   "   $��Status��61   $	
 100��6i    6A   �� *Status+6i   �� 5�   "   $��Actions��61   $	
 150��6B    5�   &   �� 5�   *   .R�5�   .   �� $ 
Horizontal=�69   .+�5�   2   �� -   5        $
��Edit��5�   9   $��0,0,5,0q�6v    6H   �� *TaskId+6v   �� 5�   2   -   5        $��Delete��5�   9    6J   �� *TaskId+6a   5�   /   5�   +   5�   #   5�      5�      5�      5�      �� 5�      $
��Chat��6   .��5�      �  5�      �� 5�      $��* �6(   �� 5�      $
��Auto �6(   .+�5�      �� -   5        $ ChatListView��5�      $��0��65   $��0,0,0,10q�6B   $
��Auto=�6T   ��5�      �� 5�      .R�5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� $
��Bold"�6L   $��0,0,5,0q�6^   ��60   �� *
SenderName+6^   �� 5�   &   $��0,0,5,0q�6p   ��60   �� *SentAt+$ {0:dd/MM/yyyy HH:mm:ss}��6p   �� 5�   &   ��60   �� *	Content+5�   #   5�      5�      �� 5�      $��1��6!   $ 
Horizontal=�6.   .+�5�      �� -   5        $ MessageTextBox��5�   "   $	��600��6:   $��40��6F   $��0,0,10,0q�6R   $��Nhập tin nhắn...��6d   5�   E   �� 5�      -   5        $ SendMessageButton��5�   !   $��Gửi��6<   $	��100��6J   $��40��6V   6b   5�      5�      5�      5�      5�      5�      