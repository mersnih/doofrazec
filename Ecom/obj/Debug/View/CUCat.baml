   M S B A M L   `   `   `  ����?  ;Ecom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ecom.View	Ecom.View  5          Ecom.View.CUCat   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.10.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      %localclr-namespace:Ecom.View   5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��0.8* �6   6,   �� 5      $
��0.2* �6   6,   .+�5   
   �� -   5         ��Name$ 
tb_nameCat��5      $��0��6'   $��5q�64   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 Nom��6?    %  !MaterialDesignFloatingHintTextBox#��[  6d   $��2��5      ��5      ��  �� UpdateSourceTrigger$ PropertyChanged=� �� Path$ tb_name� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� -   5         ��Name$ 
bt_addItem��5      $��Bottom=�6)   $��5q�6D   
	 � Tag$	 3��6O   )  #MaterialDesignThemes.Wpf.DialogHost
   CloseDialogCommand#��Z
 6q   .��6�   	Ajouter6�   �� 5      $��Bottom=�6   $��5q�61   $	 3��6<   #��Z
 6D   .��6�   Fermer6�   5      5      5      