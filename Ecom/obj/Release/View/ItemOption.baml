   M S B A M L   `   `   `  ���� ?  ;Ecom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ecom.View	Ecom.View  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     Ecom.View.ItemOption   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.10.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   %localclr-namespace:Ecom.View   0s&clr-namespace:System;assembly=mscorlib   $��Stretch=�$��Stretch=�$��Stretch=�$��Stretch=�$
��auto��$
��auto��$	��650��$	��800��  � 	Resources   �� 
TargetType   listBoxStyle �� Property �� Value �� BasedOn  ContainerStyle �� Triggers P� Property P� Value��%I  &	        '�� #     7   &	 2     �� " ��.���  � ��$ 25(��� " ��8   �� " ��.���  �@J�Opacity$	 0.5Q���  �@J�Opacity$	 0.5Q���  � ��$ 75����  � ��$	 100�� P�  �@��
IsSelected . . ���  �@J�Opacity$	 1.0Q���  � �� �#eb2f06��  � �� �#eb2f06.��� 
�������$	��700�� � RowDefinitions �� $��50 ��� $	��350 ��� $��70 �.+��� $��0��	 �� Orientation$	 Vertical=�$��Stretch=�$��Stretch=����#a5b1c2.+��� -   
 ��Name$
 tb_optionTitle��$��0��$��Center=�$��Stretch=�$��24(�
�������$�� ���� $
��Auto=�$��1��.���� -    ��Name$ icItem�� �� MaxValue �� AlternationCount# Z ���� *listIngredient+���� .R�� ���� .R�� $
��5,10q�$��0�� �� $
��0.6* ��� $
��0.4* �.+��� $	 
Horizontal=�$��0��.+�%  MaterialDesignThemes.Wpf.Badged     BadgeColorZoneMode$ Accent=�  ControlzEx.BadgedEx   BadgeForeground
 �   �   BadgePlacementMode$ TopRight=�   Badge ��  �� Path$ Ingredient_quantity�.����  ��Name$ bt_addIngredient��-   ���#576574���#576574$��Center=�$	��Top=�$	��120��$	��120��
 � Tag ��  �� RelativeSource ��  �� Mode$ TemplatedParent=�$% (ItemsControl.AlternationIndex)�.���� .+��� $��35(�$��+��$��Center=��� $��Center=�$��14(����� $ Ingredient_title��� $��Center=�$��12(����� $ Ingredient_price�€�� -   $��Stretch=����#ff7675���#ff7675
�������$��-��$��40��$��30(�$��1�� �� �� -   $
 tb_value���� -   $ bt_BackOption��$��2��$
��Left=� �� 	IsDefault .   MaterialDesignFlatButton#���  $y�Visible=�$
��Auto��.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=null]]   Kind$ ArrowLeftBoldCircle=�$��50��$��50�����#2980b9�� $��2��$	 
Horizontal=�$��Center=�.+���  . #���  $��5q����#e74c3c
�������)  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z .��	Annuler�� -    . #���  $��Right=�$��5q����#27ae60
�������#��Z .��	Ajouter�� -   $ bt_NextOption��$��2�� . #���  $��Right=�$
��Auto��.��  $ ArrowRightBoldCircle=�$��50��$��50�����#2980b9