   M S B A M L   `   `   `  ���� ?  ;Ecom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ecom.View	Ecom.View      Ecom.View.CUCat   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.10.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   %localclr-namespace:Ecom.View   .���   � RowDefinitions  �� $
��0.8* ��� $
��0.2* �.+��� -    ��Name$ 
tb_nameCat��$��0��$��5q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 Nom�� %  !MaterialDesignFloatingHintTextBox#��[  $��2������  �� UpdateSourceTrigger$ PropertyChanged=� �� Path$ tb_name� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . �� $��1�� �� Orientation$ 
Horizontal=�$��Center=�.+��� -    ��Name$ 
bt_addItem��$��Bottom=�$��5q�
	 � Tag$	 3��)  #MaterialDesignThemes.Wpf.DialogHost
   CloseDialogCommand#��Z
 .��	Ajouter�� $��Bottom=�$��5q�$	 3��#��Z
 .��Fermer