   M S B A M L   `   `   `  ���� ?  ;Ecom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ecom.View	Ecom.View      Ecom.View.Cashing   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.10.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:Ecom.View     $	��400��.��� ���	#FFA06363  � ColumnDefinitions  �� $��80 ��� .+�� $��1�� � RowDefinitions �� $��75 ��� $��75 ��� $	��250 ��� $��50 �.+�� $��0��.+���  �� Orientation$ Vertical=����	#FF169CFF.+��� -    ��Name$ tb_payementType��
�������$��20(�$��Center=�$��Center=�����  �� Path$ SelectedItem.Tag� �� ElementName$ lb_cash���� $ 
Horizontal=�$��Center=�$��Center=�.+��� -   $ tb_total��
�������$��16(��� -   $ tb_totalRest��
�������$��16(�� $��1�����	#FF169CFF.+��� -   $ 	tb_number��
�������$��Center=�$��Right=�$��30(�$��10q�� $��2�����#2C3A47  �� $��2* ��� $
��105* ��� $
��107* ��� $
��107* � �� �� �� �� .+��� -   $��0��$��0��
������ 
������ $��30(�$��1��$��3��$��0,0,106.334,62.333q�$��2������  �� RelativeSource ��  �� AncestorType$ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth��� -   $��0��$��2��
������ 
������ $��30(�$��2��$��0.333,0,0.334,62.333q�$��2������  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth��� -   $��0��$��2��
������ 
������ $��30(�$��3��$��2��$��106.333,0,0,62.333q�$��2������  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth��� -   $��1��$��0��
������ 
������ $��30(�$��4��$��3��$��0,0.333,106.334,0.333q�����  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth��� -	   $��1��$��2��
������ 
������ $��30(�$��5��$��0.333,0.333,0.334,0.333q�����  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth��� -
   $��1��$��2��
������ 
������ $��30(�$��6��$��2��$��106.333,0.333,0,0.333q�����  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth��� -   $��1��$��0��
������ 
������ $��30(�$��7��$��3��$��0,62.333,106.334,62.333q�$��3������  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth��� -   $��1��$��2��
������ 
������ $��30(�$��8��$��0.333,62.333,0.334,62.333q�$��3������  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth��� -   $��1��$��2��
������ 
������ $��30(�$��9��$��2��$��106.333,62.333,0,62.333q�$��3������  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth��� -   $��3��$��2��
������ 
������ $��30(�$��0��$��0.333,0.333,0.334,0.333q�����  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth��� -   $��3��$��0��
������ 
������ $��20(�$��Effacer��$��3��$��0,0.333,106.334,0.333q�����  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth�� $��3��  �� �� .+��� $��0q�
������ )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 
�����������  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth���Z� .��FERMER�� -   $��
bt_caching��$��1�����	#FF169CFF
������ #��Z {�.  ����  �� $ DataGridCellL�$ ActualHeight�����  �� $ DataGridCellL�$ ActualWidth�.��	ENCAISSER� $��0�����#0984e3.+��� -   	 ��Name$	 lb_cash��
������ .@��� 

 � Tag$
 CB��.���� .+�'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=null]]   Kind$ 
CreditCard=����#2C3A47$��50��$��50���� $	
 ESP��.���� .+�  $ CurrencyEur=����#2C3A47$��50��$��50���� $
 TR��.���� $��TR��$
��Bold"�$��30(����#2C3A47$��50��$��50��