   M S B A M L   `   `   `  ����F  BBankCadwise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BankCadwise.ViewsBankCadwise.Views  5      $    BankCadwise.Views.DepositeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:BankCadwise.Views     5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5    
   �� $4��.Введите количество купюр��6   $��2��63   $��2��6C   $��1q�6P   �� 5!   
   -   5         ��Name$ count��5!      $	��5,0q�6!   $��2��6.   $��3��6>   $	��100��6K    �� TextAlignment$ Center=�5"       �� 	MaxLength$ 1000000��6)   �� 5#   
   -   5         ��Name$ Deposite��5#      $#��Внести наличные��6#   $��2��6=   $��4��6M   $��1q�6Z   �� 5%   
   $&�� Баланс банкомата:��6   $��1��6,   $��1��6<   �� 5&   
   $��2��5'      $��1��6$    �� TextAlignment$
 Left=�61   ��5&      ��  �� Path$ Balance� �� Mode$ OneWay=�5'   1   �� 5)   
   $%��Выберите номинал��6   $��1��6+   $��2��6;   $��1q�6H   �� 5*   
   -   5        	 ��Name$	 AvailableMoney��5*      $��1��5+      $��3��6"   $��4��6/   $��1q�6@   
 �� SelectedItem
 5*   *   �� *DepositeMoney+$ OneWayToSource=���5,      �� 5-      .R�5.      ��  �� Orientation$ 
Horizontal=�6!   .+�5/      �� $��Номинал��6$   $��0,5,5,0q�65   �� 50      $��0,5,5,0q�6H   ��6$   �� *Key+$ OneWay=�6H   �� 51      $%��Количество купюр��6$   $��0,5,5,0q�6>   �� 52      $��0,5,5,0q�6H   ��6$   �� *Value+$ OneWay=�6H   53      54      56      57      58      