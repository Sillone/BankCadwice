   M S B A M L   `   `   `  ����F  BBankCadwise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BankCadwise.ViewsBankCadwise.Views  5           BankCadwise.Views.MenuView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:BankCadwise.Views     5      $��15(�5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��5 �6   .+�5   
   �� -   5         ��Name$ Deposite��5   ,   $%��Пополнить баланс��6   $��1��5       $��2��6!   $��5q�5!      �� 5"   
   -   5        $ GetCash��5"   *   $!��Снять наличные��6   $��1��5#      $��3��6!   $��5q�5$      �� 5%   
   -   5        $ LogOut��5%   ,   $%��Завершить работу��6   $��1��5&      $��4��6!   $��5q�5'      �� 5)   
   -   5         ��Name$ 
ActiveItem��5)      $��3��6-   $��5��6=   $��1��6Q   $��5��6^   �� 5+   	   -   5         ��Name$ MyPerson_Name��5+      $��4��5,      $��1��6$   $
��10,0q�61   �� 5-   
   $��Баланс:��6   $��1��6"   $��5��6/   �� 5.   
   -   5        $ MyPerson_Balance��5.      $��6��5/      $��1��6$   50      51      