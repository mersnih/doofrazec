   M S B A M L   `   `   `  ����?  ;Ecom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ecom.View	Ecom.View  5          Ecom.View.CUMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.10.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      %localclr-namespace:Ecom.View   5      $	��600��5
      .��5      � .+�5   
   � -   5          �Name$  gridMenuCrud��5      
������� J� Opacity$
 0.75Q�68   $��
10,0,10,20q�6G    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5      -   5           Command$	 New��5   !   6H    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%   .+�5      � $��0��6    � RowDefinitions 5      �� 5      $��0.15* �6$   65   �� 5      6&   �� 5      $
��0.2* �6$   64   .+�5"      �� -   5         ��Name$ 	sp_header��5"      $��0��60    �� Orientation$ 
Horizontal=�6>   $��40��6W   $��Center=�6c   .+�5#      �� -   5         ��Name$ tb_messageMenu��5#       $��18(�68   $y�	Collapsed=�6F   $��5q�6]   '  !MaterialDesignThemes.Wpf.PackIcon  5$      -   5        	  Name$	 icon_messageMenu��5$   .   $y�	Collapsed=�6H   $��5q�6_   5%      � 5&      $��1��6   
 � ShowGridLines
 .  .+�5'      � -   5        $  	gridForms��5'      $��0��6.    5(      �� 5)      6.   �� 5*      6.   �� 5+      6.   �� 5,      6.   �� 5-      $	��100 �6,   6;   .+�51      �� -   5         ��Name$ tb_MenuName��51   "   $��0��68   $
��5,10q�6E   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 Nom��6S    %  !MaterialDesignFloatingHintTextBox#��[  6x   $��2��52   :   ��53      ��  �� UpdateSourceTrigger$ PropertyChanged=� �� Path$ tb_name� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . �� 55      $��1��6&   $ 
Horizontal=�63   $
��Left=�6L   .+�56      �� -   5        $ tb_MenuPrice��56   &   $	��150��6<   $
��5,10q�6I   $
 Prix��6w   #��[  6�   $��2��57   :   ��58      �� $ PropertyChanged=�$ tb_price� .  . �� 59      -	   5        $ tb_MenuPricePromo��59   &   $	��150��6b   $
��5,10q�6n   $ 
Prix promo��6}   #��[  6�   $��2��5:   :   ��5;      �� $ PropertyChanged=�$ Title� .  . 5<      �� 5?      -
   5        $ tb_MenuDescription��5?   "   $��2��6?   $
��5,10q�6L   $ Description��6Z   #��[  6�   $��2��5@   :   ��5A      �� $ PropertyChanged=�$ Title� .  . �� 5D      $��3��6%   $ 
Horizontal=�62   $
��Left=�6K   .+�5E      �� $��Actif��6(   $��10,10q�65   d� 5F      -   5         d�Name$ tg_MenuActif��5F   +    d� 	IsChecked$
 TrueY�6B   $��5q�6S   6`   5G      �� 5H      $��4��6%   $ 
Horizontal=�62   .+�5I      �� -   5        $��Image��5I   %   $��10,20q�65   $	��100��6D   $
��Left=�6m   �� 5J      -   5        $��imgMenuPhoto��5J   $   $
��10,0q�69   $��UniformToFill=�6G   $��Right=�6`   5K      5L      5P      �� 5R      $��2��6   $ 
Horizontal=�6*   $��Center=�6C   .+�5S      �� -   5         ��Name$ 
bt_addItem��5S      $��Bottom=�61   $��5q�6L   
 � Tag$ 3��6W   $	��New��6y   .��6�   	Ajouter6�   �� 5T      $��Bottom=�6   $��5q�69   $ 3��6D   )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 6L   .��6�   Fermer6�   5U      5V      � 5Y      $��1��6    5Z      �� 5[      $
��0.1* �6$   64   �� 5\      6&   .+�5^      �� $��0��6   $��Center=�6%   $��Center=�6B   .��6]   Choix de produit6o   �� 5_      -   5         ��Name$ lv_items��5_      $��1��6-    �� SelectionMode$ Single=�6:    �� View 5`      �� 5a      .P�5b      ��  �� CellTemplate 5c   "   �� 5d   &   .R�5e   *   �� ��64   �� *
item_title+5g   '   5i      5j      5l      5m      � 5p      $��2��6    5q      �� 5r      $
��0.1* �6$   64   �� 5s      6&   .+�5u      �� $��0��6   $��Center=�6%   $��Center=�6B   .��6]   Choix des options6q   �� 5v      -   5        $ 
lv_options��5v      $��1��6/   $ Multiple=�6<    5w      �� 5x      .P�5y      ��  5z   "   �� 5{   &   .R�5|   *   �� ��64   �� *option_choix_menu_title+5~   '   5�      5�      5�      5�      5�      5�      5�      