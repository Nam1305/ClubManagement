   M S B A M L   `   `   `  ����I  EClubManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClubManagementClubManagement  5   	        ClubManagement.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClubManagement     5   	     � Title$  LoginWindow��5   	   $	��450��5	   	   $	��800��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#F5F5F5.��5      � .+�5   
   �� 
�������$	��400��5      $	��360��5       �� CornerRadius$ 15��5      $��Center=�5      $��Center=�5       �� Padding$ 20q�5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6#      
BlurRadius$ 10Q�61      ShadowDepth$ 5Q�6A   ._�5      �� .+�5      �� $��Login��6   $��24(�5      $
��Bold"�5      $��Center=�5      $��0,0,0,20q�5      �� 5      $��Username��6   $
��Bold"�6+   �� 5       -   5         ��Name$ txtUsername��5       $��34��5!      $��5q�5"      ���#888$��1q�5$      �� 5&      $��Password��6   $
��Bold"�5'      $��0,10,0,0q�5(      G� 5)      -   5        	 G�Name$	 pwdPassword��5)      $��34��5*      $��5q�5+      ���#888$��1q�5-      �� 5/      -   5        
 ��Name$
 btnLogin��5/      $��Login��50      ���#0078D7
�������$��16(�53      $
��Bold"�54      $��40��55      $��0,20,0,0q�56      $��0q�57       � Cursor$
 Hand��58      59      �� 5;      -   5        $
 btnForgotPassword��5;      $��Forgot Password?��5<      $��0,10,0,0q�5=      
������ $��0q�5?      ���#0078D7$
 Hand��5A      $��Center=�5B      5C      �� 5E      $��Center=�6   $��0,15,0,0q�5F      $��14(�5G       Bạn chưa có tài khoản? �� 5I      -   5        $��RegisterWindow.xaml?�5I       ���#0078D7 �� TextDecorations$ 	Underline{�5L      .�6;   Đăng ký ngay5N      5O      5P      5Q      5R      5S      