   M S B A M L   `   `   `  ����F  BBankCadwise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BankCadwise.ViewsBankCadwise.Views  5      #    BankCadwise.Views.GetCashView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:BankCadwise.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Введите сумму��6   $��1��6(   $��2��68   $��1q�6E   �� 5   
   -   5         ��Name$ amount��5      $	��5,0q�6K   $��1��6X   $��3��6h   $	��100��6u    �� TextAlignment$ Center=�5      ��5   "   ��  �� Path$ Amount� �� Mode$ OneWay=�5      �� 5   
   -   5         ��Name$ exchange��5      $2��,Выдать мелкими купюрами��6%   $��1��6G   $��4��6W   $��1q�6d   �� 5    
   -   5         ��Name$ GetCash��5       $!��Снять наличные��6"   $��1��6;   $��5��6K   $��1q�6X   �� 5"   
   $&�� Баланс банкомата:��6   $��1��6,   $��1��6<   �� 5#   
   -   5         ��Name$ MyBank_Balance��5#      $��2��5$      $��1��6$   	 �� TextAlignment$
	 Left=�61   �� 5&   
   $#��Выданные купюры��6   $��3��6*   $��2��6:   $��10,1,1,1q�6G   �� 5'   
   -   5        
 ��Name$
 ReturnedMoney��5'      $��3��5(      $��3��6"   $��3��6/   $��10,1,1,1q�6@   ��5)      �� 5*      .R�5+      ��  �� Orientation$ 
Horizontal=�6!   .+�5,      �� $��Номинал��6$   $��0,5,5,0q�65   �� 5-      $��0,5,5,0q�6H   ��6$   �� *Key+$ OneWay=�6H   �� 5.      $%��Количество купюр��6$   $��0,5,5,0q�6>   �� 5/      $��0,5,5,0q�6H   ��6$   �� *Value+$ OneWay=�6H   50      51      53      54      55      