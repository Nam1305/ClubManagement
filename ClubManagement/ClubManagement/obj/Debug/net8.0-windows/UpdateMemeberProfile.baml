   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	   )    #ClubManagement.UpdateMemeberProfile   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  UpdateMemeberProfile��5   	   $	��450��6&   $	��800��63   .��5	      �  � RowDefinitions 5
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
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Update Profile:��6-   
���  ��$��25(�6X   �� 5   
   $��1��6   $��0��6   $��User ID:��6-   �� 5   
   -   5        $��txtMemberId��5   a   $��1��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F    �� 
IsReadOnly$
 True��6t   .��6�   5       �� 5!   
   $��2��6   $��0��6   $��Student Number:��6-   �� 5"   
   -   5        $��txtStudentNumber��5"   a   $��2��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   .��6y   5$      �� 5&   
   $��3��6   $��0��6   $��Email:��6-   �� 5'   
   -   5        $��txtEmail��5'   a   $��3��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   .��6q   5)      �� 5*   
   $��4��6   $��0��6   $��
User Name:��6-   �� 5+   
   -   5        $��txtUserName��5+   a   $��4��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   .��6t   5-      �� 5.   
   $��5��6   $��0��6   $��Role:��6-   �� 5/   
   -   5        $��txtRole��5/   a   $��5��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 True��6p   .��6�   51      �� 52   
   $��6��6   $��0��6   $��
Full Name:��6-   �� 53   
   -   5        $��txtFullName��53   a   $��6��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   6w   �� 54   
   $��7��6   $��0��6   $��Status:��6-   �� 55   
   -   5        $��	txtStatus��55   a   $��7��6   $��1��6   $��3q�6/   $	��300��6:   $
��Left=�6F   $
 true��6r   .��6�   57      �� 59   
   -   5         ��Name$ 	btnUpdate��59      $��8��6$   $��1��61   $	��100��6A   $��20��6M   $��3q�6Y   $
��Left=�6d   $��Update Profile��6   6�   5=      5>      