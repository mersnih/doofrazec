   M S B A M L   `   `   `  ����?  ;Ecom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ecom.View	Ecom.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          Ecom.View.ItemOption   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.10.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      %localclr-namespace:Ecom.View   5      0s&clr-namespace:System;assembly=mscorlib   5      $��Stretch=�5
      $��Stretch=�5   
   $��Stretch=�5   
   $��Stretch=�5   
   $
��auto��5      $
��auto��5      $	��650��5      $	��800��6     � 	Resources  5       �� 
TargetType   listBoxStyle �� Property �� Value �� BasedOn  ContainerStyle �� Triggers P� Property P� Value��%  &	        '�� H     7   &	 j     �� 5   
   " ��6   .�5      ��  � ��$ 25(�6)   5      �� 5   
   " ��6   8   6X   �� 5   
   " ��6   .�5      ��  �@J�Opacity$	 0.5Q�6(   �� 5       �@J�Opacity$	 0.5Q�6(   �� 5       � ��$ 75��6*   �� 5       � ��$	 100��6'    5       P� 5!       �@��
IsSelected . . �5"      ��  �@J�Opacity$	 1.0Q�60   �� 5#       � �� �#eb2f0663   �� 5$       � �� �#eb2f0664   5%      5'      5(      .��5+      � 
�������$	��700��6    � RowDefinitions 5,   
   �� 5-      $��50 �6   6*   �� 5.      $	��350 �6   6+   �� 5/      $��70 �6   6*   .+�5D   
   �� $��0��6   	 �� Orientation$	 Vertical=�6"   $��Stretch=�69   $��Stretch=�6X   ���#a5b1c2.+�5E      �� -   5        
 ��Name$
 tb_optionTitle��5E      $��0��61   $��Center=�6>   $��Stretch=�6[   $��24(�6w   
�������$�� ��5F   !   5G      �� 5I   
   $
��Auto=�6   $��1��6:   .��5K      �� -   5         ��Name$ icItem��5K       �� MaxValue �� AlternationCount# Z 6R   ��6+   �� *listIngredient+��5L      �� 5M      .R�5N      � 5Q      ��5S      �� 5T      .R�5W      � $
��5,10q�6#   $��0��61    5X      �� 5Y   "   $
��0.6* �60   6@   �� 5Z   "   $
��0.4* �60   6@   .+�5\      �� $	 
Horizontal=�6)   $��0��6B   .+�5_   "   %  MaterialDesignThemes.Wpf.Badged     BadgeColorZoneMode$ Accent=�5`   4     ControlzEx.BadgedEx   BadgeForeground
 �   �   BadgePlacementMode$ TopRight=�5b   4      Badge 5_   8   ��  �� Path$ Ingredient_quantity�.��5d   &   ��  ��Name$ bt_addIngredient��5e   %   -   5        ���#576574���#576574$��Center=�5g   %   $	��Top=�6B   $	��120��5l   %   $	��120��61   
 � Tag 5j   %   ��  �� RelativeSource ��  �� Mode$ TemplatedParent=�$% (ItemsControl.AlternationIndex)�.��5m   *   �� .+�5o   .   �� $��35(�68   $��+��6F   $��Center=�6O   �� 5p   .   $��Center=�68   $��14(�6U   ��6c   �� $ Ingredient_title�6�   �� 5q   .   $��Center=�68   $��12(�6U   ��6c   �� $ Ingredient_price�€6�   5s   +   5t   '   5v   #   5~      �� 5      -   5        $��Stretch=�5�   %   ���#ff7675���#ff7675
�������$��-��5�   %   $��40��5�   %   $��30(�5�   %   $��1��5�   %    5�   %   �� 5�   %   5�      5�      5�      5�      �� 5�      -   5        $
 tb_value��5�      �� 5�      -   5        $ bt_BackOption��5�      $��2��5�      $
��Left=�6*    �� 	IsDefault .   MaterialDesignFlatButton#���  5�   .   $y�Visible=�5�      $
��Auto��5�   *   .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=null]]   Kind$ ArrowLeftBoldCircle=�66   $��50��6Q   $��50��6]   ���#2980b96h   5�      �� 5�      $��2��6%   $	 
Horizontal=�62   $��Center=�6K   .+�5�      ��  . #���  5�   "   $��5q�5�      ���#e74c3c
�������)  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 5�      .��6T   	Annuler5     �� 5     -   5         . #���  5  "   $��Right=�5     $��5q�5     ���#27ae60
�������#��Z 5     .��6T   	Ajouter5
     5     �� 5     -   5        $ bt_NextOption��5     $��2��5      . #���  5  .   $��Right=�5     $
��Auto��5  +   .��5       $ ArrowRightBoldCircle=�66   $��50��6R   $��50��6]   ���#2980b96i   5     5     5     