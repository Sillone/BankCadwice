   M S B A M L   `   `   `  ����F  BBankCadwise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BankCadwise.ViewsBankCadwise.Views  5      +    %BankCadwise.Views.GetCertainValueView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:BankCadwise.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $&�� Баланс банкомата:��6   $��1��6,   $��1��6<   �� 5   
   $��2��5      $��1��6$    �� TextAlignment$
 Left=�61   ��5      ��  �� Path$ Balance� �� Mode$ OneWay=�5   1   �� 5   
   $*��$Максимальная сумма:��6   $��1��6.   $��2��6>   �� 5    
   -   5         ��Name$ 	MaxAmount��5       $��2��5!      $��2��6$   $
 Left=�61   �� 5#   
   $��Введите сумму��6   $��2��6(   $��3��68   $��1q�6E   �� 5$   
   -   5         ��Name$ amount��5$      $	��5,0q�6"   $��2��6/   $��4��6?   $	��100��6L    �� TextAlignment$ Center=�5%       �� 	MaxLength$ 1000000��6)   �� 5&   
   -   5        	 ��Name$	 GetCertainValue��5&      $!��Снять наличные��6*   $��2��6C   $��5��6S   $��1q�6`   �� 5*   
   $%��Выберите номинал��6   $��1��6+   $��3��6;   $��1q�6H   �� 5+   
   -   5        
 ��Name$
 AvailableMoney��5+       �� DisplayMemberPath$	 Key��5,      $��1��5-      $��4��6"   $��1q�60    �� SelectedIndex 5+   +   �� *value+5/      52      53      