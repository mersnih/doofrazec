   M S B A M L   `   `   `  ����?  ;Ecom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ecom.View	Ecom.View  5          Ecom.View.CUItem   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.10.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      %localclr-namespace:Ecom.View   5      $	��700��5	      .��5      � -   5          �Name$  gridCrud��5      
������� J� Opacity$
 0.75Q�60   $��
10,0,10,20q�6?    J� CommandBindings 5   
   )  #System.Windows.Input.CommandBinding  5      -   5           Command$	 New��5      6D    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� -   5         ��Name$ 	sp_header��5      $��0��6(    �� Orientation$ 
Horizontal=�66   $��40��6O   $��Center=�6[   .+�5      �� -   5         ��Name$ tb_messageItem��5      $��18(�60   $y�	Collapsed=�6>   $��5q�6U   '  !MaterialDesignThemes.Wpf.PackIcon  5      -   5          Name$ icon_messageItem��5   &   $y�	Collapsed=�6@   $��5q�6W   5      � 5   
   $��1��6   	 � ShowGridLines	 .  
 � ColumnDefinitions
 5      �� 5      6%   �� 5      6%   .+�5      � -   5        $  	gridForms��5      $��0��6&    5       �� 5!      6&   �� 5"      6&   �� 5#      6&   �� 5$      6&   �� 5%      $	��100 �6$   63   �� 5&      6&   �� 5'      6&   .+�5)      �� -   5         ��Name$ tb_name��5)      $��0��6,   $
��5,10q�69   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 Nom��6G    %  !MaterialDesignFloatingHintTextBox#��[  6l   $��2��5*   :   ��5+      ��  �� UpdateSourceTrigger$ PropertyChanged=� �� Path$ tb_name� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . �� 5,      -   5        $ tb_description��5,      $��2��63   $
��5,10q�6@   $ Description��6N   #��[  6{   $��2��5-   :   ��5.      �� $ PropertyChanged=�$ Title� .  . �� 50      $��1��6   $ 
Horizontal=�6+   $
��Left=�6D   .+�51      �� -	   5        $ tb_price��51      $	��150��60   $
��5,10q�6=   $
 Prix��6k   #��[  6�   $��2��52   :   ��53      �� $ PropertyChanged=�$ tb_price� .  . �� 54      -
   5        $ tb_pricePromo��54      $	��150��6V   $
��5,10q�6b   $ 
Prix promo��6q   #��[  6�   $��2��55   :   ��56      �� $ PropertyChanged=�$ Title� .  . 57      �� 58      $��3��6   $ 
Horizontal=�6*   $
��Left=�6C   .+�59      �� $��Actif��6    $��10,10q�6-   d� 5:      -   5         d�Name$ tg_actif��5:   #    d� 	IsChecked$
 TrueY�66   $��5q�6G   6T   �� 5;      $��	Préparé��6    $��10,10q�6/   d� 5<      -   5        $ 	tg_cooked��5<   #   $
 TrueY�67   $��5q�6H   6U   5=      �� 5>      $��4��6   $ 
Horizontal=�6*   .+�5?      �� -   5        $��Image��5?      $��10,20q�6-   $	��100��6<   $
��Left=�6a   �� 5@      -   5        $��imgPhoto��5@      $
��10,0q�6-   $��UniformToFill=�6;   $��Right=�6T   5A      5B      � 5F      $��1��6    5G      �� 5H      $
��0.1* �6$   64   �� 5I      $
��0.9* �6$   64   .+�5K      �� $��0��6   $��Choix couleur��6)   $��Center=�6>   $��Center=�5L      $��5q�67   �� 5M      $��1��6    $
��Auto=�6-   .��5O      �� -   5         ��Name$ icColorsPalette��5O   #   ��6<   �� *	colorList+��5P      �� 5Q      .R�5R   "   � 5T      ��5V      �� 5W      .R�5Y   "   � $
��5,10q�6'    5Z   &   �� 5[   *   $
��0.7* �68   6H   �� 5\   *   $
��0.3* �68   6H   .+�5b   *   d� $��bt_color��67   -   5        $��0��5b   G    ) %MaterialDesignActionLightToggleButton#��[ 5c   8   $ FalseY�6w    � ToolTip$+ %MaterialDesignActionLightToggleButton��5d      $��70��5e   L   $��70��6W   ��5b   T   �� $
 Code���6u   �� $
 Code�
 � Tag 5d   G   ��  �� RelativeSource ��  �� Mode$ TemplatedParent=�$% (ItemsControl.AlternationIndex)�5e   W   5m   #   5p      5r      5s      5u      5w      �� 5x      $��2��6   $ 
Horizontal=�6#   $��Center=�6<   .+�5y      �� -   5         ��Name$ 
bt_addItem��5y      $��Bottom=�6)   $��5q�6D   $ 3��6O   $	��New��6q   .��6�   	Ajouter6�   �� 5z      $��Bottom=�6   $��5q�61   $ 3��6<   )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 6D   .��6�   Fermer6�   5{      5|      5}      