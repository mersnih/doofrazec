   M S B A M L   `   `   `  ���� ?  ;Ecom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ecom.View	Ecom.View      Ecom.View.CUItem   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.10.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   %localclr-namespace:Ecom.View   $	��700��.��� -     �Name$  gridCrud��
������� J� Opacity$
 0.75Q�$��
10,0,10,20q� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$	 New�� � RowDefinitions �� �� �� .+��� -    ��Name$ 	sp_header��$��0�� �� Orientation$ 
Horizontal=�$��40��$��Center=�.+��� -    ��Name$ tb_messageItem��$��18(�$y�	Collapsed=�$��5q�'  !MaterialDesignThemes.Wpf.PackIcon  -     Name$ icon_messageItem��$y�	Collapsed=�$��5q�� $��1��	 � ShowGridLines	 .  
 � ColumnDefinitions
 �� �� .+�� -   $  	gridForms��$��0�� �� �� �� �� �� $	��100 ��� �� .+��� -    ��Name$ tb_name��$��0��$
��5,10q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 Nom�� %  !MaterialDesignFloatingHintTextBox#��[  $��2������  �� UpdateSourceTrigger$ PropertyChanged=� �� Path$ tb_name� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . �� -   $ tb_description��$��2��$
��5,10q�$ Description��#��[  $��2������ $ PropertyChanged=�$ Title� .  . �� $��1��$ 
Horizontal=�$
��Left=�.+��� -	   $ tb_price��$	��150��$
��5,10q�$
 Prix��#��[  $��2������ $ PropertyChanged=�$ tb_price� .  . �� -
   $ tb_pricePromo��$	��150��$
��5,10q�$ 
Prix promo��#��[  $��2������ $ PropertyChanged=�$ Title� .  . �� $��3��$ 
Horizontal=�$
��Left=�.+��� $��Actif��$��10,10q�d� -    d�Name$ tg_actif�� d� 	IsChecked$
 TrueY�$��5q��� $��	Préparé��$��10,10q�d� -   $ 	tg_cooked��$
 TrueY�$��5q��� $��4��$ 
Horizontal=�.+��� -   $��Image��$��10,20q�$	��100��$
��Left=��� -   $��imgPhoto��$
��10,0q�$��UniformToFill=�$��Right=�� $��1�� �� $
��0.1* ��� $
��0.9* �.+��� $��0��$��Choix couleur��$��Center=�$��Center=�$��5q��� $��1��$
��Auto=�.���� -    ��Name$ icColorsPalette������ *	colorList+���� .R�� ���� .R�� $
��5,10q� �� $
��0.7* ��� $
��0.3* �.+�d� $��bt_color��-   $��0�� ) %MaterialDesignActionLightToggleButton#��[ $ FalseY� � ToolTip$+ %MaterialDesignActionLightToggleButton��$��70��$��70������ $
 Code����� $
 Code�
 � Tag ��  �� RelativeSource ��  �� Mode$ TemplatedParent=�$% (ItemsControl.AlternationIndex)��� $��2��$ 
Horizontal=�$��Center=�.+��� -    ��Name$ 
bt_addItem��$��Bottom=�$��5q�$ 3��$	��New��.��	Ajouter�� $��Bottom=�$��5q�$ 3��)  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z .��Fermer