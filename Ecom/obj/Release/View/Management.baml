   M S B A M L   `   `   `  ���� ?  ;Ecom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ecom.View	Ecom.View  E ADragablz, Version=0.0.3.203, Culture=neutral, PublicKeyToken=null5(clr-namespace:Dragablz;assembly=DragablzDragablz     Ecom.View.Management   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.10.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   %localclr-namespace:Ecom.View   9dragablz(clr-namespace:Dragablz;assembly=Dragablz     � 	Resources   �� MergedDictionaries �� Source   Key  
Primary100 �� Color  Primary100Foreground  
Primary500  Primary500Foreground  
Primary700  Primary700Foreground  	Accent200  Accent200Foreground  Dragablz.TabablzControl �� 
TargetType %	 !MaterialDesignTabablzControlStyle �� BasedOn��  ��  �� $b \pack://application:,,,/MaterialDesignColors;component/Themes/MaterialDesignColor.Indigo.xaml?��� PrimaryHueLightBrush  # [ �� "PrimaryHueLightForegroundBrush  # [ �� PrimaryHueMidBrush  # [ ��  PrimaryHueMidForegroundBrush  # [ �� PrimaryHueDarkBrush  # [ �� !PrimaryHueDarkForegroundBrush  # [ ��  �� $b \pack://application:,,,/MaterialDesignColors;component/Themes/MaterialDesignColor.Yellow.xaml?��� SecondaryAccentBrush  # [ �� "SecondaryAccentForegroundBrush  # [ �� $J Dpack://application:,,,/Dragablz;component/Themes/materialdesign.xaml?�%   '        7 	 �� "  8   .��  .@��� $��Gestion des produits��.���  � RowDefinitions �� �� .+�� $��0��$	��0,5q� � ColumnDefinitions �� �� �� .+�� $��0��$��0��.+�]� 
�������$	��5,0q�.+��� $	��Top=����#2e86de$��50��.+��� $��Center=�
�������$��20(�Familles des articles� $��1��.+��� -    ��Name$ lv_itemsCategory������ .R��  �� $	��150 ��� $��50 �.+��� $��0��$��20(����� *Title+�� -   $��1��$��25��$��25��
������ 
������  &
 "MaterialDesignFloatingActionButton#��[
 .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=null]]	   Kind$	 CloseCircleOutline=�$��25��$��25�����#B94B50�� -   
 ��Name$
 D_ajouter_bt��$��	0,30,30,0q�$��1��#��[
 $��10��$��Right=�$	��Top=����#4CAF50$��40��$��40�����#4CAF50
������� � ToolTip$ Ajouter��.��  $
	 Plus=�$��35��$��35��� $��0��$��1��.+�]� 
�������$	��5,0q�.+��� $	��Top=����#2e86de$��50��.+��� $��Center=�
�������$��20(�Les articles� $��1��.+��� -   $ lv_items������ .R��  �� $��50 ��� $	��150 ��� $��50 ��� $��80 ��� $	��100 ��� $��50 �.+�  $	 Brightness1=�$��0��$��25��$��25������ *Color+���� *Color+�� $��1��$��20(����� *Title+�� $��2�� �� Orientation$ 
Horizontal=�.+��� $��20(�
��� d ����� *Price+�� $	��€��$��20(�
��� d �#  MaterialDesignThemes.Wpf.Chip  $��3��
������� J� IsHitTestVisible �� *Actif+���� *Status+���� *StatusColor+�� -   $��4��.��
Modifier�� -   $��5��$��25��$��25��
������ 
������ #��[
 .��  $	 CloseCircleOutline=�$��25��$��25�����#B94B50�� -   $
 
bt_addItem��$��	0,30,30,0q�$��1��#��[
 $��10��$��Right=�$	��Top=����#4CAF50$��40��$��40�����#4CAF50
�������$ Ajouter��.��  $
	 Plus=�$��35��$��35��� $��0��$��2��.+�]� 
�������$	��5,0q�.+��� $	��Top=����#2e86de$��50��.+��� $��Center=�
�������$��20(�Options des articles� $��1��.+��� -   $ lv_itemsOptions������ .R��  �� $	��150 ��� $��50 �.+��� $��0��$ 
Horizontal=�.+��� $��20(����� *Title+�� -	   $��1��$��25��$��25��
������ 
������ #��[
 .��  $	 CloseCircleOutline=�$��25��$��25�����#B94B50�� -
   $
 bt_addItemOption��$��	0,30,30,0q�$��1��#��[
 $��10��$��Right=�$	��Top=����#4CAF50$��40��$��40�����#4CAF50
�������$ Ajouter��.��  $
	 Plus=�$��35��$��35��� $��1��$	��0,5q� �� �� .+�� $��0��.+�]� 
�������$	��5,0q�.+��� $	��Top=����#2e86de$��50��.+��� $��Center=�
�������$��20(�Familles des ingrédients� $��1��.+��� -   $ lv_ingredientCategory������ .R�� $��Stretch=� �� $	��150 ��� $	��100 ��� $��50 �.+��� $��0��$��20(����� *Title+�� -   $��1��.��
Modifier�� -   $��2��$��25��$��25��
������ 
������ #��[
 .��  $	 CloseCircleOutline=�$��25��$��25�����#B94B50�� -   $
 bt_addIngredientCat��$��	0,30,30,0q�$��1��#��[
 $��10��$��Right=�$	��Top=����#4CAF50$��40��$��40�����#4CAF50
�������$ Ajouter��.��  $
	 Plus=�$��35��$��35��� $��1��.+�]� 
�������$	��5,0q�.+��� $	��Top=����#2e86de$��50��.+��� $��Center=�
�������$��20(�Les ingrédients� $��1��.+��� -   $ lv_ingredient������ .R��  �� $	��120 ��� $��50 ��� .+��� $��0��$��20(����� *Title+�� -   $��1��$��25��$��25��
������ 
������ #��[
 .��  $	 CloseCircleOutline=�$��25��$��25�����#B94B50�� -   $
 bt_addIngredient��$��	0,30,30,0q�$��1��#��[
 $��10��$��Right=�$	��Top=����#4CAF50$��40��$��40�����#4CAF50
�������$ Ajouter��.��  $
	 Plus=�$��35��$��35���� $��Gestion des menus��.���  �� �� ��  �� �� .+�� $��0��.+�]� 
�������$	��5,0q�.+��� $	��Top=����#2e86de$��50��.+��� $��Center=�
�������$��20(�	Les menus� .+��� -   $ lv_menu������ .R��  �� $	��180 ��� $��50 �.+��� $��0��$��20(����� *Title+�� -   $��1��$��25��$��25��
������ 
������ #��[
 .��  $	 CloseCircleOutline=�$��25��$��25�����#B94B50�� -   $
 D_ajouterMenu_bt��$��	0,30,30,0q�$��1��#��[
 $��10��$��Right=�$	��Top=����#4CAF50$��40��$��40�����#4CAF50
�������$ Ajouter��.��  $
	 Plus=�$��35��$��35��� $��0��$��1��.+�]� 
�������$	��5,5q�.+��� $	��Top=����#2e86de$��50��.+��� $��Center=�
�������$��20(�	Options� .+��� -   $ lv_menuSelectedOption������ .R��  �� $	��150 ��� $��50 �.+��� $��0��$��20(����� *Title+�� -   $��1��$��25��$��25��
������ 
������ #��[
 .��  $	 CloseCircleOutline=�$��25��$��25�����#B94B50�� -   $$
 D_ajouterMenuSelectedOption_bt��$��	0,30,30,0q�$��1��#��[
 $��10��$��Right=�$	��Top=����#4CAF50$��40��$��40�����#4CAF50
�������$ Ajouter��.��  $
	 Plus=�$��35��$��35��� $��1��$��0��.+�]� 
�������$	��5,5q�.+��� $	��Top=����#2e86de$��50��.+��� $��Center=�
�������$��20(�Choix du menu� .+��� -   $ lv_menuOption������ .R��  �� $	��150 ��� $��50 �.+��� $��0��$��20(����� *Title+�� -   $��1��$��25��$��25��
������ 
������ #��[
 .��  $	 CloseCircleOutline=�$��25��$��25�����#B94B50�� -   $
 D_ajouterMenuOption_bt��$��	0,30,30,0q�$��1��#��[
 $��10��$��Right=�$	��Top=����#4CAF50$��40��$��40�����#4CAF50
�������$ Ajouter��.��  $
	 Plus=�$��35��$��35��� $��1��$��1��.+�]� 
�������$	��5,5q�.+��� $	��Top=����#2e86de$��50��.+��� $��Center=�
�������$��20(�Les produits� .+��� -   $ lv_menuItemsOptions������ .R��  �� $	��150 ��� $��50 �.+��� $��0��$��20(����� *Title+�� -   $��1��$��25��$��25��
������ 
������ #��[
 .��  $	 CloseCircleOutline=�$��25��$��25�����#B94B50�� -   $
 D_ajouterItemsOptions_bt��$��	0,30,30,0q�$��1��#��[
 $��10��$��Right=�$	��Top=����#4CAF50$��40��$��40�����#4CAF50
�������$ Ajouter��.��  $
	 Plus=�$��35��$��35��